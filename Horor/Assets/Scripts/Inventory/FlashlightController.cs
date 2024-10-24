using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(AudioSource))]
public class FlashlightController : MonoBehaviour 
{
    [SerializeField] private GameObject _spotlight;
    [SerializeField] private AudioClip _buttonPressingSound;

    private PlayerInput _playerInput;
    private AudioSource _playerAudioSource;

    private bool isActive;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_playerInput.GetFlashlightToggleInput())
        {
            isActive = !isActive;
            _playerAudioSource.PlayOneShot(_buttonPressingSound);
        }

        _spotlight.SetActive(isActive);
    }
}
