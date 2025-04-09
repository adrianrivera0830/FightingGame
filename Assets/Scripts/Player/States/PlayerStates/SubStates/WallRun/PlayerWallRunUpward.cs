using Player;
using UnityEngine;

public class PlayerWallRunUpward : PlayerBaseState
{
    public PlayerWallRunUpward(PlayerContext context) : base(context)
    {
    }
    
    public override void OnEnter()
    {
        _animationRequester.RequestAnimation(_animations.wallrunUp);

        Vector3 wallDirection = Vector3.forward;
        Vector3 moveDirection = _surfaceDetector.Head.up;
        _physics.Accelerate(Vector3.zero);

        if (Physics.Raycast(_surfaceDetector.Head.position,
                PlayerUtils.GetRelativeDirection(wallDirection, _surfaceDetector.Head), out var hit,
                _surfaceDetector.WallCheckDistance))
        {
            var wallNormal = hit.normal.normalized;
            var dir = Vector3.ProjectOnPlane(moveDirection, wallNormal);

            _physics.SetImpulse(dir.normalized * _movementDataSo.WallRunSpeedLimit);
            
            Vector3 dirOnPlane = new Vector3(-wallNormal.x, 0, -wallNormal.z).normalized;
    
            ctx._objectRotator.RotateTowards(dirOnPlane);
        }
    }

    
}

