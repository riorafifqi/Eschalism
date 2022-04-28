using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollission : MonoBehaviour
{
    public float initialPitch = 1;
    public float pitchMultiplier = 0.5f;
    public float initialVolume = 0.3f;
    public float volumeMultiplier = 10;
    private void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio.playOnAwake)
        {
            playSound(10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0)
        {
            playSound(collision.relativeVelocity.magnitude);
        } else
        {
            Debug.Log("Too slow to play sound " + collision.relativeVelocity.magnitude);
        }
    }
    void playSound(float magnitude)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = initialVolume / volumeMultiplier * magnitude;
        audio.pitch = (Random.Range(initialPitch - pitchMultiplier, initialPitch + pitchMultiplier));
        audio.Play();
    }
}
