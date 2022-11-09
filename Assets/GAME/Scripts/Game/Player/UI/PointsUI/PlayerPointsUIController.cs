using UnityEngine;
using TMPro;

public class PlayerPointsUIController : MonoBehaviour
{
    private TextMeshProUGUI _playerPointsText;

    private PlayerPointsManager _playerPointsManager;

    private void Awake()
    {
        _playerPointsText = GetComponent<TextMeshProUGUI>();
        _playerPointsManager = GameManager.Instance.PlayerPointsManager;
    }

    private void Start()
    {
        _playerPointsManager.OnChangedPlayerPoints += UpdatePlayerPoints;
    }

    private void UpdatePlayerPoints()
    {
        _playerPointsText.text = _playerPointsManager.PlayerPoints.ToString();
    }
}
