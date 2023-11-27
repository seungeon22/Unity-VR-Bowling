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
            // 2초 후에 SetActive를 true로 변경
            Invoke("ActivateParticle", 2.0f);
            isStrike = true;
        }
    }

    void ActivateParticle()
    {
        // 지연 호출 후에 파티클 활성화
        particle.SetActive(true);
    }
}
