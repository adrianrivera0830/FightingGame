
    using UnityEngine;

    public class PlayerWallJumpRight: PlayerBaseState
    {
        public PlayerWallJumpRight(PlayerContext context) : base(context)
        {
        }
        
        public override void OnEnter()
        {
            Vector3 dir = _surfaceDetector.Head.transform.right * -_movementDataSo.horizontalWallJumpForce +
                          _surfaceDetector.Head.transform.forward * _movementDataSo.fowardWallJumpForce;
            dir.y = _movementDataSo.verticalWallJumpForce;
            _physics.SetImpulse(dir);
        }
    }