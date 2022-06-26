using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    protected float outlineWidth = 1f;
    protected GameObject player;
    protected Highlight highlight;
    public Vector3 objectLocalPos;
    protected Rigidbody object_rb;
    protected Vector3 objectCenter;

    public DialogueTrigger trigger;
    public bool canInteract = true;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.GetComponent<Collider>().bounds.center, radius);
    }

    public virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        object_rb = gameObject.GetComponent<Rigidbody>();
        highlight = gameObject.AddComponent<Highlight>();
    }

    public virtual void Start()
    {
        objectCenter = gameObject.GetComponent<Collider>().bounds.center;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        objectLocalPos = player.transform.InverseTransformPoint(objectCenter);    // get object position local to player
        if (Vector3.Distance(player.transform.position, objectCenter) < radius)
        {
            // Insert "if near, highlight object" code here
            highlight.enabled = true;
            if (Input.GetKeyDown(KeyCode.F) && !DialogueManager.isInDialogue)
            {
                Interact();
            }
        }
        else
        {
            highlight.enabled = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + this.name);
        highlight.enabled = false;
    }

}
