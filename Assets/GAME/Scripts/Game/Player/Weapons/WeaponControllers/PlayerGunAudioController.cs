using UnityEngine;

public class PlayerGunAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _gunShootAudio;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void PlayGunShootAudio()
    {
        _gameManager.AudioManager.PlayAudio(_gunShootAudio);
    }

    private void OnEnable()
    {
        PlayerGunShootManager.OnPlayerIsShooting += PlayGunShootAudio;
    }

    private void OnDisable()
    {
        PlayerGunShootManager.OnPlayerIsShooting -= PlayGunShootAudio;
    }
}
