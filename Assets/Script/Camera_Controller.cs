using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public int rotation_ID;
    public float rotation_speed = 5.0f;
    private int newRotation;
    private Vector3 currentRotation;
    public bool isRotatable;
    float wait = 0;

    public Animator animator;
    private float newFace;
    private float currentFace;

    // Start is called before the first frame update
    void Start()
    {
        rotation_ID = 0;
        Debug.Log(rotation_ID);
        currentRotation = transform.eulerAngles;
        isRotatable = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isRotatable) // Rotate to right
        {
            int count = 0;

            // Increase rotation ID
            wait = 1f;
            rotation_ID++;
            if (rotation_ID > 3)
                rotation_ID = 0;
            Debug.Log(rotation_ID);
            newRotation = (int)currentRotation.y + 90;

            while (count != 2)
            {
                animator.SetFloat("IdleFace", animator.GetFloat("IdleFace") - 1.0f);
                if (animator.GetFloat("IdleFace") == -1)
                    animator.SetFloat("IdleFace", 7);
                count++;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) && isRotatable)     // Rotate to Left
        {
            int count = 0;

            // Decrease Rotation ID
            wait = 1f;
            rotation_ID--;
            if (rotation_ID < 0)
                rotation_ID = 3;
            Debug.Log(rotation_ID);
            newRotation = (int)currentRotation.y - 90;

            while (count != 2)
            {
                animator.SetFloat("IdleFace", animator.GetFloat("IdleFace") + 1.0f);
                if (animator.GetFloat("IdleFace") == 8)
                    animator.SetFloat("IdleFace", 0);
                count++;
            }

        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;
            isRotatable = false;
        }
        else
        {
            isRotatable = true;
            wait = 0;
        }

            currentRotation.y = Mathf.MoveTowards(currentRotation.y, newRotation, rotation_speed * Time.deltaTime);
        rotate();
        
    }

    void rotate()
    {
        transform.eulerAngles = currentRotation;
    }

    /*
    // Update is called once per frame
    void RotateWorld()
    {
        if (rotation_ID == 0) // Rotation y = 0
        {
            
        }
        else if (rotation_ID == 1) // Rotation y = -90
        {

        }
        else if (rotation_ID == 2) // Rotation y = -180
        {

        }
        else if (rotation_ID == 3) // Rotation y = -180
        {

        }*/

}
