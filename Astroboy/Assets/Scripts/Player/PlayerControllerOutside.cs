using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerControllerOutside : MonoBehaviour
{
    [SerializeField] private bool test;
    [Space(10)]
    [SerializeField] private Transform feet;
    [Space(10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField][Range(1, 10)] private float jumpForce = 9f;

    private float _jumpHeight, _c1, _c3;
    private bool _isGrounded, _isMoving, _onSurface, _lastFrameUp, _currFrameUp;
    private Rigidbody _rb;
    private Vector3 _moveBy, _moveClamped;
    private const float BufferGrounding = 0.05f;
    private ParticleSystem _trailPS;
    private EnemyHeadStompCheck _surfaceCheck;
    private RaycastHit _hit;
    
    private Animator _animator;

    public bool IsGrounded => _isGrounded;
    public bool IsMoving => _isMoving;

    private void Awake()
    {
        _trailPS = feet.GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _surfaceCheck = feet.GetComponent<EnemyHeadStompCheck>();
        _isMoving = false;
        _isGrounded = false;
        
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void OnJump()
    {
        if (!_isGrounded) return;
        _rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update()
    {
        if (test) DrawAxes();
        ExecuteMovement();
        if (_isGrounded && _isMoving) if (_trailPS.isStopped) _trailPS.Play();
        if (!_isGrounded || !_isMoving) if (_trailPS.isPlaying) _trailPS.Stop();
    }

    private void DrawAxes()
    {
        Debug.DrawRay(transform.position, transform.up * 20, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward * 20, Color.magenta);
        Debug.DrawRay(transform.position, Vector3.down * 20, Color.yellow);
    }

    private void ExecuteMovement()
    {
        _isMoving = _moveBy != Vector3.zero;
        CheckGroundPosition();
        _moveClamped = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //print(_moveClamped);
        
        _animator.SetBool("walk", _isMoving);
        _animator.SetBool("jump", !_isGrounded);
        
        RotatePlayer(_moveBy);
        MovePlayer();
    }

    private void CheckGroundPosition()
    {
        Physics.Raycast(feet.position, transform.up * -1, out _hit);
        _isGrounded = _hit.distance <= BufferGrounding;
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * (_moveClamped.z * (speed * Time.deltaTime)));
    }

    private void RotatePlayer(Vector3 rotationVector)
    {
        transform.Rotate(0, _moveClamped.x * rotationSpeed * Time.deltaTime, 0);
    }
}
