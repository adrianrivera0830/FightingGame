using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveGroundedState : PlayerBaseState
{
    public PlayerMoveGroundedState(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        MovementConfig groundedConfig = new MovementConfig (
            _movementDataSo.GroundedSpeedLimit,
            _movementDataSo.GroundedDrag,
            _movementDataSo.GroundedExtraVelDrag,
            _movementDataSo.GroundedExtraVelSpeedLimit
            );

        _physics.SetGravity(0);
        _physics.SetImpulse(new Vector3(_physics.Velocity.x,0,_physics.Velocity.z));
        _physics.SetMovementConfig(groundedConfig);
        
    }


    public override void OnUpdate()
    {
        Vector3 inputDir = PlayerInputManager.moveInput.x * _surfaceDetector.Feet.right + PlayerInputManager.moveInput.y * _surfaceDetector.Feet.forward;
        
        _physics.Accelerate(inputDir * _movementDataSo.GroundedAcceleration);
        
        float normlizedSpeed = _physics.Velocity.magnitude / _movementDataSo.GroundedSpeedLimit;
        _animationRequester.RequestAnimation(_animations.sprint);
        _animationRequester.UpdateState(_animations.sprint,PlayerInputManager.moveInput.normalized * normlizedSpeed);

            

    }
    
}