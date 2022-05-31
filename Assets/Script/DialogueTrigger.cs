using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        if (!DialogueManager.isInDialogue)  // Only trigger if player currently not in dialogue
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
