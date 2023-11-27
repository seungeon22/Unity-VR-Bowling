using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndInstantiate : MonoBehaviour
{

    public GameObject controller;
    public GameObject objectToInstantiate; // 새로 Instantiate할 오브젝트
    private bool isGrabbed = false;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            // XRGrabInteractable 컴포넌트가 없다면 추가
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }

        // 오브젝트를 잡았을 때의 이벤트에 함수 등록
        grabInteractable.onSelectEntered.AddListener(OnGrab);

        // 오브젝트를 놓았을 때의 이벤트에 함수 등록
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        // 오브젝트를 잡음
        isGrabbed = true;
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        // 오브젝트를 놓음
        isGrabbed = false;
    }
    
    void Update()
    {
        
        // Oculus Touch 컨트롤러의 그랩 트리거 버튼을 클릭했을 때
        if (isGrabbed && Input.GetButtonDown("Fire1")) // "Fire1"은 헤드셋이나 컨트롤러 버튼에 대한 입력 이름입니다. 수정이 필요할 수 있습니다.
        {
            Debug.Log("ddd");
            Instantiate(objectToInstantiate, controller.transform);
            // 상태 변경
            isGrabbed = false;
        }
    }
    
}
