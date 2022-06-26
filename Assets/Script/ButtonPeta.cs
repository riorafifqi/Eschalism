using UnityEngine;

public class ButtonPeta : MonoBehaviour
{
    public bool isPressed = false;
    private Vector3 def;
    private Vector3 tar;

    public string Code;

    private void Start()
    {
        def = this.GetComponent<Transform>().position;
        tar = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
    }

    void Update()
    {
        this.GetComponent<Light>().enabled = isPressed;
        Press(isPressed);
    }

    void Press(bool pressed)
    {
        if (pressed)
        {
            transform.position = tar;
        }
        else
        {
            transform.position = def;
        }
    }

    private void OnMouseDown()
    {
        if (isPressed)
        {
            PetaPuzzleManager.petaPass = PetaPuzzleManager.petaPass.Remove(PetaPuzzleManager.petaPass.Length - 2, 2);
            isPressed = false;
        }
        else
        {
            PetaPuzzleManager.petaPass = PetaPuzzleManager.petaPass + Code;
            isPressed = true;
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = (Random.Range(0.6f, 1.3f));
        audioSource.Play();
    }
}
