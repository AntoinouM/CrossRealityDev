using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerOutside : MonoBehaviour
{
    [SerializeField] private bool test;
    [Space(10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float jumpForce = 24f;

    private float _gravity;
    private bool _isMoving, _isGrounded;
    private Rigidbody _rb;
    private Vector3 _moveBy, _moveClamped;
    private Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gravity = DataStorage.instance.Gravity;
        _isMoving = false;
        _isGrounded = false;
    }

    private void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void OnJump()
    {
        print("jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (test) DrawAxes();
        ExecuteMovement();
    }

    private void DrawAxes()
    {
        Debug.DrawRay(transform.position, transform.up * 20, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward * 20, Color.magenta);
    }

    private void ExecuteMovement()
    {
        _isMoving = _moveBy != Vector3.zero;
        _isGrounded = _rb.velocity.y > -.035 || _rb.velocity.y < 0.00001;
        _moveClamped = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        print(_moveClamped);
        
        if(_isGrounded){
            _moveDirection = transform.forward * (_moveClamped.z * speed);
        }
        
        RotatePlayer();
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * (_moveClamped.z * (speed * Time.deltaTime)));
    }

    private void RotatePlayer()
    {
        transform.Rotate(0, _moveClamped.x * rotationSpeed * Time.deltaTime, 0);
        // add slerp to rotation?
    }
}
