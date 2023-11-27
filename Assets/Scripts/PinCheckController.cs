using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCheckController : MonoBehaviour
{
    public CountController pinCount;
    bool isCount = false;

    Quaternion prev_transform;

    private void Start()
    {
        prev_transform = GetComponent<Transform>().rotation;
    }
    void Update()
    {
        if(transform.rotation != prev_transform && isCount==false)
        {
            Debug.Log("HIT");
            pinCount.count++;
            isCount = true;

        }
    }
}
