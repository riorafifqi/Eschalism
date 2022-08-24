using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InteractPuzzle : Interactable
{
    public bool isActive = true;
    public GameObject obj;
    public GameObject cam;

    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera puzzleCamera;
    protected bool isInPuzzleCamera = false;

    public override void Awake()
    {
        base.Awake();
        playerCamera = GameObject.Find("Cinemachine Cam 1").GetComponent<CinemachineVirtualCamera>();
    }

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Update()
    {
        if (Vector3.Distance(player.transform.position, objectCenter) < radius)
        {
            // Insert "if near, highlight object" code here
            if(!isInPuzzleCamera)
                highlight.enabled = !isActive;
            if (Input.GetKeyDown(KeyCode.F) && !DialogueManager.isInDialogue)
            {
                if(!isInPuzzleCamera)
                    PuzzleDialogueTriggerer();

                if (canInteract)
                    Interact();
            }
        } else
        {
            highlight.enabled = false;
            //isActive = false;
        }

        /*obj.SetActive(isActive);
        cam.SetActive(isActive);*/
    }

    public override void Interact()
    {
        base.Interact();
        /*if (!isActive)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }*/

        if(isInPuzzleCamera)
        {
            puzzleCamera.Priority = 0;  // switch back to player camera
            playerCamera.Priority = 1;
            highlight.enabled = true;

            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player_Movement_Script>().enabled = true;
        }
        else
        {
            highlight.enabled = false;  
            puzzleCamera.Priority = 1;  // switch to puzzle camera
            playerCamera.Priority = 0;

            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Player_Movement_Script>().enabled = false;
        }
        isInPuzzleCamera = !isInPuzzleCamera;
    }

    public virtual void PuzzleDialogueTriggerer()
    {
        trigger.TriggerDialogue();
    }
}
