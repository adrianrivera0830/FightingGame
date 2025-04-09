using Interfaces;

public class PlayerContext
{


     public SurfaceDetector _surfaceDetector { get; }
     public MovementDataSo _movementDataSo { get; }
     public IPlayerPhysics _physics { get; }
     public IAnimationRequester _animationRequester { get; }
     public IPlayerCamera _playerCamera { get; }
     public IObjectRotator _objectRotator { get; }
     public PlayerContext(SurfaceDetector surfaceDetector, MovementDataSo movementDataSo, PlayerMovementPhysics playerMovementPhysics, PlayerAnimatorController animationRequester, StateAnimations stateAnimations, PlayerCameraAim playerCameraAim, PlayerRotator playerRotator)
     {
          _animationRequester = animationRequester;
          _surfaceDetector = surfaceDetector;
          _movementDataSo = movementDataSo;
          _physics = playerMovementPhysics;
          _stateAnimations = stateAnimations;     
          _playerCamera = playerCameraAim;
          _objectRotator = playerRotator;
     }

     public StateAnimations _stateAnimations { get; }
     
     
}
