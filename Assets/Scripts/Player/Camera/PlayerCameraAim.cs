using UnityEngine;
using System;
using Interfaces;

public class PlayerCameraAim : MonoBehaviour, IPlayerCamera
{
    [Header("Referencias")]
    [SerializeField] private Transform cameraTransform;

    public void RotateCamera(Vector2 rotation)
    {
        cameraTransform.localRotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
    }
}