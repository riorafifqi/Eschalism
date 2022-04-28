using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPetaOnPov : MonoBehaviour
{
    public GameObject tombolPeta;
    public string Code;
    private bool isPressed = false;
    private void OnMouseDown()
    {
        if(isPressed)
        {
            PetaPuzzleManager.petaPass = PetaPuzzleManager.petaPass.Remove(PetaPuzzleManager.petaPass.Length - 2, 2);
            isPressed = false;
        } else
        {
            PetaPuzzleManager.petaPass = PetaPuzzleManager.petaPass + Code;
            isPressed = true;
        }
        tombolPeta.GetComponent<ButtonPeta>().isPressed = isPressed;
    }
}
