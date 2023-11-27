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
        rb.isKinematic = true; // ���� �߿� ���� �ùķ��̼��� ������� �ʵ��� ����
        lastControllerPosition = grabbingInteractor.transform.position;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        rb.isKinematic = false; // ������ �����Ǹ� �ٽ� ���� �ùķ��̼��� ����ϵ��� ����

        if (grabbingInteractor)
        {
            Vector3 controllerVelocity = (grabbingInteractor.transform.position - lastControllerPosition) / Time.fixedDeltaTime;
            rb.velocity = controllerVelocity * 2f; // �ӵ��� ����Ͽ� ����

            grabbingInteractor = null;
        }
    }
}
