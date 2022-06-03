using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Condition : MonoBehaviour
{
    public Animator animator;
    public Interactable[] interactables;
    //public DialogueTrigger[] triggers;
    public DialogueTrigger triggerFixLight;

    private void Awake()
    {
        animator.SetBool("InCoat", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pazel_listrik_manager.allIsFixed)
        {
            for(int i = 0; i < interactables.Length; i++ )
            {
                // Change all dialoguetrigger component to dialoguetrigger attached in this component
                interactables[i].trigger = gameObject.GetComponent<DialogueTrigger>();
                interactables[i].canInteract = false;
            }
        }
        else
        {
            // Change it back to default dialoguetrigger
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].trigger = interactables[i].gameObject.GetComponent<DialogueTrigger>();
                interactables[i].canInteract = true;
            }
        }
    }
}
