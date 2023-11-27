using UnityEngine;

public class StrikeController : MonoBehaviour
{
    public GameObject particleEffectPrefab; // 파티클 이펙트 프리팹을 연결할 변수
    public string targetTag = "Pin"; // 타겟 오브젝트의 태그

    private int targetsHit = 0; // 맞춘 타겟 수

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그가 지정한 태그와 일치하는지 확인
        if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
        {
            // 타겟을 맞췄을 때 실행할 동작
            HitTarget();

            // 맞춘 타겟 수가 10개인지 확인
            if (targetsHit >= 10)
            {
                // 10개를 맞추면 파티클 이펙트를 생성
                ShowParticleEffect();
            }
        }
    }

    void HitTarget()
    {
        // 타겟을 맞췄을 때 실행할 동작을 여기에 추가
        // 예를 들면 타겟을 비활성화하는 등의 동작을 수행할 수 있습니다.

        // 맞춘 타겟 수 증가
        targetsHit++;
    }

    void ShowParticleEffect()
    {
        // 파티클 이펙트를 생성하는 동작을 여기에 추가
        // 예를 들면 Instantiate를 사용하여 프리팹을 생성할 수 있습니다.
        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
