using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float Speed;

    public float RunSpeed;
    public Animator animator;

    public Image StaminBar;
    public float Stamina, MaxStamina;
    public float RunCoast;

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

        var runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector += transform.forward * RunSpeed;
                StmaUp();
            }
            else
            {
                _moveVector += transform.forward;
            }
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector += transform.right * RunSpeed;
                StmaUp();
            }
            else
            {
                _moveVector += transform.right;
            }
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector -= transform.forward * RunSpeed;
                StmaUp();
            }
            else
            {
                _moveVector -= transform.forward;
            }
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveVector -= transform.right * RunSpeed;
                StmaUp();
            }
            else
            {
                _moveVector -= transform.right;
            }
            runDirection = 4;
            
        }
        animator.SetInteger("Run direction", runDirection);
    }

    private void StmaUp()
    {
        Stamina -= RunCoast * Time.deltaTime;
        if (Stamina < 0) Stamina = 0;
        StaminBar.fillAmount = Stamina / MaxStamina;
    }

    private void JumpUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetTrigger("jump");
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
