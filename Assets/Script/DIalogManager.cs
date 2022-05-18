using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DIalogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>(); 
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start Dialogue");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue");
    }




    /*public bool active = false;
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
    }*/
}
