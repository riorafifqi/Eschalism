using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
    public Rigidbody player_Rb;
    public float moveSpeed;
    public Camera_Controller world_Rotation;
    public Animator anim;

    private Vector2 moveInput;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.y = Input.GetAxis("Vertical");
        anim.SetFloat("Vertical", moveInput.y);
        moveInput.x = Input.GetAxis("Horizontal");
        anim.SetFloat("Horizontal", moveInput.x);
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
        moveInput.Normalize();

        //player_Rb.velocity = new Vector3(moveInput.x * moveSpeed, player_Rb.velocity.y, moveInput.y * moveSpeed);
        Player_Movement_Adjustment();
    }

    void Player_Movement_Adjustment()
    {
        if (world_Rotation.rotation_ID == 0) // Rotation y = 0
        {
            player_Rb.velocity = new Vector3(moveInput.x * moveSpeed, player_Rb.velocity.y, moveInput.y * moveSpeed);
        }
        else if (world_Rotation.rotation_ID == 1) // Rotation y = -90
        {
            player_Rb.velocity = new Vector3(moveInput.y * moveSpeed, player_Rb.velocity.y, -moveInput.x * moveSpeed);
        }
        else if (world_Rotation.rotation_ID == 2) // Rotation y = -180
        {
            player_Rb.velocity = new Vector3(-moveInput.x * moveSpeed, player_Rb.velocity.y, -moveInput.y * moveSpeed);
        }
        else if (world_Rotation.rotation_ID == 3) // Rotation y = -180
        {
            player_Rb.velocity = new Vector3(-moveInput.y * moveSpeed, player_Rb.velocity.y, moveInput.x * moveSpeed);
        }
        
        
        /*if (!moving.isMoving())
        {
            if (world_Rotation.rotation_ID == 0) // Rotation y = 0
            {
                player_Rb.velocity = new Vector3(moveInput.x * moveSpeed, player_Rb.velocity.y, moveInput.y * moveSpeed);
            }
            else if (world_Rotation.rotation_ID == 1) // Rotation y = -90
            {
                player_Rb.velocity = new Vector3(moveInput.y * moveSpeed, player_Rb.velocity.y, -moveInput.x * moveSpeed);
            }
            else if (world_Rotation.rotation_ID == 2) // Rotation y = -180
            {
                player_Rb.velocity = new Vector3(-moveInput.x * moveSpeed, player_Rb.velocity.y, -moveInput.y * moveSpeed);
            }
            else if (world_Rotation.rotation_ID == 3) // Rotation y = -180
            {
                player_Rb.velocity = new Vector3(-moveInput.y * moveSpeed, player_Rb.velocity.y, moveInput.x * moveSpeed);
            }
        }
        else if (moving.isMoving())
        {

        }*/
    }
}
