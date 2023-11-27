using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    public float launchForce = 10.0f; // 던지는 힘의 크기

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Z키를 누르면 운동량을 설정하고 오브젝트를 떨어뜨립니다.
            transform.parent = null;
            rb.useGravity = true;
            //rb.velocity = new Vector3(0, 0, launchForce);
            rb.velocity = Camera.main.transform.forward * launchForce;
            //Vector3 worldVelocity = transform.TransformDirection(new Vector3(0, 0, launchForce));
            //rb.velocity = worldVelocity;
            //rb.AddForce(new Vector3(0, 0, launchForce), ForceMode.VelocityChange);
        }
    }
}
