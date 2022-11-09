using UnityEngine;
using System;

public class PlayerPointsManager : MonoBehaviour
{
    public event Action OnChangedPlayerPoints;

    public int PlayerPoints { get; private set; }

    public void IncreasePlayerPoints(int amountToIncrease)
    {
        PlayerPoints += Mathf.Abs(amountToIncrease);

        OnChangedPlayerPoints?.Invoke();
    }
}
