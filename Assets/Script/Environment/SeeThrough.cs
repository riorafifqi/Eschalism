using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    [SerializeField] private List<VanishingWall> inTheWayObjects;
    [SerializeField] private List<VanishingWall> transparentObjects;
    [SerializeField] private Transform character;
    private Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        inTheWayObjects = new List<VanishingWall>();
        transparentObjects = new List<VanishingWall>();
    }

    // Update is called once per frame
    void Update()
    {
        GetObjectsInTheWay();

        MakeObjectsSolid();
        MakeObjectsTransparent();

    }
    private void GetObjectsInTheWay()
    {
        inTheWayObjects.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(transform.position - character.position);

        Ray ray1_forward = new Ray(transform.position, character.position - transform.position);
        Ray ray1_backward = new Ray(character.position, transform.position - character.position);

        var hit1_forward = Physics.RaycastAll(ray1_forward, cameraPlayerDistance);
        var hit1_backward = Physics.RaycastAll(ray1_backward, cameraPlayerDistance);

        foreach (var hit in hit1_forward)
        {
            if (hit.collider.gameObject.TryGetComponent(out VanishingWall inTheWay))
            {
                if (!inTheWayObjects.Contains(inTheWay))
                {
                    inTheWayObjects.Add(inTheWay);
                }
            }
        }

        foreach (var hit in hit1_backward)
        {
            if (hit.collider.gameObject.TryGetComponent(out VanishingWall inTheWay))
            {
                if (!inTheWayObjects.Contains(inTheWay))
                {
                    inTheWayObjects.Add(inTheWay);
                }
            }
        }
    }

    private void MakeObjectsSolid()
    {
        for (int i = 0; i < transparentObjects.Count; i++)
        {
            VanishingWall wasInTheWay = transparentObjects[i];
            if (!inTheWayObjects.Contains(wasInTheWay))
            {
                wasInTheWay.ShowSolid();
                transparentObjects.Remove(wasInTheWay);
            }
        }
    }

    private void MakeObjectsTransparent()
    {
        for (int i = 0; i < inTheWayObjects.Count; i++)
        {
            VanishingWall wasInTheWay = inTheWayObjects[i];
            if (!transparentObjects.Contains(wasInTheWay))
            {
                wasInTheWay.ShowTransparent();
                transparentObjects.Add(wasInTheWay);
            }
        }
    }
}
