using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Inventory/Item/Description Item")]
public class DescriptionItem : Item
{
    public string description;
    public override void Use()
    {
        base.Use();
        GameObject.Find("DialogManager").GetComponent<DIalogManager>().useDialog(this.description);
        Debug.Log("Description Effect Activate");
    }
}
