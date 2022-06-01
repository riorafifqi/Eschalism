using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueCondition : MonoBehaviour
{
    public Animator animator;
    public DialogueTrigger answerThePhoneDialogue;
    public DialogueTrigger getTheCoatDialogue;

    public Interactable[] interactablesPhone;
    public Interactable[] interactablesCoat;


    // Update is called once per frame
    void Update()
    {
        ConditionOne();
    }

    public void ConditionOne()
    {
        // If player haven't answer/receive the phone before interacting with the other
        if (!PhoneInteractable.isAnswered)
        {
            for (int i = 0; i < interactablesPhone.Length; i++)
            {
                // Change all dialoguetrigger component to dialoguetrigger attached in this component
                interactablesPhone[i].trigger = answerThePhoneDialogue;
                interactablesPhone[i].canInteract = false;
            }
        }
        else
        {
            // Change it back to default dialoguetrigger
            for (int i = 0; i < interactablesPhone.Length; i++)
            {
                interactablesPhone[i].trigger = interactablesPhone[i].gameObject.GetComponent<DialogueTrigger>();
                interactablesPhone[i].canInteract = true;
            }

            // Start Second Condition
            ConditionTwo();
        }
    }

    public void ConditionTwo()
    {
        // If player doesn't use the coat before interacting with door
        if (!animator.GetBool("InCoat"))
        {
            for (int i = 0; i < interactablesCoat.Length; i++)
            {
                // Change all dialoguetrigger component to dialoguetrigger attached in this component
                interactablesCoat[i].trigger = getTheCoatDialogue;
                interactablesCoat[i].canInteract = false;
            }
        }
        else
        {
            // Change it back to default dialoguetrigger
            for (int i = 0; i < interactablesCoat.Length; i++)
            {
                interactablesCoat[i].trigger = interactablesCoat[i].gameObject.GetComponent<DialogueTrigger>();
                interactablesCoat[i].canInteract = true;
            }
        }
    }
}
