using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteractable : ObjectInteraction
{
    static public bool isAnswered = false;
    public GameObject phoneLight;
    public AudioSource phoneRing;

    public override void Awake()
    {
        base.Awake();
        phoneRing = gameObject.GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();
        isAnswered = true;
        phoneLight.SetActive(false);
        phoneRing.enabled = false;
    }
}
