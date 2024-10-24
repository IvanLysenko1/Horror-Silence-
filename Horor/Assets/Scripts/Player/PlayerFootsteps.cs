using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footstepSounds;      // Массив звуков шагов
    [SerializeField] private float _footstepDelay = 0.5f;      // Задержка между шагами
    [SerializeField] private float _walkSpeedThreshold = 0.2f; // Минимальная скорость для воспроизведения шагов

    private AudioSource _playerAudioSource;                    // Источник звука для шагов
    private Rigidbody _playerRigidbody;                        // Ссылка на Rigidbody персонажа

    private float _footstepTimer = 0f;
    private bool _isGrounded = true;                           // Переменная для отслеживания нахождения на земле

    private void Awake()
    {
        _playerAudioSource = GetComponent<AudioSource>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверяем, что персонаж на земле и его скорость больше порога
        if (_isGrounded && _playerRigidbody.velocity.magnitude > _walkSpeedThreshold)
        {
            _footstepTimer -= Time.deltaTime;

            // Воспроизводим звук шага, когда таймер истёк
            if (_footstepTimer <= 0f)
            {
                PlayFootstepSound();
                // Сбрасываем таймер
                _footstepTimer = _footstepDelay;  
            }
        }
        else
        {
            // Сбрасываем таймер, если персонаж не двигается
            _footstepTimer = 0f;  
        }
    }

    void PlayFootstepSound()
    {
        if (_footstepSounds.Length > 0)
        {
            // Выбираем случайный звук из массива
            int index = Random.Range(0, _footstepSounds.Length);  
            _playerAudioSource.clip = _footstepSounds[index];

            // Воспроизводим звук, если он ещё не играет
            if (!_playerAudioSource.isPlaying)
            {
                _playerAudioSource.Play();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
