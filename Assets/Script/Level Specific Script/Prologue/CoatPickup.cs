using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoatPickup : Interactable
{
    public Animator animator;

    public override void Interact()
    {
        base.Interact();
        animator.SetBool("InCoat", true);
        Destroy(gameObject);
    }
}
