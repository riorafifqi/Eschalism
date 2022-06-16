using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoatPickup : Interactable
{
    public Animator animator;

    public override void Awake()
    {
        base.Awake();
        animator.SetBool("InCoat", false);
    }
    public override void Interact()
    {
        base.Interact();
        if (canInteract)
        {
            animator.SetBool("InCoat", true);
            gameObject.SetActive(false);
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }
}
