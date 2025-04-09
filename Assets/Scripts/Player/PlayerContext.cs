public class PlayerContext
{
     public PlayerContext(SurfaceDetector surfaceDetector, MovementDataSo movementDataSo, IPlayerPhysics physics,IAnimationRequester animationRequester)
     {
          _animationRequester = animationRequester;
          _surfaceDetector = surfaceDetector;
          _movementDataSo = movementDataSo;
          _physics = physics;
     }

     public SurfaceDetector _surfaceDetector { get; }
     public MovementDataSo _movementDataSo { get; }
     public IPlayerPhysics _physics { get; }
     public IAnimationRequester _animationRequester;
     
     
}
