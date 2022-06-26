using UnityEngine;

public class CoatPickup : Interactable
{
    public Animator animator;
    public AudioClip cloth;
    public override void Awake()
    {
        base.Awake();
        animator.SetBool("InCoat", false);
    }
    public override void Interact()
    {
        base.Interact();
        if (canInteract)
        {
            animator.SetBool("InCoat", true);
            playSound();
            gameObject.SetActive(false);
        }
        else
        {
            trigger.TriggerDialogue();
        }
    }

    void playSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.pitch = Random.Range(0.7f, 1.3f);
        audio.PlayOneShot(cloth);
    }
}
