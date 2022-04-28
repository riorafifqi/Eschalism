using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerinteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactableDistance = 2f;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    public void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitsomething = false;
        if(Physics.Raycast(ray,out hit, interactableDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                hitsomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.P))
                {
                    interactable.Interact();
                }
            }
        }
        interactionUI.SetActive(hitsomething);
    }
}
