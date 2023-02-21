using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioSource musicSource;

    //public void Awake()
    //{
    //    musicSource = GetComponent<AudioSource>();
    //    StartMenuMusic();
    //}
    public void StartLevelMusic()
    {
        musicSource.Stop();
        musicSource.PlayOneShot(levelMusic);
    }
    public void StartMenuMusic()
    {
        musicSource.Stop();
        musicSource.PlayOneShot(menuMusic);
    }
}
