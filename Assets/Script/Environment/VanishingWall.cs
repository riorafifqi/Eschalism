using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingWall : MonoBehaviour
{
    [SerializeField] private Material solidMaterial;
    [SerializeField] private Material transparentMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        ShowSolid();
    }

    public void ShowTransparent()
    {
        gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
    }

    public void ShowSolid()
    {
        gameObject.GetComponent<MeshRenderer>().material = solidMaterial;
    }
}
