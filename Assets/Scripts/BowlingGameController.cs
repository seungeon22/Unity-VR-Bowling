using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowlingGameController : MonoBehaviour
{
    public GameObject bowlingBallPrefab; // ���� �� ������
    public Transform ballSpawnPoint; // ���� ������ ��ġ
    public float ballSpeed = 10f; // ���� �߻� �ӵ�

    private XRGrabInteractable interactable; // XR Interaction Toolkit�� Grab Interactable

    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        // �̺�Ʈ ������ �߰�
        interactable.onActivate.AddListener(OnActivate);
    }

    void OnActivate(XRBaseInteractor interactor)
    {
        FireBowlingBall();
    }

    void FireBowlingBall()
    {
        // ���� �� ����
        GameObject ball = Instantiate(bowlingBallPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);

        // ���� ���� ���� �߻�
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.velocity = ballSpawnPoint.forward * ballSpeed;
    }
}
