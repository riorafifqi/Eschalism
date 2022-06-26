using UnityEngine;

public class DoorInteractable : Interactable
{
    public LevelLoaderScript levelLoader;
    public AudioClip[] openDoor;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        if (canInteract)
        {
            base.Interact();
            transform.eulerAngles = new Vector3(0, 45, 0);
            playSound();
            levelLoader.LoadNextLevel();
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }

    void playSound()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        AudioClip clip = openDoor[Random.Range(0, openDoor.Length)];
        audio.pitch = Random.Range(0.7f, 1.2f);
        audio.PlayOneShot(clip);
    }
}
