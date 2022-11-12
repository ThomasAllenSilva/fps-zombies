using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] private AlphaTween _gameOverCanvas;

    [SerializeField] private AlphaTween _submitScoreCanvas;

    private void Start()
    {
        GameManager.Instance.OnGameEnds += _gameOverCanvas.PlayFadeInAnimation;
        GameManager.Instance.OnGameEnds += _submitScoreCanvas.PlayFadeInAnimation;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameEnds -= _gameOverCanvas.PlayFadeInAnimation;
        GameManager.Instance.OnGameEnds -= _submitScoreCanvas.PlayFadeInAnimation;
    }
}
