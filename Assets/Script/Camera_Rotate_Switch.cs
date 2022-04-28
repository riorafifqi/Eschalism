using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate_Switch : MonoBehaviour
{
    [SerializeField] private GameObject[] cam;
    public static int rotation_ID = 0;
    public bool isRotateable = true;
    public float wait = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isRotateable)
        {
            wait = 1f;
            rotation_ID++;
            if (rotation_ID > 3)
                rotation_ID = 0;
        }

        if (Input.GetKeyDown(KeyCode.Q) && isRotateable)
        {
            wait = 1f;
            rotation_ID--;
            if (rotation_ID < 0)
                rotation_ID = 3;
        }

        if (wait > 0)
        {
            wait -= Time.deltaTime;
            isRotateable = false;
        }
        else
        {
            isRotateable = true;
            wait = 0;
        }

        for (int i = 0; i < cam.Length; i++)
        {
            if (rotation_ID == i)
            {
                cam[i].SetActive(true);
            }
            else
            {
                cam[i].SetActive(false);
            }
        }
    }
}
