using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Queue<Dialogue> dialogues;
    public static bool isInDialogue = false;
    public bool isTyping = false;
    //public GameObject nextButton;

    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public Image characterImage;
    public Image dialogueBoxImage;
    public TMP_Text name;

    public AudioClip typing;
    public AudioClip next;

    private void Awake()
    {
        dialogueBoxImage = dialogueBox.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogues = new Queue<Dialogue>();
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInDialogue == true && !isTyping)
            {
                DisplayNext();
            }
            // DisplayNext only available if dialogue box is active
        }

        /*if (isTyping)
        {
            nextButton.SetActive(false);
        }
        else
            nextButton.SetActive(true);*/
    }

    public void StartDialogue(Dialogue[] tempDialogues)
    {
        isInDialogue = true;
        dialogueBox.SetActive(true);
        dialogues.Clear();

        foreach (Dialogue dialogue in tempDialogues)
        {
            dialogues.Enqueue(dialogue);
        }
        DisplayNext();
    }

    public void DisplayNext()
    {
        Debug.Log("Next Dialogue");
        GetComponent<AudioSource>().pitch = 1;
        GetComponent<AudioSource>().volume = 1;
        GetComponent<AudioSource>().PlayOneShot(next);
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue currentDialogue = dialogues.Dequeue();

        //dialogueBox = currentDialogue.DialoguePrefab;
        name.text = currentDialogue.name;
        dialogueBoxImage.sprite = currentDialogue.DialoguePrefab.GetComponent<Image>().sprite;
        dialogueBox.transform.Find("DialogueText").GetComponent<RectTransform>().anchoredPosition = currentDialogue.DialoguePrefab.transform.Find("DialogueText").GetComponent<RectTransform>().anchoredPosition;
        characterImage.sprite = currentDialogue.characterImage;
        StartCoroutine(TypeSentence(currentDialogue.sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        bool isTags = false;

        foreach (char letter in sentence.ToCharArray())
        {
            if (letter == '<' || isTags)
            {
                isTags = true;
                dialogueText.text += letter;
                if (letter == '>')
                    isTags = false;
            }
            else
            {
                dialogueText.text += letter;
                typingRandomize();
                yield return null;
            }

        }
        isTyping = false;
    }

    public void EndDialogue()
    {
        isInDialogue = false;
        dialogueBox.SetActive(false);
        Debug.Log("End Dialogue");
    }

    void typingRandomize()
    {
        GetComponent<AudioSource>().pitch = (Random.Range(0.3f, 0.9f));
        GetComponent<AudioSource>().volume = 0.15f;
        GetComponent<AudioSource>().PlayOneShot(typing);
    }
}
