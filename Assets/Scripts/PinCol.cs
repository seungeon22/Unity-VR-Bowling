using System.Collections;
using UnityEngine;

public class PinCol : MonoBehaviour
{
    // 공이 핀에 부딪혔을 때 호출될 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체가 공인지 확인
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
        {
            StartCoroutine(co_Col());
           
        }
    }

    IEnumerator co_Col()
    {
        yield return new WaitForSeconds(6.0f);
        // 공과 충돌한 핀을 비활성화(제거)
        gameObject.SetActive(false);
    }
}
