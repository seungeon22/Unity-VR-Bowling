using System.Collections;
using UnityEngine;

public class BallCol : MonoBehaviour
{
    // 볼이 던져질 때 호출될 함수
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체가 핀이면서 핀이 활성화 중인지 확인
        if (collision.gameObject.CompareTag("Pin") || collision.gameObject.activeSelf)
        {
            StartCoroutine(co_Col());

        }
    }

    IEnumerator co_Col()
    {
        yield return new WaitForSeconds(5.0f);
        // 핀을 비활성화(제거)
        gameObject.SetActive(false);

    }
}
