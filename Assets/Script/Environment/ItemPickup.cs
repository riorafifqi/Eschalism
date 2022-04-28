using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    public void Pickup()
    {
        // Add to inventory
        Debug.Log("Picking Up " + item.name);
        bool wasPicked = Inventory.instance.Add(item);
        // Destroy Game Object
        if (wasPicked)
            Destroy(gameObject);
    }
}
