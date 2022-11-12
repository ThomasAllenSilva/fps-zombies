using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private Vector2 scaleSizeToAnimate;

    [SerializeField] private float _animationDuration = 0.3f;

    public void PlayScaleInAnimation()
    {
        LeanTween.scale(gameObject, scaleSizeToAnimate, _animationDuration).setIgnoreTimeScale(true);
    }

    public void PlayScaleOutAnimation()
    {
        LeanTween.scale(gameObject, Vector3.zero, _animationDuration);
    }
}