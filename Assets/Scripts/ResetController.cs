using UnityEngine;

public class ResetController : MonoBehaviour
{
    public GameObject ballPrefab; // ���������� ����� �� ������
    public Transform spawnPoint;  // ������� ��ġ
    public float forceMagnitude = 10f; // ���� ũ��
    public float torqueMagnitude = 5f; // ȸ���� ũ��

    private void OnTriggerEnter(Collider other)
    {
        
        
        // ���� �浹�� ������Ʈ�� �±װ� "Ball"���
        if (other.CompareTag("Ball"))
        {
            // ���� ���� ����
            Destroy(other);
            Debug.Log("2");
            // 5�� �ڿ� ���� �����ϴ� �Լ� ȣ��
            Invoke("RespawnBall", 5f);
            Debug.Log("3");
        }
    }

    private void RespawnBall()
    {
        Debug.Log("4");
        // ���� ���ο� ��ġ�� ����
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        // ���� ���� ���ϰ� ȸ���� �ο�
        Rigidbody rb = newBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // ���� ����
        rb.AddForce(newBall.transform.forward * forceMagnitude, ForceMode.Impulse);

        // ȸ���� �ο�
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueMagnitude;
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        // ���� Z�� �������� ���������� �߰� ȸ��
        Vector3 rollTorque = new Vector3(0f, 0f, 1f) * torqueMagnitude;
        rb.AddTorque(rollTorque, ForceMode.Impulse);
    }
}
