using System;
using Player;
using UnityEngine;

public class SurfaceDetector : MonoBehaviour
{
    [Header("Wall Check")] 
    [SerializeField] private Transform head;

    [SerializeField] private float wallCheckDistance;

    [Header("Ground Check")] 
    [SerializeField] private Transform feet;

    [SerializeField] private float isGroundedRayDistance = 0.2f;

    public bool IsGrounded => Physics.Raycast(feet.position, Vector3.down, isGroundedRayDistance);
    
    public float WallCheckDistance => wallCheckDistance;
    public Transform Feet => feet;
    public Transform Head => head;


    public bool WallRight    => CheckWall(Vector3.right);
    public bool WallLeft     => CheckWall(Vector3.left);
    public bool WallForward  => CheckWall(Vector3.forward);
    public bool WallBackward => CheckWall(Vector3.back);


    public bool IsTouchingWall => WallRight || WallLeft || WallForward|| WallBackward;
    
    private bool CheckWall(Vector3 direction)
    {
        var relativeDir = PlayerUtils.GetRelativeDirection(direction, head);
        return Physics.Raycast(head.position, relativeDir, wallCheckDistance);
    }



}
