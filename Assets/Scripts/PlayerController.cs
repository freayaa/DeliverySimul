using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float Speed;

    public float RunSpeed;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector += transform.forward * RunSpeed;
            }
            else
            {
                _moveVector += transform.forward;
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector += transform.right * RunSpeed;
            }
            else
            {
                _moveVector += transform.right;
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector -= transform.forward * RunSpeed;
            }
            else
            {
                _moveVector -= transform.forward;
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector -= transform.right * RunSpeed;
            }
            else
            {
                _moveVector -= transform.right;
            }

        }
    }
    private void JumpUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;

        }
    }

    private void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        //Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall if on the ground
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
