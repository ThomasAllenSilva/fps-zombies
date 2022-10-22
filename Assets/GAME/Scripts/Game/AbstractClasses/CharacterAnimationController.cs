using UnityEngine;

public abstract class CharacterAnimationController : MonoBehaviour
{
    protected Animator _characterAnimator;

    protected virtual void Awake()
    {
        _characterAnimator = GetComponent<Animator>();
    }
}
