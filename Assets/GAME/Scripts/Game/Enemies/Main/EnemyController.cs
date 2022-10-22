using UnityEngine;

[RequireComponent(typeof(NavMeshTargetManager))]

public class EnemyController : MonoBehaviour
{
    public EnemyCollisionsManager EnemyCollisionsManager { get; private set; }

    private void Awake()
    {
        EnemyCollisionsManager = GetComponent<EnemyCollisionsManager>();
    }
}
