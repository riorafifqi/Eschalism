using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kertas_pick : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameObject.Find("kertas").GetComponent<ItemClick>().click();
        Destroy(gameObject);
    }
}
