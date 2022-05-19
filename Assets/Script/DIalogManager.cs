using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DIalogManager : MonoBehaviour
{
    public bool active = false;
    public GameObject dialogBox;
    public GameObject text;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            active = false;
        }

        dialogBox.SetActive(active);
    }

    public void useDialog(string isi)
    {
        text.GetComponent<TMPro.TextMeshProUGUI>().SetText(isi);
        active = true;
    }
}
