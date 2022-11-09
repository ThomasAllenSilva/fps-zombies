using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    private const int _leaderBoardID = 8720;

    private Scores[] _scores;

    private void Awake()
    {
        _scores = GetComponentsInChildren<Scores>();
    }

    private IEnumerator Start()
    {
        yield return LoginRequest();
        yield return GetTopTenHighScores();
    }

    private IEnumerator SubmitScore(int scoreToSubmit)
    {
        bool doneRequest = false;

        string playerID = PlayerPrefs.GetString("PlayerID");

        LootLockerSDKManager.SubmitScore(playerID, scoreToSubmit, _leaderBoardID, (responde) =>
        {
            doneRequest = true;

            if (responde.success)
            {
                Debug.Log("send");
            }
        });

        yield return new WaitWhile(() => doneRequest == false);
    }

    private IEnumerator GetTopTenHighScores()
    {
        bool done = false;

        LootLockerSDKManager.GetScoreList(_leaderBoardID, 10, 0, (onComplete) =>
        {
            if (onComplete.success)
            {
                LootLockerLeaderboardMember[] scores = onComplete.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    _scores[i].SetPlayerNameAndScore(scores[i].player.id.ToString(), scores[i].score);

                }

            }

            done = true;
        });

        yield return new WaitWhile(() => done == false);
    }
    private IEnumerator LoginRequest()
    {

        bool doneRequest = false;

        LootLockerSDKManager.StartGuestSession((connected) =>
        {
            doneRequest = true;

            if (connected.success)
            {
                PlayerPrefs.SetString("PlayerScoreID", connected.player_id.ToString());

                return;
            }
        });

        yield return new WaitWhile(() => doneRequest == false);
    }
}
