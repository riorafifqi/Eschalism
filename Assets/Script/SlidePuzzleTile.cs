using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleTile : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 correctPosition;
    public Vector3 currentPosition;
    public int number;

    public bool isInCorrectPos;

    // Start is called before the first frame update
    void Awake()
    {
        correctPosition = transform.position;
        targetPosition = correctPosition;
    }

    private void Start()
    {
        currentPosition = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(currentPosition, targetPosition, 0.05f);
        currentPosition = targetPosition;

        if (targetPosition == correctPosition)
        {
            isInCorrectPos = true;
        }
        else
            isInCorrectPos = false;
    }
}
