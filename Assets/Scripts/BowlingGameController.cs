using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingGameController : MonoBehaviour
{
    public GameObject bowlingBallPrefab; // 볼링 공 프리팹
    public Transform ballSpawnPoint; // 공이 생성될 위치
    public float ballSpeed = 10f; // 공의 발사 속도

    private XRGrabInteractable interactable; // XR Interaction Toolkit의 Grab Interactable

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        // 이벤트 리스너 추가
        interactable.onActivate.AddListener(OnActivate);
    }

    void OnActivate(XRBaseInteractor interactor)
    {
        FireBowlingBall();
    }

    void FireBowlingBall()
    {
        // 볼링 공 생성
        GameObject ball = Instantiate(bowlingBallPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);

        // 공에 힘을 가해 발사
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.velocity = ballSpawnPoint.forward * ballSpeed;
    }
}
