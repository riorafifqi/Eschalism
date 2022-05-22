using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLockedDoor : Interactable
{
    public bool unlocked = false;
    public Item key;
    public LevelLoaderScript levelLoader;

    private DialogueTrigger trigger;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        if(Inventory.instance.have(key))
        {
            Debug.Log("buka");
            unlocked = true;
            levelLoader.LoadNextLevel();

        } else 
        {
            trigger.TriggerDialogue();
        }
    }
}
