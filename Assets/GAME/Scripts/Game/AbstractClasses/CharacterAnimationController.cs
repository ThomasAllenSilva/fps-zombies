using UnityEngine;

public abstract class CharacterAnimationController : MonoBehaviour
{
    protected Animator _characterAnimator;

    [Range(1f, 12f)] [SerializeField] protected float _animationsTransitionSpeed = 4f;


    protected static string BlendTreeAnimationParameterName = "CurrentAnimationStateValue";

    protected virtual void Awake()
    {
        _characterAnimator = GetComponent<Animator>();
    }
}
