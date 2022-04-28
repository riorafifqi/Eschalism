using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Script : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    public float angle = 0;
    private Vector3 _input;

    private void Update()
    {
        int id = Camera_Rotate_Switch.rotation_ID;
        switch(id)
        {
            case 0:
                angle = 0;
                break;
            case 1:
                angle = -90;
                break;
            case 2:
                angle = 180;
                break;
            case 3:
                angle = 90;
                break;
        }
        gatherInput();
        look();

    }

    private void FixedUpdate()
    {
        Move();
    }

    void gatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, angle, 0));

            var skewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _speed * Time.deltaTime);
    }
}
