using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public static bool isInDialogue = false;
    public bool isTyping = false;
    public GameObject nextButton;

    public TMP_Text dialogueText;
    public GameObject dialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInDialogue == true && !isTyping)
                FindObjectOfType<DialogueManager>().DisplayNext();
            // DisplayNext only available if dialogue box is active
        }

        if (isTyping)
        {
            nextButton.SetActive(false);
        }
        else
            nextButton.SetActive(true);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isInDialogue = true;
        dialogueBox.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }

    public void DisplayNext()
    {
        Debug.Log("Next Dialogue");
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        isInDialogue = false;
        dialogueBox.SetActive(false);
        Debug.Log("End Dialogue");
    }
}
