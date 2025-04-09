using Player;
using UnityEngine;

public class PlayerWallRunRight : PlayerBaseState
{
    public PlayerWallRunRight(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        _animationRequester.RequestAnimation(_animations.wallrunRight);

        Vector3 wallDirection = Vector3.right;
        Vector3 moveDirection = _surfaceDetector.Head.forward;
        _physics.Accelerate(Vector3.zero);
        if (Physics.Raycast(_surfaceDetector.Head.position,
                PlayerUtils.GetRelativeDirection(wallDirection, _surfaceDetector.Head), out var hit,
                _surfaceDetector.WallCheckDistance))
        {
            var wallNormal = hit.normal.normalized;
            var dir = Vector3.ProjectOnPlane(moveDirection, wallNormal);

            _physics.SetImpulse(dir.normalized * _movementDataSo.WallRunSpeedLimit);
            


            Vector3 dirOnPlane = new Vector3(dir.x, 0, dir.z).normalized;
    
            ctx._objectRotator.RotateTowards(dirOnPlane);
        }
        
        
    }

}

