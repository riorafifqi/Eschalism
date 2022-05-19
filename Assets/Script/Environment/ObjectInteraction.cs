using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : Interactable
{
    public bool isActive = false;
    public string desc;

    public override void Interact()
    {
        base.Interact();
        GameObject.Find("DialogManager").GetComponent<DIalogManager>().useDialog(desc);
    }
}

