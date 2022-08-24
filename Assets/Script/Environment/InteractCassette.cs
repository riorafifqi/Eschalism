using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InteractCassette : InteractPuzzle
{
    public AudioSource casetteAudio;

    [SerializeField] Item casette;
    [SerializeField] AudioClip[] morseCodeClips;
    AudioClip usedClip;
    [SerializeField] AudioClip emptyClip;

    public override void Start()
    {
        base.Start();

        // randomize morseCodeClips & assign usedClip
        int randomIndex = Random.Range(0, morseCodeClips.Length - 1);
        usedClip = morseCodeClips[randomIndex];
    }

    public override void Interact()
    {
        base.Interact();
        if(isInPuzzleCamera)
        {
            // start audio
            // Check if cassette item is available
            if(Inventory.instance.have(casette))
            {
                // Play randomize clip
                StartCoroutine(PlayAudio(usedClip));
                casetteAudio.loop = false;
            }
            else
            {
                // play empty clip
                StartCoroutine(PlayAudio(emptyClip));
                casetteAudio.loop = true;
            }
        }
        else
        {
            //stop audio
            casetteAudio.Stop();
        }
    }

    private IEnumerator PlayAudio(AudioClip audioClip)
    {
        yield return new WaitForSeconds(2.0f);

        // Play clip
        casetteAudio.clip = audioClip;
        casetteAudio.Play();
    }
}
