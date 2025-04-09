public class MovementConfig
{
    public MovementConfig(float speedLimit, float movementDrag, float extraVelocityDrag, float extraVelocityLimit)
    {
        SpeedLimit = speedLimit;
        MovementDrag = movementDrag;
        ExtraVelocityDrag = extraVelocityDrag;
        ExtraVelocityLimit = extraVelocityLimit;
    }

    public readonly float SpeedLimit;
    public readonly float MovementDrag;
    public readonly float ExtraVelocityDrag;
    public readonly float ExtraVelocityLimit;
}