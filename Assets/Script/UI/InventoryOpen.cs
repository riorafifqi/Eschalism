using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryOpen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator inventoryAnimator;
    float inventoryTimer;
    public float inventoryDuration = 5f;
    public static bool mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        inventoryAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mouseOver)
        {
            if (inventoryTimer > 0)
            {
                inventoryTimer -= Time.deltaTime;
            }
            else
            {
                inventoryTimer = 0f;
            }

            if (inventoryTimer == 0)    // if countdown reach 0, close inventory
            {
                inventoryAnimator.SetBool("IsOpen", false);
            }
        }
        else
        {
            inventoryTimer = inventoryDuration;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Pointer Enter");
        inventoryAnimator.SetBool("IsOpen", true);
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Pointer Exit");
        // timer start
        mouseOver = false;
    }
}
