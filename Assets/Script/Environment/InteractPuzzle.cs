using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPuzzle : Interactable
{
    public bool isActive = true;
    public GameObject obj;
    public GameObject cam;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Vector3.Distance(player.transform.position, objectCenter) < radius)
        {
            // Insert "if near, highlight object" code here
            highlight.enabled = !isActive;
            if (Input.GetKeyDown(KeyCode.F) && !DialogueManager.isInDialogue)
            {
                PuzzleDialogueTriggerer();
                if (canInteract)
                    Interact();
            }
        } else
        {
            highlight.enabled = false;
            isActive = false;
        }

        obj.SetActive(isActive);
        cam.SetActive(isActive);
    }

    public override void Interact()
    {
        base.Interact();
        if (!isActive)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public virtual void PuzzleDialogueTriggerer()
    {
        trigger.TriggerDialogue();
    }
}
