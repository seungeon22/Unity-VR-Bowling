using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectLauncher : XRGrabInteractable
{
    private XRBaseInteractor grabbingInteractor;
    private Rigidbody rb;
    private Vector3 lastControllerPosition;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        grabbingInteractor = args.interactor;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // 선택 중에 물리 시뮬레이션을 사용하지 않도록 설정
        lastControllerPosition = grabbingInteractor.transform.position;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        rb.isKinematic = false; // 선택이 해제되면 다시 물리 시뮬레이션을 사용하도록 설정

        if (grabbingInteractor)
        {
            Vector3 controllerVelocity = (grabbingInteractor.transform.position - lastControllerPosition) / Time.fixedDeltaTime;
            rb.velocity = controllerVelocity * 2f; // 속도를 계산하여 설정

            grabbingInteractor = null;
        }
    }
}
