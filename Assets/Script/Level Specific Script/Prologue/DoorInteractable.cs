using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    public LevelLoaderScript levelLoader;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        if(canInteract)
        {
            base.Interact();
            transform.eulerAngles = new Vector3(0, 45, 0);
            levelLoader.LoadNextLevel();
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }
}
