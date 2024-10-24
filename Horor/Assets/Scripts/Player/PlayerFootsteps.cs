using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioClip[] _footstepSounds;      // ������ ������ �����
    [SerializeField] private float _footstepDelay = 0.5f;      // �������� ����� ������
    [SerializeField] private float _walkSpeedThreshold = 0.2f; // ����������� �������� ��� ��������������� �����

    private AudioSource _playerAudioSource;                    // �������� ����� ��� �����
    private Rigidbody _playerRigidbody;                        // ������ �� Rigidbody ���������

    private float _footstepTimer = 0f;
    private bool _isGrounded = true;                           // ���������� ��� ������������ ���������� �� �����

    private void Awake()
    {
        _playerAudioSource = GetComponent<AudioSource>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���������, ��� �������� �� ����� � ��� �������� ������ ������
        if (_isGrounded && _playerRigidbody.velocity.magnitude > _walkSpeedThreshold)
        {
            _footstepTimer -= Time.deltaTime;

            // ������������� ���� ����, ����� ������ ����
            if (_footstepTimer <= 0f)
            {
                PlayFootstepSound();
                // ���������� ������
                _footstepTimer = _footstepDelay;  
            }
        }
        else
        {
            // ���������� ������, ���� �������� �� ���������
            _footstepTimer = 0f;  
        }
    }

    void PlayFootstepSound()
    {
        if (_footstepSounds.Length > 0)
        {
            // �������� ��������� ���� �� �������
            int index = Random.Range(0, _footstepSounds.Length);  
            _playerAudioSource.clip = _footstepSounds[index];

            // ������������� ����, ���� �� ��� �� ������
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
