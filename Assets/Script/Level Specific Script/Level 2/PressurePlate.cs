using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Rigidbody block;    // to trigger pressure plate
    public Rigidbody player;   // player

    public GameObject cellBar;  // opened when trigger

    public float smoothTime = 0.4f;
    public float speed = 10f;

    public bool isStepped = true;

    private Vector3 targetPos = new Vector3(0f, -0f, 0.012f); // cell bar target pos when opened
    private Vector3 ogPos = new Vector3(0f, -0f, -0.013f); // cell bar original pos if closed
    private Vector3 offset = new Vector3(1f, 1f, 1f);
    private Vector3 currentTarget;
    Vector3 velocity;

    private void Awake()
    {
        currentTarget = cellBar.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        // pressure plate can only be triggered by player and block
        if (other.attachedRigidbody == block || other.attachedRigidbody == player)
        {
            if (!isStepped)
            {
                currentTarget.y *= -1;
                isStepped = true;
            }
            StartCoroutine(slideCellBar(cellBar.transform.position, currentTarget));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentTarget.y *= -1;
        isStepped = false;
        StartCoroutine(slideCellBar(cellBar.transform.position, currentTarget));
    }

    IEnumerator slideCellBar(Vector3 source, Vector3 target)
    {
        while (source != target)
        {
            cellBar.transform.position = Vector3.SmoothDamp(cellBar.transform.position, currentTarget, ref velocity, smoothTime, speed);
            yield return null;
        }
    }
}
