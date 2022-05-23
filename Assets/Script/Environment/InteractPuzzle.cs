using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPuzzle : Interactable
{
    public bool isActive = false;
    public GameObject obj;
    public GameObject cam;

    // Update is called once per frame
    public override void Update()
    {

        if (Vector3.Distance(player.transform.position, objectCenter) < radius)
        {
            // Insert "if near, highlight object" code here
            highlight.enabled = !isActive;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(!isActive)
                {
                    base.Interact();
                    isActive = true;
                } else
                {
                    isActive = false;
                }
                    
            }
        } else
        {
            highlight.enabled = false;
            isActive = false;
        }

        obj.SetActive(isActive);
        cam.SetActive(isActive);
    }
}
