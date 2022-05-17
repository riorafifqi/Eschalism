using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : Interactable
{
    public bool isActive = false;
    public string desc;

    public Dialogue dialogue;
    private DIalogManager dialogManager;

    private void Start()
    {
        dialogManager = FindObjectOfType<DIalogManager>();
    }

    public override void Interact()
    {
        base.Interact();
        dialogManager.StartDialogue(dialogue);
    }

    public override void Update()
    {
        base.Update();
        if (Input.anyKeyDown)
        {
            dialogManager.NextSentence();
        }
        
    }

}

