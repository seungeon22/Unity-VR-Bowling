using UnityEngine;

public class ResetController : MonoBehaviour
{
    public GameObject ballPrefab; // 프리팹으로 사용할 공 프리팹
    public Transform spawnPoint;  // 재생성할 위치
    public float forceMagnitude = 10f; // 힘의 크기
    public float torqueMagnitude = 5f; // 회전의 크기

    private void OnTriggerEnter(Collider other)
    {
        
        
        // 만약 충돌한 오브젝트의 태그가 "Ball"라면
        if (other.CompareTag("Ball"))
        {
            // 기존 공을 제거
            Destroy(other);
            Debug.Log("2");
            // 5초 뒤에 공을 생성하는 함수 호출
            Invoke("RespawnBall", 5f);
            Debug.Log("3");
        }
    }

    private void RespawnBall()
    {
        Debug.Log("4");
        // 공을 새로운 위치에 생성
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        // 공에 힘을 가하고 회전을 부여
        Rigidbody rb = newBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 힘을 가함
        rb.AddForce(newBall.transform.forward * forceMagnitude, ForceMode.Impulse);

        // 회전을 부여
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * torqueMagnitude;
        rb.AddTorque(randomTorque, ForceMode.Impulse);

        // 공이 Z축 방향으로 굴러가도록 추가 회전
        Vector3 rollTorque = new Vector3(0f, 0f, 1f) * torqueMagnitude;
        rb.AddTorque(rollTorque, ForceMode.Impulse);
    }
}
