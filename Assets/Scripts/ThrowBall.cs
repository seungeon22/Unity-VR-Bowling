using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowBall : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        if (grabInteractable == null || rb == null)
        {
            Debug.LogError("XRGrabInteractable or Rigidbody component is missing.");
        }

        // 물체를 놓았을 때 이벤트에 함수 등록
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        // 공을 던지기
        Throw();
    }

    void Throw()
    {
        // 앞으로 향하는 방향으로 힘을 가해서 물체를 던집니다.
        Vector3 throwDirection = transform.forward;
        float throwForce = 100f; // 던지는 힘의 크기 조절

        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    }
}
