using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Item/Level Key")]
public class Level_Key : Item
{
    public override void Use()
    {
        base.Use();
        // Key Effect Here
    }
}
