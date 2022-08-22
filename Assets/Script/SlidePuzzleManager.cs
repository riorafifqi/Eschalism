using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject emptySpace;
    [SerializeField] Camera camera;
    [SerializeField] SlidePuzzleTile[] tiles;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit && hit.transform.name.Contains("Tile"))
            {
                if(Vector2.Distance(emptySpace.transform.position, hit.transform.position) < 0.1)
                {
                    SlidePuzzleTile thisTile = hit.transform.GetComponent<SlidePuzzleTile>();
                    
                    Vector3 lastEmptySpacePos = emptySpace.transform.position;
                    emptySpace.transform.position = hit.transform.position;
                    thisTile.targetPosition = lastEmptySpacePos;
                }
            }
        }

        if(CheckPuzzlePosition())
        {
            Debug.Log("Box Opened");
            // Open box
        }
    }

    public void Shuffle()
    {
        for(int i = 0; i < 12; i++)
        {
            var lastPos = tiles[i].targetPosition;
            int randomIndex = Random.Range(0, 14);
            tiles[i].targetPosition = tiles[randomIndex].targetPosition;
            tiles[randomIndex].targetPosition = lastPos;
        }
    }

    private bool CheckPuzzlePosition()
    {
        foreach (SlidePuzzleTile tile in tiles)
        {
            if (!tile.isInCorrectPos)
                return false;
        }

        return true;
    }
}
