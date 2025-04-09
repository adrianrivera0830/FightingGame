using Player;
using UnityEngine;

public class PlayerWallRunState : PlayerBaseState
{


    private StateMachine stateMachine;

    private PlayerWallRunRight _playerWallRunRight;
    private PlayerWallRunLeft _playerWallRunLeft;
    private PlayerWallRunUpward _playerWallRunUpward;
    private PlayerWallRunDownward _playerWallRunDownward;
    public PlayerWallRunState(PlayerContext context) : base(context)
    {
        //Sub estados
        stateMachine = new StateMachine();
        _playerWallRunRight  = new PlayerWallRunRight(context);
        _playerWallRunLeft  = new PlayerWallRunLeft(context);
        _playerWallRunUpward  = new PlayerWallRunUpward(context);
        _playerWallRunDownward  = new PlayerWallRunDownward(context);

        stateMachine.RegisterState(_playerWallRunRight);
        stateMachine.RegisterState(_playerWallRunLeft);
        stateMachine.RegisterState(_playerWallRunUpward);
        stateMachine.RegisterState(_playerWallRunDownward);
    }

    public override void OnEnter()
    {
        
        
        MovementConfig config = new MovementConfig (
            _movementDataSo.WallRunSpeedLimit,
            _movementDataSo.WallRunDrag,
            _movementDataSo.WallRunExtraVelDrag,
            _movementDataSo.WallRunSpeedLimit
        );
        
        
        _physics.SetGravity(0);
        _physics.SetImpulse(new Vector3(_physics.Velocity.x,0,_physics.Velocity.z));
        _physics.SetMovementConfig(config);
        
        
        if (_surfaceDetector.WallRight)
            stateMachine.SetCurrentState(_playerWallRunRight);
        else if (_surfaceDetector.WallLeft)
            stateMachine.SetCurrentState(_playerWallRunLeft);
        else if (_surfaceDetector.WallForward)
            stateMachine.SetCurrentState(_playerWallRunUpward);
        else if (_surfaceDetector.WallBackward) 
            stateMachine.SetCurrentState(_playerWallRunDownward);
    }
    
}