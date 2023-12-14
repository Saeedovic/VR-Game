using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioClip laughSound;

    private AudioSource backgroundMusicSource;
    private AudioSource laughSoundSource;

    public float backgroundMusicVolume = 0.5f;
    public float laughSoundVolume = 1.0f;

    public float timeBetweenLaughs = 10f; 
    private float nextLaughTime;

    void Start()
    {
        
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        laughSoundSource = gameObject.AddComponent<AudioSource>();

       
        backgroundMusicSource.clip = backgroundMusic;
        laughSoundSource.clip = laughSound;

        
        backgroundMusicSource.volume = backgroundMusicVolume;
        laughSoundSource.volume = laughSoundVolume;

        
        PlayLaughSound();

        
        Invoke("StartBackgroundMusic", laughSound.length);
    }

    void Update()
    {
        
        if (Time.time > nextLaughTime)
        {
            PlayLaughSound();

            
            nextLaughTime = Time.time + timeBetweenLaughs;
        }
    }

    void PlayLaughSound()
    {
        if (laughSound != null)
        {
            laughSoundSource.PlayOneShot(laughSound);
        }
    }

    void StartBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }
}