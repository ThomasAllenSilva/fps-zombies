using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshTargetManager))]

public class NavMeshManager : MonoBehaviour
{

    private NavMeshTargetManager meshTargetManager;
    // Start is called before the first frame update
    void Start()
    {
        meshTargetManager = GetComponent<NavMeshTargetManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitplayer");
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hitplayer");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("hitplayer");
    }
}
