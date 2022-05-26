using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour
{
    public DialogueTrigger trigger;
    public bool isTriggered;
    public bool playerStop;

    public Player_Movement_Script playerMovement;
    public Animator playerAnimator;

    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
        playerMovement = GameObject.Find("Player").GetComponent<Player_Movement_Script>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            trigger.TriggerDialogue();
            isTriggered = true;
        }
    }

    private void Update()
    {
        if (playerStop)
        {
            if (DialogueManager.isInDialogue)
            {
                playerMovement.enabled = false;
                playerAnimator.SetFloat("Speed", 0);
            }
            else
                playerMovement.enabled = true;
        }
    }
}

