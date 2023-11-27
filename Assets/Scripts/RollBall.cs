using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RollBall : MonoBehaviour
{
    public float rollForce = 10f; // 볼링공을 밀어주는 힘
    public float rotationSpeed = 100f; // 회전 속도
    private XRGrabInteractable interactable;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<XRGrabInteractable>();
        interactable.onSelectEntered.AddListener(OnSelectEnter);
        interactable.onSelectExited.AddListener(OnSelectExit);
    }

    void OnSelectEnter(XRBaseInteractor interactor)
    {
        Roll();
    }

    void OnSelectExit(XRBaseInteractor interactor)
    {
        // 트리거에서 손을 놓았을 때 추가적인 동작이 필요하다면 이곳에 작성
    }

    void Roll()
    {
        // 볼링공에 힘을 가해 굴리는 로직
        Vector3 rollDirection = transform.forward; // 공이 바라보는 방향으로 굴릴 수 있도록 설정
        rb.AddForce(rollDirection * rollForce, ForceMode.Impulse);

        // 볼링공의 각속도를 설정하여 회전하게 만듭니다.
        Vector3 rotationAxis = Vector3.up; // Y축 주위로 회전
        rb.angularVelocity = rotationAxis * rotationSpeed;
    }
}
