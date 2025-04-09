using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerJumpState: PlayerBaseState
{
    public PlayerJumpState(PlayerContext context) : base(context)
    {
    }

    public override void OnEnter()
    {
        _animationRequester.RequestAnimation(_animations.jump);

        _physics.SetImpulse(new Vector3(_physics.Velocity.x,_movementDataSo.JumpMomentum,_physics.Velocity.z));
    }

}