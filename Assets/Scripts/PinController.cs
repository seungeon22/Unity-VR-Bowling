using System.Collections;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public GameObject nowPin;
    public GameObject pinPrefab;  // Pin�� ������� ������
    public Transform respawnPosition;  // ������� ��ġ
    int cmt = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            cmt++;

            if (cmt == 2)
            {
                StartCoroutine(co_Enter());
                cmt = 0;
            }

        }
        Debug.Log("10");
    }

    IEnumerator co_Enter()
    {
        Destroy(nowPin, 5.0f);

        yield return new WaitForSeconds(6.0f);

        Debug.Log("20");

        RespawnPin();
        yield return null;
    }

    // "Pin" ������Ʈ�� Ư�� ��ġ���� ������ϴ� �޼���
    void RespawnPin()
    {

        // �������� �̿��Ͽ� ���ο� "Pin" ������Ʈ�� ������ ��ġ�� ����
        GameObject newPin = Instantiate(pinPrefab, respawnPosition.position, respawnPosition.rotation);

        nowPin = newPin;

        // ������ "Pin" ������Ʈ�� Ȱ��ȭ
        newPin.SetActive(true);
        Debug.Log("30");
    }
}
