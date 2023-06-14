using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovmentComponent : MonoBehaviour
{
    [SerializeField] private bool test;
    [Space(10)]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField][Range(1, 3)] private float jumpHeightRatio = 3f;
    [SerializeField][Range(0, 2)] private float jumpTime = 0.5f;
    [SerializeField] private Transform playerFigure;

    private float _gravity, _jumpHeight, _c1, _c3;
    private bool _isMoving, _isGrounded;
    private Rigidbody _rb;
    private Vector3 _moveBy, _moveClamped;
    private Vector3 _moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        // easing const
        _c1 = 1.70158f;
        _c3 = _c1 + 1;
        
        _rb = GetComponent<Rigidbody>();
        _gravity = DataStorage.instance.Gravity;
        _isMoving = false;
        _isGrounded = true;
        _jumpHeight = playerFigure.GetComponent<MeshRenderer>().bounds.size.y * jumpHeightRatio;
    }

    private void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    private void OnJump()
    {
        //StartCoroutine(JumpingCoroutine());
        _rb.AddForce(transform.up * 5, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (test) DrawAxes();
        ExecuteMovement();
    }

    IEnumerator JumpingCoroutine()
    {
        Vector3 targetPosition = transform.position + transform.up * _jumpHeight;
        Vector3 startPosition = transform.position;
        float timeCount = 0;
        
        if (_isGrounded)
        {
            while (timeCount / jumpTime <= 1)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, EaseOutBack(timeCount / jumpTime));
                timeCount += Time.deltaTime;
                yield  return null;
            }
        }
        yield break;
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
        
        if(_isGrounded){
            _moveDirection = transform.forward * (_moveClamped.z * speed);
        }
        
        RotatePlayer(_moveBy);
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * (_moveClamped.z * (speed * Time.deltaTime)));
    }

    private void RotatePlayer(Vector3 rotationVector)
    {
        transform.Rotate(0, _moveClamped.x * rotationSpeed * Time.deltaTime, 0);
    }
    
    float EaseOutBack(float x){

        return 1 + _c3 * Mathf.Pow(x - 1, 3) + _c1 * Mathf.Pow(x - 1, 2);
    }
}
