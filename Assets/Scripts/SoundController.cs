using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip enterSound; // Ʈ���ſ� �������� �� ����� ����� Ŭ��
    public AudioClip exitSound; // Ʈ���Ÿ� �������� �� ����� ����� Ŭ��
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource ������Ʈ�� ã�ų� �߰��մϴ�.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������Ʈ�� Ʈ���ſ� �������� �� ������ ����
        if (other.CompareTag("Ball")) // Ʈ���ſ� ������ ������Ʈ�� "Ball" �±׸� ������ �ִ��� Ȯ��
        {
            // ���� ����� Ŭ�� ����
            StopAudio();

            // ���ο� ����� Ŭ�� ���
            PlayAudio(enterSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ������Ʈ�� Ʈ���Ÿ� �������� �� ������ ����
        if (other.CompareTag("Ball")) // Ʈ���Ÿ� ���������� ������Ʈ�� "Ball" �±׸� ������ �ִ��� Ȯ��
        {
            // ���� ��� ���� ����� Ŭ�� ����
            //StopAudio();

            // ���ο� ����� Ŭ�� ���
            PlayAudio(exitSound);
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        // ����� Ŭ���� �����Ǿ� ������ ���
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void StopAudio()
    {
        // ���� ��� ���� ����� Ŭ�� ����
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
