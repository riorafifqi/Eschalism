using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazel_listrik_manager : MonoBehaviour
{
    public GameObject[] ctekan;
    public GameObject[] lampu;
    public bool allIsFixed;

    private void Start()
    {
        ctekan = GameObject.FindGameObjectsWithTag("ctekan");
        lampu = GameObject.FindGameObjectsWithTag("lampu");
    }
    private void Update()
    {
        allIsFixed = true;
        for (int i = 0; i < ctekan.Length; i++)
        {
            if (!ctekan[i].GetComponent<pazel_listrik>().isActive)
            {
                allIsFixed = false;
                break;
            }
        }
        fixedLight(allIsFixed);
    }

    void fixedLight(bool s)
    {
        for (int i = 0; i < lampu.Length; i++)
        {
            lampu[i].GetComponent<flicker>().isFixed = s;
        }
    }
}
