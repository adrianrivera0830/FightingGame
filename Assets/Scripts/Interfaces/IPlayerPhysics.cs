using UnityEngine;

public interface IPlayerPhysics
{
    public Vector3 Velocity { get; }
    public void SetMovementConfig(MovementConfig config);
    public void SetGravity(float gravity);
    public void Accelerate(Vector3 acceleration);
    public void SetImpulse(Vector3 impulse);
    public void ChangeExtraVelocityDirection(Vector3 newDirection);
}