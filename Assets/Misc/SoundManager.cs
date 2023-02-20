using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Water,Music,Wind;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayWater()
    {
        audioSource.PlayOneShot(Water);
    }

    public void PlayMusic()
    {
        audioSource.PlayOneShot(Music);
        audioSource.loop=true;

    }

        public void PlayWind()
    {
        audioSource.PlayOneShot(Wind);

    }
}
