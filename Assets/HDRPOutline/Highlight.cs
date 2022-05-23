using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Highlight : MonoBehaviour
{
    private Renderer[] renderers;
    private Material highlightMaterial;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        highlightMaterial = Instantiate(Resources.Load<Material>(@"Material/HighlightMaterial"));
    }
    
    void OnEnable()
    {
        foreach (var renderer in renderers)
        {

            // Append outline shaders
            var materials = renderer.sharedMaterials.ToList();

            materials.Add(highlightMaterial);

            renderer.materials = materials.ToArray();
        }
    }

    void OnDisable()
    {
        foreach (var renderer in renderers)
        {

            // Remove outline shaders
            var materials = renderer.sharedMaterials.ToList();

            materials.Remove(highlightMaterial);

            renderer.materials = materials.ToArray();
        }
    }
}
