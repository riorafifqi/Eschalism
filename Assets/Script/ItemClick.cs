using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : ItemPickup
{
    private void OnMouseDown()
    {
        Click();
        Destroy(gameObject);
    }

    public void Click()
    {
        base.Interact();
    }
}
