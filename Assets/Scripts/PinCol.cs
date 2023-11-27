using System.Collections;
using UnityEngine;

public class PinCol : MonoBehaviour
{
    // ���� �ɿ� �ε����� �� ȣ��� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� ������ Ȯ��
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
        {
            StartCoroutine(co_Col());
           
        }
    }

    IEnumerator co_Col()
    {
        yield return new WaitForSeconds(6.0f);
        // ���� �浹�� ���� ��Ȱ��ȭ(����)
        gameObject.SetActive(false);
    }
}
