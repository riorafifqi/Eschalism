using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public bool isFlickering = false;
    public bool isFixed = false;
    public float timeDelay;
    public float minVal = 1f;
    public float maxVal = 2f;

    private void Update()
    {
        if(!isFixed)
        {
            if (!isFlickering)
            {
                StartCoroutine(Flickering());
            }
        }
    }

    IEnumerator Flickering()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(minVal, maxVal);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(minVal, maxVal);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
