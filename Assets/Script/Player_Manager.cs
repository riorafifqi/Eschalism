using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    Animator animator;
    public float health = 3.0f;

    private void Awake()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Health", health);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Health", health);
    }
}
