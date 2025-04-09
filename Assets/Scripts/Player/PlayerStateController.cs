using System;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateController : MonoBehaviour
{
[FormerlySerializedAs("playerPhysics")] [SerializeField] private PlayerMovementPhysics playerMovementPhysics;
[SerializeField] private SurfaceDetector surfaceDetector;
[SerializeField] private MovementDataSo movementDataSo;
[SerializeField] private PlayerAnimatorController animationRequester;
[SerializeField] private StateAnimations stateAnimations;

[SerializeField] private PlayerCameraAim playerCameraAim;
[SerializeField] private PlayerRotator playerRotator;

    private StateMachine _playerStateMachine;
    private StateMachine _cameraStateMachine;

    public StateMachine PlayerStateMachine => _playerStateMachine;

    private void Awake()
    {
        _playerStateMachine = new StateMachine();
    }

    private void Start()
    {
        SetUpPlayerStates();
    }

 

    private void SetUpPlayerStates()
    {
        PlayerContext playerContext = new PlayerContext(surfaceDetector,movementDataSo,playerMovementPhysics,animationRequester,stateAnimations,playerCameraAim,playerRotator);

        
        var groundedState = new PlayerMoveGroundedState(playerContext);
        var jumpState = new PlayerJumpState(playerContext);
        var airborneState = new PlayerMoveAirborneState(playerContext);
        var dashState = new PlayerDashState(playerContext);
        var wallRunState = new PlayerWallRunState(playerContext);
        var wallJumpState = new PlayerWallJumpState(playerContext);

        
        _playerStateMachine.RegisterState(groundedState);
        _playerStateMachine.RegisterState(jumpState);
        _playerStateMachine.RegisterState(airborneState);
        _playerStateMachine.RegisterState(dashState);
        _playerStateMachine.RegisterState(wallRunState);
        _playerStateMachine.RegisterState(wallJumpState);

        
        _playerStateMachine.AddStateTransition(groundedState, new Transition(airborneState,(() => !surfaceDetector.IsGrounded)));
        _playerStateMachine.AddStateTransition(jumpState, new Transition(airborneState,(() => true)));
        _playerStateMachine.AddStateTransition(airborneState, new Transition(groundedState,(() => surfaceDetector.IsGrounded)));
        _playerStateMachine.AddStateTransition(wallRunState, new Transition(airborneState,(() => !surfaceDetector.IsTouchingWall &&  !surfaceDetector.IsGrounded)));
        _playerStateMachine.AddStateTransition(wallRunState, new Transition(groundedState,(() => surfaceDetector.IsGrounded)));

        _playerStateMachine.AddStateTransition(dashState, new Transition(groundedState,(() => dashState.TimeElapsed > movementDataSo.DashDuration)));
        _playerStateMachine.AddStateTransition(wallJumpState, new Transition(airborneState,(() => true)));
        
        PlayerInputManager.JumpEvent += () => _playerStateMachine.ChangeState(wallRunState, new Transition(wallJumpState,(() => true)));
        
        PlayerInputManager.JumpEvent += () => _playerStateMachine.ChangeState(groundedState, new Transition(jumpState,(() => true)));
        PlayerInputManager.DashEvent += () => _playerStateMachine.ChangeState(groundedState, new Transition(dashState,(() => true)));
        
        PlayerInputManager.JumpEvent += () => _playerStateMachine.ChangeState(airborneState, new Transition(wallRunState,(() => surfaceDetector.IsTouchingWall)));
        

        _playerStateMachine.SetCurrentState(airborneState);
    }


    private void Update()
    {
        _playerStateMachine.UpdateState();
    }

    float cameraX;
    float cameraY;

    public void LateUpdate()
    {
        
        //Control de apuntado de la camara
        Vector2 rotation = PlayerInputManager.lookInput * 5 * Time.deltaTime;
        
        //valores en grados
        cameraX -= rotation.y;
        cameraY += rotation.x;
        
        

        playerCameraAim.RotateCamera(new Vector2(cameraX, cameraY));

        Vector3 playerRotation = new Vector3(0, cameraY, 0);
        
        
        //Al rotar la camara tambien se rota el personaje del jugador para que este mire hacia donde miramos
        //No queremos este comportamiento mientras hacemos wallRunning porque si no pareciera como si el personaje no estuviera moviendose paralelo a la pared
        if (_playerStateMachine.GetCurrentStateType() != typeof(PlayerWallRunState))
        {
            
            Vector3 forwardDirection = new Vector3(
                Mathf.Sin(cameraY * Mathf.Deg2Rad),
                0,
                Mathf.Cos(cameraY * Mathf.Deg2Rad)
            );
            
            //Rotar el personaje del jugador
            playerRotator.RotateTowards(forwardDirection);
        }
    }
}   

