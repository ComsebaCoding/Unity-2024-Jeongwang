using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    AudioSource myAudioSource;
    public AudioClip hit1Sound;
    public AudioClip hit2Sound;
    public AudioClip outSound;
    public AudioClip powerUpSound;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void PlayHit1Sound()
    {
        myAudioSource.PlayOneShot(hit1Sound);
    }
    public void PlayHit2Sound()
    {
        myAudioSource.PlayOneShot(hit2Sound);
    }
    public void PlayOutSound()
    {
        myAudioSource.PlayOneShot(outSound);
    }
    public void PlayPowerUpSound()
    {
        myAudioSource.PlayOneShot(powerUpSound);
    }
}