using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip enterSound; // 트리거에 진입했을 때 재생할 오디오 클립
    public AudioClip exitSound; // 트리거를 빠져나갈 때 재생할 오디오 클립
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource 컴포넌트를 찾거나 추가합니다.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 오브젝트가 트리거에 진입했을 때 실행할 동작
        if (other.CompareTag("Ball")) // 트리거에 진입한 오브젝트가 "Ball" 태그를 가지고 있는지 확인
        {
            // 기존 오디오 클립 중지
            StopAudio();

            // 새로운 오디오 클립 재생
            PlayAudio(enterSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 오브젝트가 트리거를 빠져나갈 때 실행할 동작
        if (other.CompareTag("Ball")) // 트리거를 빠져나가는 오브젝트가 "Ball" 태그를 가지고 있는지 확인
        {
            // 현재 재생 중인 오디오 클립 중지
            //StopAudio();

            // 새로운 오디오 클립 재생
            PlayAudio(exitSound);
        }
    }

    private void PlayAudio(AudioClip clip)
    {
        // 오디오 클립이 지정되어 있으면 재생
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void StopAudio()
    {
        // 현재 재생 중인 오디오 클립 중지
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
