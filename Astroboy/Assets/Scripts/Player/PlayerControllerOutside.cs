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
    [SerializeField] private GameObject playerArmature;
    


    private float _jumpHeight, _c1, _c3;
    private bool _isGrounded, _wasGroundedLastFrame, _didJump, _isMoving, _onSurface, _isFalling, _isJumping, _oxygenHalf, _isLanding, _currFrameLand, _lastFrameLand, _footstepPlaying, _playingLanding;
    private bool _jumpInit;
    private Rigidbody _rb;
    private Vector3 _moveBy, _moveClamped;
    private const float BufferGrounding = 0.1f;
    private ParticleSystem _trailPS;
    private RaycastHit _hit;
    private BoxCollider _bcPlayer;
    private Animator _animator;
    private SkinnedMeshRenderer _mrPlayer;
    private PlayerInput _inputs;

    private float _lastFootstepTime = 0;
    private float _lastLandingTime = 0;

    private float _jumpBuildupCurr;
    private float _jumpBuildup = 0.4f;

    private void Awake()
    {
        _trailPS = feet.GetComponent<ParticleSystem>();

        _lastFootstepTime = Time.time;
        _lastLandingTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        _bcPlayer = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
        _isMoving = false;
        _isGrounded = false;
        _mrPlayer = playerArmature.GetComponent<SkinnedMeshRenderer>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _oxygenHalf = DataStorage.instance.CurrOxygen <= DataStorage.instance.MaxOxygen / 2;
        _isLanding = false;
        _lastFrameLand = false;
        _currFrameLand = false;
        _footstepPlaying = false;
        _wasGroundedLastFrame = true;
        _playingLanding = false;
        _didJump = false;
        _inputs = GetComponent<PlayerInput>();
    }

    private void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void OnJump()
    {
        if (!_isGrounded || _isFalling || _isJumping) return;
        //_rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
        _animator.SetBool("jump", true);
        _animator.SetBool("landing", false);
        _didJump = true;
        
        _jumpInit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (test) DrawAxes();
        ExecuteMovement();
        _isFalling = _rb.velocity.y < -0.2; 
        _isJumping = _rb.velocity.y > 0.2;
        if (_isGrounded && _isMoving) if (_trailPS.isStopped) _trailPS.Play();
        if (!_isGrounded || !_isMoving) if (_trailPS.isPlaying) _trailPS.Stop();
        UseOxygen();
        _oxygenHalf = DataStorage.instance.CurrOxygen <= DataStorage.instance.MaxOxygen / 2;
        _wasGroundedLastFrame = _isGrounded;
    }

    void FixedUpdate()
    {
        if (_jumpInit) _jumpBuildupCurr += Time.deltaTime;
        if (_jumpBuildupCurr >= _jumpBuildup)
        {
            _rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
            _jumpInit = false;
            _jumpBuildupCurr = 0;
        }
    }

    private void DrawAxes()
    {
        Debug.DrawRay(transform.position, transform.up * 20, Color.magenta);
        Debug.DrawRay(transform.position, transform.forward * 20, Color.magenta);
        Debug.DrawRay(transform.position, Vector3.down * 20, Color.yellow);
    }

    private void ExecuteMovement()
    {
        Debug.Log(!_wasGroundedLastFrame && _isGrounded && _isJumping);
        _isMoving = _moveBy != Vector3.zero && _isGrounded;
        //_moveClamped = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveClamped = new Vector3(_moveBy.x, 0, _moveBy.z);

        if (!_wasGroundedLastFrame && _isGrounded && _didJump)
        {
            AkSoundEngine.PostEvent("Play_Landing", gameObject);
            _didJump = false; 
        }

        if (_wasGroundedLastFrame && !_isGrounded && !_didJump)
        {
            _animator.SetBool("fall", true);
        }
        
        switch (_oxygenHalf)
        {
            case false when _isMoving:
                _animator.SetBool("walk", true);
                break;
            case true when _isMoving:
                _animator.SetBool("walkTilted", true);
                break;
            default:
                _animator.SetBool("walkTilted", false);
                _animator.SetBool("walk", false);
                break;
        }

        
        RotatePlayer(_moveBy);
        MovePlayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Surface")) _isGrounded = true;
        _animator.SetBool("fall", false);
        _animator.SetBool("jump", false);
        _animator.SetBool("landing", true);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Surface")) _isGrounded = false;
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * (_moveClamped.z * (speed * Time.deltaTime)));
    }

    private void RotatePlayer(Vector3 rotationVector)
    {
        transform.Rotate(0, _moveClamped.x * rotationSpeed * Time.deltaTime, 0);
    }

    private void UseOxygen()
    {
        DataStorage.instance.LoseOxygen();
    }
}
