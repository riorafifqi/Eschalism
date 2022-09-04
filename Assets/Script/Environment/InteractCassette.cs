using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InteractCassette : InteractPuzzle
{
    public AudioSource casetteAudio;

    [SerializeField] Item casette;
    [SerializeField] CassetteScript[] morseCodeClips;
    AudioClip usedClip;
    [SerializeField] AudioClip emptyClip;
    DoorPasswordManager doorPassword;

    public override void Awake()
    {
        base.Awake();
        doorPassword = GameObject.Find("GameManager").GetComponent<DoorPasswordManager>();
    }

    public override void Start()
    {
        base.Start();

        // randomize morseCodeClips & assign usedClip
        int randomIndex = Random.Range(0, morseCodeClips.Length - 1);
        
        usedClip = morseCodeClips[randomIndex].morseClip;
        doorPassword.password = morseCodeClips[randomIndex].morseCode;
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
