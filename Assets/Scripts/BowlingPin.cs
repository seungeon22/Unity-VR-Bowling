using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    public float knockDownForce = 50f; // �������� �Ѿ�߸��� ��

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // �������� �浹�ϸ� �������� �Ѿ�߸��ϴ�.
            Rigidbody pinRigidbody = GetComponent<Rigidbody>();
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection.Normalize();

            pinRigidbody.AddForce(forceDirection * knockDownForce, ForceMode.Impulse);
        }
    }
}
