using System.Collections;
using UnityEngine;

public class BallCol : MonoBehaviour
{
    // ���� ������ �� ȣ��� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� ���̸鼭 ���� Ȱ��ȭ ������ Ȯ��
        if (collision.gameObject.CompareTag("Pin") || collision.gameObject.activeSelf)
        {
            StartCoroutine(co_Col());

        }
    }

    IEnumerator co_Col()
    {
        yield return new WaitForSeconds(5.0f);
        // ���� ��Ȱ��ȭ(����)
        gameObject.SetActive(false);

    }
}
