using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : ItemPickup
{
    private void OnMouseDown()
    {
        Click();
        Destroy(gameObject);

        if (trigger)
            trigger.TriggerDialogue();
    }

    public void Click()
    {
        base.Pickup();
    }
}
