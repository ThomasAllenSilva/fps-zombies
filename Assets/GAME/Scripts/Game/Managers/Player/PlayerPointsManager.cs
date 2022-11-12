using System;
using System.Collections;
using LootLocker.Requests;
using UnityEngine;
using TMPro;

public class PlayerPointsManager : MonoBehaviour
{
    public event Action OnChangedPlayerPoints;

    private const int _leaderBoardID = 8737;

    public int PlayerPoints { get; private set; }

    public void IncreasePlayerPoints(int amountToIncrease)
    {
        PlayerPoints += Mathf.Abs(amountToIncrease);

        OnChangedPlayerPoints?.Invoke();
    }

    private IEnumerator SendScoreToLeaderboard()
    {
        bool doneRequest = false;

        LootLockerSDKManager.SubmitScore(SystemInfo.deviceUniqueIdentifier, PlayerPoints, _leaderBoardID, (responde) =>
        {
            doneRequest = true;

            if (responde.success)
            {
                Debug.Log("send");
            }

            else
            {
                Debug.Log(responde.Error);
            }
        });

        yield return new WaitWhile(() => doneRequest == false);
    }

    public void SendScore(TextMeshProUGUI playerName)
    {
        LootLockerSDKManager.SetPlayerName(playerName.text, (send) => { });

        StartCoroutine(SendScoreToLeaderboard());
    }
}
