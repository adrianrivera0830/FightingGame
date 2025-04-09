using System;
using Animancer;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour, IAnimationRequester
{
  //plugin extra de animaciones. Dificl de explicar pero no hace la gran cosa
    [SerializeField] private AnimancerComponent  _animancerComponent;
    public float lerpSpeed = 5f; // Puedes ajustar este valor desde el inspector


    public void RequestAnimation(TransitionAsset clipTransition)
    {
        if(_animancerComponent.IsPlaying(clipTransition)) return;
        _animancerComponent.Play(clipTransition);

    }

    public void UpdateState(TransitionAsset clipTransition, float targetValue)
    {
        var state = (LinearMixerState)_animancerComponent.States[clipTransition];
        state.Parameter = Mathf.Lerp(state.Parameter, targetValue, Time.deltaTime * lerpSpeed);
    }

    public void UpdateState(TransitionAsset clipTransition, Vector2 targetValue)
    {
        var state = (DirectionalMixerState)_animancerComponent.States[clipTransition];
        state.Parameter = Vector2.Lerp(state.Parameter, targetValue, Time.deltaTime * lerpSpeed);
    }


}
