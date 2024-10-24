using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class SoundTrigger : MonoBehaviour 
{
    [SerializeField] private bool _oneShoot = false;
    [SerializeField] private List<AudioClip> _sounds;

    private AudioSource _audioSource;
    private bool _active = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(_active)
        {
            if (other.tag == "Player")
            {
                PlayRandomSound();
                if (_oneShoot)
                {
                    _active = false;
                }
            }
        }      
    }

    void PlayRandomSound()
    {
        int randomNumber = Random.Range(0, _sounds.Count);
        _audioSource.clip = _sounds[randomNumber];
        _audioSource.Play();
    }

}
