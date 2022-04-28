using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pazel_rak : MonoBehaviour
{
    public GameObject bukudirak;
    public GameObject bukudilantai;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Destroy(bukudirak);
        bukudilantai.SetActive(true);
    }
}
