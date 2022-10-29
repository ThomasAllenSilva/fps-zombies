using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeTwoAttackManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.parent = other.gameObject.transform;
            transform.localPosition = new Vector3(0f, transform.localPosition.y, -3.5f);
        }
    }
}
