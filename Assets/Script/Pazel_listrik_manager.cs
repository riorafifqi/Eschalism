using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazel_listrik_manager : MonoBehaviour
{
    public GameObject[] ctekan;
    public GameObject[] lampu;
    public static bool allIsFixed;
    public int triggerOnce = 1;

    public DialogueTrigger trigger;

    private void Start()
    {
        trigger = GameObject.Find("SecondPhase").GetComponent<DialogueTrigger>();
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

        if(allIsFixed)
        {
            if (triggerOnce == 1)
            {
                trigger.TriggerDialogue();
                triggerOnce--;
            }


        }
    }

    void fixedLight(bool s)
    {
        for (int i = 0; i < lampu.Length; i++)
        {
            lampu[i].GetComponent<flicker>().isFixed = s;
        }
    }
}
