using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject emptySpace;
    [SerializeField] GameObject emptyCover;
    Animator slidePuzzleBoxAnimation;

    [SerializeField] Camera camera;
    [SerializeField] SlidePuzzleTile[] tiles;
    
    int emptySpaceIndex = 8;
    bool isSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        slidePuzzleBoxAnimation = gameObject.GetComponent<Animator>();
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
            if (hit && hit.transform.name.Contains("Tile") && !isSolved)
            {
                //Debug.Log(Vector2.Distance(emptySpace.transform.position, hit.transform.position));
                if(Vector2.Distance(emptySpace.transform.position, hit.transform.position) < 0.12)
                {
                    SlidePuzzleTile thisTile = hit.transform.GetComponent<SlidePuzzleTile>();
                    
                    // change in the game
                    Vector3 lastEmptySpacePos = emptySpace.transform.position;
                    emptySpace.transform.position = thisTile.currentPosition;
                    thisTile.targetPosition = lastEmptySpacePos;

                    // change by the array
                    int tileIndex = GetIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }

        if(CheckPuzzlePosition())
        {
            Debug.Log("Box Opened");
            isSolved = true;

            // Disable all puzzle piece
            emptyCover.SetActive(false);    // cover behind all tiles
            emptySpace.SetActive(false);
            foreach(SlidePuzzleTile tile in tiles)
            {
                if (tile != null)
                {
                    tile.gameObject.SetActive(false);
                }
            }

            // Open the box;
            slidePuzzleBoxAnimation.SetBool("IsOpen", true);
        }
    }

    public void Shuffle()
    {
        int inversion;
        do
        {
            for (int i = 0; i < 8; i++)
            {
                // randomize tiles in game
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 8);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;

                // randomize tiles in array
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }
            inversion = GetInversion();
            Debug.Log("Shuffling");
        }
        while (inversion % 2 != 0);
    }

    public int GetIndex(SlidePuzzleTile puzzleTile)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if(tiles[i])
            {
                if (tiles[i] == puzzleTile)
                    return i;
            }
        }

        return -1;
    }

    private bool CheckPuzzlePosition()
    {
        foreach (SlidePuzzleTile tile in tiles)
        {
            if(tile != null)
                if (!tile.isInCorrectPos)
                    return false;
        }

        return true;
    }

    int GetInversion()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInversion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if(tiles[j] != null)
                {
                    if(tiles[i].number > tiles[j].number)
                    {
                        thisTileInversion++;
                    }
                }
            }
            inversionsSum += thisTileInversion;
        }
        return inversionsSum;
    }
}
