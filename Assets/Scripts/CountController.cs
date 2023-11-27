using UnityEngine;

public class CountController : MonoBehaviour
{
    public int count = 0;
    public GameObject particle;
    bool isStrike = false;

    void Update()
    {
        if (count >= 10 && !isStrike)
        {
            // 2�� �Ŀ� SetActive�� true�� ����
            Invoke("ActivateParticle", 2.0f);
            isStrike = true;
        }
    }

    void ActivateParticle()
    {
        // ���� ȣ�� �Ŀ� ��ƼŬ Ȱ��ȭ
        particle.SetActive(true);
    }
}
