using System.Collections;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public GameObject nowPin;
    public GameObject pinPrefab;  // Pin을 재생성할 프리팹
    public Transform respawnPosition;  // 재생성할 위치
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

    // "Pin" 오브젝트를 특정 위치에서 재생성하는 메서드
    void RespawnPin()
    {

        // 프리팹을 이용하여 새로운 "Pin" 오브젝트를 지정된 위치에 생성
        GameObject newPin = Instantiate(pinPrefab, respawnPosition.position, respawnPosition.rotation);

        nowPin = newPin;

        // 생성된 "Pin" 오브젝트를 활성화
        newPin.SetActive(true);
        Debug.Log("30");
    }
}
