using System.Collections;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
    private const int _leaderBoardID = 8737;

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
                    _scores[i].SetPlayerNameAndScore(scores[i].player.name, scores[i].score);
                }

            }

            else
            {
                Debug.Log(onComplete.Error);
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
        });

        yield return new WaitWhile(() => doneRequest == false);
    }
}
