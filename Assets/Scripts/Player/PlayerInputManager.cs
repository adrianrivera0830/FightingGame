using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference dashAction;
    [SerializeField] private InputActionReference lookAction;

    public static event Action JumpEvent;
    public static event Action DashEvent;
    public static Vector2 moveInput;
    public static Vector2 lookInput;
    public static bool isPressingJump;


    void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        lookInput = lookAction.action.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        jumpAction.action.started += (_) => isPressingJump = true;  // Se activa al presionar el botón
        jumpAction.action.canceled += (_) => isPressingJump = false; // Se desactiva al soltar el botón
        jumpAction.action.performed += Jump;
        dashAction.action.performed += Dash;
    }

    void OnDisable()
    {
        jumpAction.action.started -= (_) => isPressingJump = true;
        jumpAction.action.canceled -= (_) => isPressingJump = false;
        jumpAction.action.performed -= Jump;
        dashAction.action.performed -= Dash;
    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        JumpEvent?.Invoke();
    }

    public void Dash(InputAction.CallbackContext callbackContext)
    {
        DashEvent?.Invoke();
    }
}