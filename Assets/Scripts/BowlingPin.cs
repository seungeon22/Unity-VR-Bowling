using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public float knockDownForce = 50f; // 볼링핀을 넘어뜨리는 힘

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 볼링공과 충돌하면 볼링핀을 넘어뜨립니다.
            Rigidbody pinRigidbody = GetComponent<Rigidbody>();
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection.Normalize();

            pinRigidbody.AddForce(forceDirection * knockDownForce, ForceMode.Impulse);
        }
    }
}
