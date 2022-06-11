using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_MoveObject_2D : Interactable
{
    static bool isMoving = false;
    public string objectOrientation;
    public float localObjectDifX;   // To get the difference of player and object position in x axis
    public float localObjectDifZ;   // To get the difference of player and object position in z axis
    public FixedJoint fixedJoint;
    public Camera_Controller camera_c;

    Animator animator;

    public override void Awake()
    {
        base.Awake();
        fixedJoint = gameObject.AddComponent<FixedJoint>(); // Add fixedJoint programmitacilay
        camera_c = GameObject.Find("Player").GetComponent<Camera_Controller>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public override void Update()
    {
        localObjectDifX = Mathf.Abs(objectLocalPos.x);      // u askin' where the objectlocalPos is?
        localObjectDifZ = Mathf.Abs(objectLocalPos.z);      // it's in the Interactable script

        objectLocalPos = player.transform.InverseTransformPoint(transform.position);    // get object position local to player
        if (Vector3.Distance(player.transform.position, transform.position) < radius)
        {
            // Insert "if near, highlight object" code here
            highlight.enabled = true;
            if (Input.GetKeyDown(KeyCode.F) && !DialogueManager.isInDialogue)
            {
                Interact();
            }
        }
        else
        {
            highlight.enabled = false;
        }

        if (Vector3.Distance(player.transform.position, transform.position) > radius)   // Object unmovable when not in range
        {
            object_rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (!isMoving)
        {
            fixedJoint.connectedBody = player.GetComponent<Rigidbody>();    // this line connect object and player
            player.GetComponent<Rigidbody>().drag = 3f;
            isMoving = true;
            animator.SetBool("isPushing", true);
            camera_c.enabled = false;

            // if-else below to get object position based on player
            // so we can give player a right sprite animation
            if (localObjectDifX > localObjectDifZ)  // Object is in x axis
            {
                //object_rb.constraints = ~RigidbodyConstraints.FreezePositionX;  // now object & player can only move in z axis
                if (objectLocalPos.x < 0)
                {
                    Debug.Log("Object on Left");
                    objectOrientation = "Left";
                    animator.SetFloat("ObjectOrientation", 4);
                    // animation idle push left here
                }

                // object on the right of player
                else if (objectLocalPos.x > 0)
                {
                    Debug.Log("Object on Right");
                    // animation idle push right here
                    objectOrientation = "Right";
                    animator.SetFloat("ObjectOrientation", 1);
                    // move based on z or x

                }
            }
            else if (localObjectDifX < localObjectDifZ) // Object is in z axis
            {
                //object_rb.constraints = ~RigidbodyConstraints.FreezePositionZ;  // now object & player can only move in x axis
                // object on the front
                if (objectLocalPos.z < 0)
                {
                    Debug.Log("Object on Front");
                    objectOrientation = "Front";
                    animator.SetFloat("ObjectOrientation", 2);
                    // animation idle push front here
                    // move based on z or x

                }

                // object on the back
                else if (objectLocalPos.z > 0)
                {
                    Debug.Log("Object on Back");
                    objectOrientation = "Back";
                    // animation idle push back here
                    animator.SetFloat("ObjectOrientation", 0);
                    // move based on z or x

                }
            } // End of if-else
            LockAxis();
        } else if (isMoving) { 
            fixedJoint.connectedBody = null;
            isMoving = false;
            animator.SetBool("isPushing", false);
            camera_c.enabled = true;
            objectOrientation = null;
            player.GetComponent<Rigidbody>().drag = 0;
        }
    }

    private void LockAxis()
    {
        if (camera_c.rotation_ID == 0 || camera_c.rotation_ID == 2)
        {
            if (objectOrientation == "Left" || objectOrientation == "Right")
            {
                object_rb.constraints = ~RigidbodyConstraints.FreezePositionX;  // now object & player can only move in z axis
            }
            else if (objectOrientation == "Front" || objectOrientation == "Back")
            {
                object_rb.constraints = ~RigidbodyConstraints.FreezePositionZ;  // now object & player can only move in x axis
            }
        }
        else
        {
            if (objectOrientation == "Left" || objectOrientation == "Right")
            {
                object_rb.constraints = ~RigidbodyConstraints.FreezePositionZ;  // now object & player can only move in x axis
            }
            else if (objectOrientation == "Front" || objectOrientation == "Back")
            {
                object_rb.constraints = ~RigidbodyConstraints.FreezePositionX;  // now object & player can only move in z axis
            }
        }
    }

    // this shit is trash, but might be useful later
    /*public bool isMoving()
    {
        Math.Round(player.transform.position.z, 1);
        if (Mathf.RoundToInt(player.transform.position.x) > Mathf.RoundToInt(transform.position.x))
        {
            objectOrientation = "Left";
        }

        else if (Mathf.RoundToInt(player.transform.position.x) < Mathf.RoundToInt(transform.position.x))
        {
            objectOrientation = "Right";
        }
        else if (Mathf.RoundToInt(player.transform.position.z) < Mathf.RoundToInt(transform.position.z))
        {
            objectOrientation = "Up";
        }
        else if (Mathf.RoundToInt(player.transform.position.z) > Mathf.RoundToInt(transform.position.z))
        {
            objectOrientation = "Down";
        }
        return true;
    }*/
}
