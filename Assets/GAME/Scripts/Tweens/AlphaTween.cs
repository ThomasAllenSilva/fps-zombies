using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class AlphaTween : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    [SerializeField] private float _animationDuration = 1.5f;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

    private void Start() => PlayFadeOutAnimation();
    
    public void PlayFadeInAnimationAndLoadScene(int sceneIndexToLoad)
    {
        _canvasGroup.alpha = 0f;
        LeanTween.alphaCanvas(_canvasGroup, 1f, _animationDuration).setIgnoreTimeScale(true).setOnComplete(() => ScenesManager.Instance.LoadSceneByIndex(sceneIndexToLoad));
    }

    public void PlayFadeInAnimation()
    {
        _canvasGroup.alpha = 0f;
        LeanTween.alphaCanvas(_canvasGroup, 1f, _animationDuration).setIgnoreTimeScale(true);
    }

    public void LoadSceneWithoutFade(int sceneIndexToLoad)
    {
        ScenesManager.Instance.LoadSceneByIndex(sceneIndexToLoad);
    }

    public async void PlayFadeOutAnimation()
    {
        await Task.Delay((int) _animationDuration * 1000);
        _canvasGroup.alpha = 1f;
        LeanTween.alphaCanvas(_canvasGroup, 0f, _animationDuration);
    }
}