using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        base.Interact();
        Pickup();

        if(trigger)
            trigger.TriggerDialogue();
    }

    public void Pickup()
    {
        // Add to inventory
        Debug.Log("Picking Up " + item.name);
        bool wasPicked = Inventory.instance.Add(item);
        // Destroy Game Object
        //Destroy(gameObject);
        if (wasPicked)
            Destroy(gameObject);
    }
}
