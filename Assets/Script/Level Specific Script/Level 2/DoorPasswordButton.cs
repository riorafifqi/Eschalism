using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPasswordButton : MonoBehaviour
{
    public string code;
    DoorPasswordManager doorPassword;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        doorPassword = GameObject.Find("GameManager").GetComponent<DoorPasswordManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed");
        doorPassword.passwordOnScreen = doorPassword.passwordOnScreen + code;
        audioSource.Play();
    }
}
