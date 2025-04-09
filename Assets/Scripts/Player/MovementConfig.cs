public class MovementConfig
{
    public MovementConfig(float speedLimit, float movementDrag, float extraVelocityDrag, float extraVelocityLimit)
    {
        SpeedLimit = speedLimit;
        MovementDrag = movementDrag;
        ExtraVelocityDrag = extraVelocityDrag;
        ExtraVelocityLimit = extraVelocityLimit;
    }

    public float SpeedLimit;
    public float MovementDrag;
    public float ExtraVelocityDrag;
    public float ExtraVelocityLimit;
}