using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    protected float outlineWidth = 1f;
    protected GameObject player;
    protected Outline outline;
    public Vector3 objectLocalPos;
    protected Rigidbody object_rb;
    protected Vector3 objectCenter;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.GetComponent<Collider>().bounds.center, radius);
    }

    public virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        outline = gameObject.AddComponent<Outline>();
        object_rb = gameObject.GetComponent<Rigidbody>();
    }

    public virtual void Start()
    {
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = outlineWidth;
        objectCenter = gameObject.GetComponent<Collider>().bounds.center;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        objectLocalPos = player.transform.InverseTransformPoint(objectCenter);    // get object position local to player
        if (Vector3.Distance(player.transform.position, objectCenter) < radius)
        {
            // Insert "if near, highlight object" code here
            outline.enabled = true;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Interact();                    
            }
        } else
        {
            outline.enabled = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + this.name);
        outline.enabled = false;
    }

}
