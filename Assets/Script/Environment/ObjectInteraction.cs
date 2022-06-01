using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : Interactable
{
    public bool isActive = false;
    public string desc;


    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        trigger.TriggerDialogue();
        if (canInteract)
            base.Interact();
        //GameObject.Find("DialogManager").GetComponent<DIalogManager>().useDialog(desc);
    }
}

