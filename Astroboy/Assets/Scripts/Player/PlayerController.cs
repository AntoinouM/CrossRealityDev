using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed = 0.1f;
    
    private Animator animator;
    private CharacterController controller;

    private Vector3 moveBy;
    private Vector3 lookDir;
    private bool isMoving;
    private bool isJumpingOrFalling;
    
    public float turnSpeed = 400.0f;

    //private Vector2 lookDirection;
    private float xRotation;
    private float yRotation;
    
    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        print(inputValue);
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }
    
    void OnJump(InputValue input)
    {
        if (isJumpingOrFalling) return;

        GetComponent<Rigidbody>().AddForce(0, 8, 0, ForceMode.VelocityChange);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteMovement();
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

        isJumpingOrFalling = GetComponentInChildren<Rigidbody>().velocity.y < -.035 || GetComponentInChildren<Rigidbody>().velocity.y > 0.00001;

        animator.SetBool("walk", isMoving);
        animator.SetBool("jump", isJumpingOrFalling);

        if (!isMoving)
        {
            return;
        }

        float turn = moveBy.x;
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        //RotatePlayerFigure(moveBy);
        transform.Translate(Vector3.forward * moveBy.z * (speed * Time.deltaTime));
        //transform.Translate(moveBy * (speed * Time.deltaTime));
    }
    
    private void RotatePlayerFigure(Vector3 rotateVector)
    {
        rotateVector = Vector3.Normalize(rotateVector);
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        var rotationY = 90 * rotateVector.x;

        if (rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }
        transform.Rotate(0, rotationY, 0);
    }
    
    /*void OnLook(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        lookDir = new Vector3(inputValue.x, 0, inputValue.y);
    }*/
}
