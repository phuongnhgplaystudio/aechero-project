using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake()
    {
        instance = this;
    }
    public void PlayThisSoundOneShot(string nameOfSound, float volumeMultiplier)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeMultiplier;
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + nameOfSound, typeof(AudioClip)));
    }

    public void StopThisSound()
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
