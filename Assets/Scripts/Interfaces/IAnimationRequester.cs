using System;
using Animancer;
using UnityEngine;

public interface IAnimationRequester
{
    public void RequestAnimation(TransitionAsset clipTransition);
    public void UpdateState(TransitionAsset clipTransition, float value);

    public void UpdateState(TransitionAsset clipTransition,Vector2 value);
}