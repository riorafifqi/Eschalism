using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    // Update Inventory UI
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 20;

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("No space");
                return false;
            }
            else
            {
                items.Add(item);

                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove (Item item)
    {
        items.Remove(item);
        
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public bool have(Item item)
    {
        bool have = false;
        if(items.Contains(item))
        {
            have = true;
        }
        return have;
    }
}
