using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 correctPosition;
    public bool isInCorrectPos;

    // Start is called before the first frame update
    void Awake()
    {
        correctPosition = transform.position;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);
        if (targetPosition == correctPosition)
        {
            isInCorrectPos = true;
        }
        else
            isInCorrectPos = false;
    }
}
