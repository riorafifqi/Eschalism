using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : ItemPickup
{
    private void OnMouseDown()
    {
        click();
    }

    public void click()
    {
        base.Pickup();
    }
}
