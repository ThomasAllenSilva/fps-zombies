using UnityEngine;
using System;

public abstract class CharacterAnimationController<T> : MonoBehaviour where T : Enum
{
    protected Animator _characterAnimator;

    protected bool _canPlayAnimations = true;

    protected T _currentAnimationState;

    protected virtual void Awake() => _characterAnimator = GetComponent<Animator>();
    
    protected void ChangeCurrentAnimationState(T animationToPlay)
    {
        if (!_canPlayAnimations && animationToPlay.ToString() == _currentAnimationState.ToString())
        {
            return;
        }

        _characterAnimator.Play(animationToPlay.ToString());

        _currentAnimationState = animationToPlay;
    }
}
