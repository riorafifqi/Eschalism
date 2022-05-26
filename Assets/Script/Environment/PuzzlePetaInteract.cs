using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePetaInteract : InteractPuzzle
{
    public Item paper;
    public DialogueTrigger trigger;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();
    }

    public void Condition()
    {
        if (!Inventory.instance.have(paper))
        {
            trigger.TriggerDialogue();
        }
    }
}
