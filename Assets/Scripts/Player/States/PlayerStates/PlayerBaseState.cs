using Interfaces;

public class PlayerBaseState : BaseState<PlayerContext>
{
        protected IPlayerPhysics _physics;
        protected MovementDataSo _movementDataSo;
        protected SurfaceDetector _surfaceDetector;
        protected IAnimationRequester _animationRequester;
        protected StateAnimations _animations;
        protected IPlayerCamera _playerCameraAim;
        protected IObjectRotator _objectRotator;
        public PlayerBaseState(PlayerContext context) : base(context)
        {
                _physics = context._physics;
                _movementDataSo = context._movementDataSo;
                _surfaceDetector = context._surfaceDetector;
                _animationRequester = context._animationRequester;
                _animations = context._stateAnimations;
                _playerCameraAim = context._playerCamera;
                _objectRotator = context._objectRotator;
        }
        
        
}
