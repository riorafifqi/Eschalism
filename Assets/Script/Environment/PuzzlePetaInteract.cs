using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePetaInteract : InteractPuzzle
{
    public DescriptionItem paper;

    public override void PuzzleDialogueTriggerer()
    {
        if (!Inventory.instance.have(paper))
        {
            trigger.TriggerDialogue();
        }

    }
}
