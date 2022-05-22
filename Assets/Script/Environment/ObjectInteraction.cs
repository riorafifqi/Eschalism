using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : Interactable
{
    public bool isActive = false;
    public string desc;

    public DialogueTrigger trigger;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        base.Interact();
        //GameObject.Find("DialogManager").GetComponent<DIalogManager>().useDialog(desc);
        trigger.TriggerDialogue();
    }
}

