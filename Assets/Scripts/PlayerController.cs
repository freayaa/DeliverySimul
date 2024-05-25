using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : SOUNDS
{
    public Slider slidervolumemusic;
    public float volume;
    public AudioSource Audio;

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
    private int _runDirection;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        PlaySound(sounds[2]);
    }

    private void Update()
    {
        MovementUpdate();
        JumpUpdate();
        //MusicVol();
    }
    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        _runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            if (StamRun == true && (Input.GetKey(KeyCode.LeftShift)))
            {
                _moveVector += transform.forward * RunSpeed;
                StmaUp();
                _runDirection = 6;
            }
            else
            {
                _moveVector += transform.forward;
                _runDirection = 1;
            }
        }
        if (Input.GetKey(KeyCode.D) )
        {

            _moveVector += transform.right;
            
            _runDirection = 3;
        }
        if (Input.GetKey(KeyCode.S) )
        {

            _moveVector -= transform.forward;
            
            _runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {

            _moveVector -= transform.right;
            
            _runDirection = 4;
        }
        animator.SetInteger("Run direction", _runDirection);
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
            if (Stamina > 30)
            {
                StamRun = true;
            }
            if(Stamina > MaxStamina)
            {
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
            _runDirection = 0;
            _runDirection = 5;
            _fallVelocity = -jumpForce;
            animator.SetInteger("Run direction", _runDirection);
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
    public void MusicVol()
    {
        volume = slidervolumemusic.value;
        Audio.volume = volume;
    }
}
