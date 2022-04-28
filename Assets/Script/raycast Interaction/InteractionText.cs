using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionText : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "mengambil Info";
    }
    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    

    
}
