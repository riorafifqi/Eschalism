using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLockedDoor : Interactable
{
    public bool unlocked = false;
    public Item key;
    public LevelLoaderScript levelLoader;

    public override void Interact()
    {
        if(Inventory.instance.have(key))
        {
            Debug.Log("buka");
            unlocked = true;
            levelLoader.LoadNextLevel();

        } else
        {
            Debug.Log("Locked");
            //GameObject.Find("DialogManager").GetComponent<DIalogManager>().useDialog("Its Locked");
        }
    }
}
