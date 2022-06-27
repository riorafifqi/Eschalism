using UnityEngine;

public class InteractLockedDoor : Interactable
{
    public bool unlocked = false;
    public Item key;
    public LevelLoaderScript levelLoader;

    public AudioClip[] locked;
    public AudioClip[] opened;

    public override void Start()
    {
        base.Start();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public override void Interact()
    {
        if (Inventory.instance.have(key))
        {
            Debug.Log("buka");
            unlocked = true;
            levelLoader.LoadNextLevel();
        }
        else
        {
            trigger.TriggerDialogue();
        }
        playSound(unlocked);
    }

    void playSound(bool isunlocked)
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        AudioClip clip;
        if (!isunlocked)
            clip = locked[Random.Range(0, opened.Length)];
        else
            clip = opened[Random.Range(0, locked.Length)];
        audio.pitch = Random.Range(0.7f, 1.2f);
        audio.PlayOneShot(clip);
    }
}
