using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{

    private TextMeshProUGUI _playerNameText;

    private TextMeshProUGUI _playerScoreText;

    private void Awake()
    {
        _playerNameText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _playerScoreText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void SetPlayerNameAndScore(string playerName, int playerScore)
    {
        _playerNameText.text = playerName;
        _playerScoreText.text = playerScore.ToString();
    }
}
