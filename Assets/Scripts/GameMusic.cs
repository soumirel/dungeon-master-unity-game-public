using System;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _audioSource;
    
    private float _savedTime;

    public void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _savedTime = 0f;
    }

    public void Start()
    {
        _audioSource.clip = _audioClip;
        
        _audioSource.loop = true;
        _audioSource.playOnAwake = false;

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void ContinueMusic()
    {
        _audioSource.time = _savedTime;
        PlayMusic();
    }
    

    public void StopMusic()
    {
        _savedTime = _audioSource.time;
        _audioSource.Stop();
    }
}