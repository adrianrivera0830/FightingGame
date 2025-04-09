using UnityEngine;

public class PlayerDashState: PlayerBaseState
{
    //por implementar clase
    public PlayerDashState(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        // _playerMovementPhysics.SetConfiguration(true,0,_movementDataSo.DashSpeed,0,0,_movementDataSo.DashExtraSpeedGain);
        // Vector3 inputDir = PlayerInputManager.moveInput.x * _surfaceDetector.Feet.right + PlayerInputManager.moveInput.y * _surfaceDetector.Feet.forward;
        // _playerMovementPhysics.Velocity = inputDir.normalized * _movementDataSo.DashSpeed;
        //
        //
        // _playerMovementPhysics.BoostVelocity = inputDir.normalized * _movementDataSo.DashExtraSpeedGain;

    }

    public float TimeElapsed = 0;
    public override void OnExit()
    {
        // TimeElapsed = 0;

    }

    public override void OnUpdate()
    {
        // TimeElapsed += Time.deltaTime;
    }
    
}