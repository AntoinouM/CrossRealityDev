using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerInside : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveBy;
    private bool isMoving;
    private bool isJumpingOrFalling;

    private bool _footstepPlaying;

    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float turnSpeed = 400.0f;

    private float _lastFootstepTime = 0;

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }
    
    private void Awake()
    {
        GetComponent<PlayerInput>().actions["Interact"].Disable();
        _lastFootstepTime = Time.time;
    }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();

        _footstepPlaying = false;
    }
    
    void Update()
    {
        ExecuteMovement();
        RefillOxygen();
    }

    void ExecuteMovement()
    {

        if (moveBy == Vector3.zero || moveBy.z < 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        
        if (isMoving && !_footstepPlaying)
        {
            AkSoundEngine.PostEvent("Play_Footsteps_Inside", gameObject);
            _lastFootstepTime = Time.time;
            _footstepPlaying = true;
        }
        else if(isMoving && _footstepPlaying)
        {
            if (Time.time - _lastFootstepTime > 1300 / speed * Time.deltaTime)
            {
                _footstepPlaying = false;
            }
        }

        isJumpingOrFalling = rb.velocity.y < -.035 || rb.velocity.y > 0.00001;

        animator.SetBool("walk", isMoving);

        if (!isMoving)
        {
            return;
        }
        
        transform.Rotate(0, moveBy.x * turnSpeed * Time.deltaTime, 0); // comm
        transform.Translate(Vector3.forward * (moveBy.z * (speed * Time.deltaTime))); // comm
    }

    private void RefillOxygen()
    {
        if (DataStorage.instance.CurrOxygen < DataStorage.instance.MaxOxygen) DataStorage.instance.RefillOxygen();
    }
}
