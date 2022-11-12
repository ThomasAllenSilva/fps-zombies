using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _mainAudioSource;

    private void Awake()
    {
        _mainAudioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioToPlay)
    {
        _mainAudioSource.PlayOneShot(audioToPlay);
    }
}
