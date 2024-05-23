using UnityEngine;
using System.Collections;

public class PlayerController : SOUNDS
{


    public float gravity = 9.8f;
    public float jumpForce;
    public float Speed;

    public float RunSpeed;
    public Animator animator;

    public float Stamina = 100;
    public float MaxStamina = 100;
    public float RunCoast;
    public RectTransform valuerectTransform;
    public float ChargeRate;

    bool StamRun = true;

    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private CharacterController _characterController;
    private Coroutine _recharge;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        PlaySound(sounds[2]);
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
            if (StamRun == true && (Input.GetKey(KeyCode.LeftShift)))
            {
                _moveVector += transform.forward * RunSpeed;
                //Recharge();
                StmaUp();
                // сюда анимацию бега
                // звук бега
            }
            else
            {
                _moveVector += transform.forward;
                //runDirection = 1;
                //PlaySound(sounds[1]);
            }
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            if (StamRun == true && (Input.GetKey(KeyCode.LeftShift)))
            {
                    _moveVector += transform.right * RunSpeed;
                    //Recharge();
                    StmaUp();
                // сюда анимацию бега
            }
            else
            {
                _moveVector += transform.right;
            }
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.S) )
        {
            if (StamRun == true && (Input.GetKey(KeyCode.LeftShift)))
            {
                    _moveVector -= transform.forward * RunSpeed;
                    //Recharge();
                    StmaUp();
                // сюда анимацию бега
            }
            else
            {
                _moveVector -= transform.forward;
            }
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (StamRun == true && (Input.GetKey(KeyCode.LeftShift)))
            {
                    _moveVector -= transform.right * RunSpeed;
                    //Recharge();
                    StmaUp();
                // сюда анимацию бега
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
        if (Stamina < 0)
        {
            StamRun = false;
            Stamina = 0;
        }
        valuerectTransform.anchorMax = new Vector2(Stamina / MaxStamina, 1);
        Recharge();
    }
    private void Recharge()
    {
        if (_recharge != null) StopCoroutine(_recharge);
        _recharge = StartCoroutine(RechargeStamina());
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (Stamina < MaxStamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina)
            {
                StamRun = true;
                Stamina = MaxStamina;
            }

            valuerectTransform.anchorMax = new Vector2(Stamina / MaxStamina, 1);
            yield return new WaitForSeconds(.1f);
        }
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
