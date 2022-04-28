using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollController : MonoBehaviour
{
    public Collider playerCollider;
    public Collider[] limbCollider;
    public Animator playerAnimator;
    public bool ragdollActive = false;
    
    void Update()
    {
        playerCollider.enabled = !ragdollActive;
        playerAnimator.enabled = !ragdollActive;
        for (int i = 0; i < limbCollider.Length; i++)
        {
            limbCollider[i].enabled = ragdollActive;
        }
    }
}
