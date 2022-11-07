using UnityEngine;
using System;

public abstract class CharacterAnimationController<T> : MonoBehaviour where T : Enum
{
    protected Animator _characterAnimator;

    protected bool _canPlayAnimations = true;

    protected virtual void Awake() => _characterAnimator = GetComponent<Animator>();

    protected void ChangeCurrentAnimationState(T animationToPlay)
    {
        _characterAnimator.Play(animationToPlay.ToString());
    }
}
