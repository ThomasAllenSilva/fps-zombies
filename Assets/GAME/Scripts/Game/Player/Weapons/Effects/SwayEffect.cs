using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayEffect : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void LateUpdate()
    {
        SwayPlayerHands();
    }

    private void SwayPlayerHands()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.parent.parent.eulerAngles), speed * Time.deltaTime);
    }
}
