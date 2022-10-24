using UnityEngine;

public class ZombieRagdollController : MonoBehaviour
{
    private Rigidbody[] rigidbodiesFromRagdoll;

    private void Awake() => rigidbodiesFromRagdoll = GetComponentsInChildren<Rigidbody>();

    public void EnableRagdoll()
    {
        foreach (Rigidbody rigidbody in rigidbodiesFromRagdoll)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void DisableRagdoll()
    {
        foreach (Rigidbody rigidbody in rigidbodiesFromRagdoll)
        {
            rigidbody.isKinematic = true;
        }
    }

    private void OnEnable()
    {
        DisableRagdoll();
    }
}
