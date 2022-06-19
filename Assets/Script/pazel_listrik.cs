using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pazel_listrik : MonoBehaviour
{
    public bool isActive = false;
    public bool isBroken = false;
    public GameObject ctekan;
    public GameObject indikator;
    public float x, y;
    public AudioClip on;
    public AudioClip off;
    private Vector3 rot;
    private Vector3 pos;
    private Transform ctek;

    private void Start()
    {
        ctek = ctekan.transform;
        rot = transform.localEulerAngles;
        pos = transform.localPosition;
    }

    void OnMouseDown()
    {
        Debug.Log("Object Pressed");
        AudioSource audio = GetComponent<AudioSource>();
        audio.pitch = (Random.Range(1 - 0.2f, 1 + 0.2f));
        if (!isBroken)
        {
            if (!isActive)
            {
                transform.Rotate(new Vector3(76,0,0));
                transform.localPosition = new Vector3(x, y, transform.localPosition.z);
                isActive = true;
                audio.PlayOneShot(on, 0.2f);
            }
            else
            {
                transform.localEulerAngles = rot;
                transform.localPosition = pos;
                isActive = false;
                audio.PlayOneShot(off, 0.2f);
            }
        }
        indikator.GetComponent<Light>().enabled = isActive;
    }
}
