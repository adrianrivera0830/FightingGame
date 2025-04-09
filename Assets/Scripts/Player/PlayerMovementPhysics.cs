using System;
using TMPro;
using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour, IPlayerPhysics
{
    [Header("General Settings")] [SerializeField]
    private float _minSpeedReset;

    [SerializeField] private float _minDirectionalAlignment;

    [Header("References")] [SerializeField]
    private CharacterController characterController;

    [Header("Debug UI (Opcional)")] [SerializeField]
    private TextMeshProUGUI speedText;

    [SerializeField] private TextMeshProUGUI momentumText;

    [Header("Gizmos Debug")] [SerializeField]
    private Transform gizmosOrigin;

    [SerializeField] private float gizmosRayLength = 3f;

    private Vector3 _velocity;
    private Vector3 _acceleration;
    
    //extra velocity o boost, en otras palabras momentum (como en titanfall) aun no se implementa del todo
    private Vector3 _extraVelocity;

    private float _gravity;
    private float _speedLimit;
    private float _extraVelocityLimit;
    private float _movementDrag;
    private float _extraVelocityDrag;

    private void Update()
    {
        ApplyAcceleration();
        ApplyGravity();
        ApplyVelocityDrag();
        ApplyExtraVelocityHorizontalDrag();
        //priorizamos aplicar todos los efectos de fisica primero para al final limitar la velocidad

        LimitSpeed();
        LimitBoost();
        MovePlayer();
        UpdateUI();
    }

    private void ApplyExtraVelocityHorizontalDrag()
    {
        var horizontalVel = _velocity;
        horizontalVel.y = 0;

        var horizontalExtraVel = _extraVelocity;
        horizontalExtraVel.y = 0;

        var directionAlignment = Vector3.Dot(horizontalExtraVel.normalized, horizontalVel.normalized);

        if (directionAlignment < _minDirectionalAlignment || _extraVelocity.magnitude < _minSpeedReset)
            _extraVelocity = Vector3.zero;

        _extraVelocity += _extraVelocityDrag * Time.deltaTime * -_extraVelocity.normalized;
    }

    private void ApplyAcceleration()
    {
        _velocity += _acceleration * Time.deltaTime;
    }


    private void ApplyVelocityDrag()
    {
        _velocity += -_velocity.normalized * (_movementDrag * Time.deltaTime);
        if (_velocity.magnitude + _acceleration.magnitude < _minSpeedReset)
        {
            _velocity = Vector3.zero;
        }
    }

    private void ApplyGravity()
    {
        
        _velocity += new Vector3(0, -_gravity, 0) * Time.deltaTime;
    }

    private void LimitSpeed()
    {
        var flatVel = new Vector3(_velocity.x, 0, _velocity.z);
        if (flatVel.magnitude > _speedLimit)
        {
            var limitedVel = flatVel.normalized * _speedLimit;
            _velocity = new Vector3(limitedVel.x, _velocity.y, limitedVel.z);
        }
    }

    private void LimitBoost()
    {
        if (_extraVelocity.magnitude > _extraVelocityLimit)
            _extraVelocity = _extraVelocity.normalized * _extraVelocityLimit;
    }


    private void MovePlayer()
    {
        var movement = _velocity + _extraVelocity;
        characterController.Move(movement * Time.deltaTime);
    }

    #region Debug

    private void UpdateUI()
    {
        if (speedText != null)
        {
            var velWithoutGravity = _velocity;
            velWithoutGravity.y = 0;
            speedText.text = Math.Round(velWithoutGravity.magnitude + _extraVelocity.magnitude, 2).ToString();
        }

        if (momentumText != null) momentumText.text = Math.Round(_extraVelocity.magnitude, 2).ToString();
    }

    private void OnDrawGizmos()
    {
        if (gizmosOrigin == null) return;

        // Dibujar Velocity (azul)
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            gizmosOrigin.position,
            gizmosOrigin.position + _velocity.normalized * gizmosRayLength
        );

        // Dibujar BoostVelocity (rojo)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(
            gizmosOrigin.position,
            gizmosOrigin.position + _extraVelocity.normalized * gizmosRayLength
        );
    }

    #endregion

    public Vector3 Velocity => _velocity;
    
    
    //Configuracion que dicat como se comportara las fisicas 
    //Cada estado puede tener su propia configuracion
    public void SetMovementConfig(MovementConfig config)
    {
        _speedLimit = config.SpeedLimit;
        _movementDrag = config.MovementDrag;
        _extraVelocityLimit = config.ExtraVelocityLimit;
        _extraVelocityDrag = config.ExtraVelocityDrag;
    }

    public void SetGravity(float gravity)
    {
        _gravity = gravity;
    }
    
    public void Accelerate(Vector3 acceleration)
    {
        _acceleration = acceleration;
    }

    public void SetImpulse(Vector3 impulse)
    {
        _velocity = impulse;
    }

    public void ChangeExtraVelocityDirection(Vector3 newDirection)
    {
        var magnitude = _extraVelocity.magnitude;
        _extraVelocity = newDirection.normalized * magnitude;
    }
}