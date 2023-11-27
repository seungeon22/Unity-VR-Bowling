using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    public float launchForce = 10.0f; // ������ ���� ũ��

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // ZŰ�� ������ ����� �����ϰ� ������Ʈ�� ����߸��ϴ�.
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
