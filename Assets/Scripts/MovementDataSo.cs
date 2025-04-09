using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "MovementDataSO", menuName = "Scriptable Objects/MovementDataSO")]
public class MovementDataSo : ScriptableObject
{
    [Header("GroundedAccelerationd")]
    public float GroundedAcceleration;
    public float GroundedDrag;
    public float GroundedSpeedLimit;
    public float GroundedExtraVelSpeedLimit;
    public float GroundedExtraVelDrag;


    [Header("Airborne")]
    public float AirborneAcceleration;
    public float AirborneDrag;
    public float AirborneSpeedLimit;
    public float AirborneExtraVelSpeedLimit;
    public float AirborneExtraVelDrag;
    
    [Header("Jump")]
    public float JumpMomentum;
    public float GravityUpward; 
    public float GravityDownward; 

    [Header("Dash")]
    public float DashSpeed;
    public float DashExtraSpeedGain;
    public float DashDuration;

    [Header("WallRun")]
    public float WallRunAcceleration;

    public float timeUntilGravity;
    public float wallRunGravity;
    public float WallRunDrag;
    public float WallRunSpeedLimit;
    public float WallRunExtraVelSpeedLimit;
    public float WallRunExtraVelDrag;


    [Header("WallJump")] 
    public float horizontalWallJumpForce;
    public float verticalWallJumpForce;
    public float fowardWallJumpForce;


}


