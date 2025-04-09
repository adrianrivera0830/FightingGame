using Player;
using UnityEngine;

public class PlayerWallRunDownward : PlayerBaseState
{
    public PlayerWallRunDownward(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        Vector3 wallDirection = Vector3.back;
        Vector3 moveDirection = _surfaceDetector.Head.up;
        _physics.Accelerate(Vector3.zero);

        if (Physics.Raycast(_surfaceDetector.Head.position,
                PlayerUtils.GetRelativeDirection(wallDirection, _surfaceDetector.Head), out var hit,
                _surfaceDetector.WallCheckDistance))
        {
            var wallNormal = hit.normal.normalized;
            var dir = Vector3.ProjectOnPlane(moveDirection, wallNormal);

            _physics.SetImpulse(dir.normalized * _movementDataSo.WallRunSpeedLimit);
        }
    }


}
