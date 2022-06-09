using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Rigidbody block;    // to trigger pressure plate
    public Rigidbody player;   // player

    public GameObject cellBar;  // opened when trigger

    private void OnTriggerStay(Collider other)
    {
        // pressure plate can only be triggered by player and block
        if (other.attachedRigidbody == block || other.attachedRigidbody == player)
        {
            cellBar.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cellBar.SetActive(true);
    }
}
