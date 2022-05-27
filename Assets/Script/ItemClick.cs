using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : ItemPickup
{
    private void OnMouseDown()
    {
        Click();
    }

    public void Click()
    {
        base.Interact();
    }
}
