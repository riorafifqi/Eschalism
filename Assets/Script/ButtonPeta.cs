using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPeta : MonoBehaviour
{
    public bool isPressed = false;
    private Vector3 def;
    private Vector3 tar;

    private void Start()
    {
        def = this.GetComponent<Transform>().position;
        tar = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
    }

    void Update()
    {
        this.GetComponent<Light>().enabled = isPressed;
        Press(isPressed);
    }

    void Press(bool pressed)
    {
        if(pressed)
        {
            transform.position = tar;
        } else
        {
            transform.position = def;
        }
    }
}
