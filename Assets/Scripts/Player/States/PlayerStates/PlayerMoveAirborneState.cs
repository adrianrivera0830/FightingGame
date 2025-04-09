using UnityEngine;

public class PlayerMoveAirborneState : PlayerBaseState
{
    public PlayerMoveAirborneState(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        
        MovementConfig config = new MovementConfig(
            _movementDataSo.AirborneSpeedLimit,
            _movementDataSo.AirborneDrag,
            _movementDataSo.AirborneExtraVelDrag,
            _movementDataSo.AirborneExtraVelSpeedLimit
        );
        
        _physics.SetGravity(_movementDataSo.GravityUpward);
        _physics.SetMovementConfig(config);
        

    }



    public override void OnUpdate()
    {
        Vector3 inputDir = PlayerInputManager.moveInput.x * _surfaceDetector.Feet.right + PlayerInputManager.moveInput.y * _surfaceDetector.Feet.forward;
        _physics.Accelerate(inputDir * _movementDataSo.AirborneAcceleration);

        if (_physics.Velocity.y < 0)
        {
            _physics.SetGravity(_movementDataSo.GravityDownward);
            _animationRequester.RequestAnimation(_animations.airborneDown);
        }
        else
        {
            _animationRequester.RequestAnimation(_animations.airborneUp);

        }
        
 
    }

}