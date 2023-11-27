using UnityEngine;

public class StrikeController : MonoBehaviour
{
    public GameObject particleEffectPrefab; // ��ƼŬ ����Ʈ �������� ������ ����
    public string targetTag = "Pin"; // Ÿ�� ������Ʈ�� �±�

    private int targetsHit = 0; // ���� Ÿ�� ��

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±װ� ������ �±׿� ��ġ�ϴ��� Ȯ��
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
        {
            // Ÿ���� ������ �� ������ ����
            HitTarget();

            // ���� Ÿ�� ���� 10������ Ȯ��
            if (targetsHit >= 10)
            {
                // 10���� ���߸� ��ƼŬ ����Ʈ�� ����
                ShowParticleEffect();
            }
        }
    }

    void HitTarget()
    {
        // Ÿ���� ������ �� ������ ������ ���⿡ �߰�
        // ���� ��� Ÿ���� ��Ȱ��ȭ�ϴ� ���� ������ ������ �� �ֽ��ϴ�.

        // ���� Ÿ�� �� ����
        targetsHit++;
    }

    void ShowParticleEffect()
    {
        // ��ƼŬ ����Ʈ�� �����ϴ� ������ ���⿡ �߰�
        // ���� ��� Instantiate�� ����Ͽ� �������� ������ �� �ֽ��ϴ�.
        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
