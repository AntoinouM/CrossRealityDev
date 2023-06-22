using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool testing;
    [Space(10)]
    [SerializeField] private float slerpFactor;
    [SerializeField] private float speed;
    [SerializeField] private float minMoveDuration;
    [SerializeField] private float maxMoveDuration;
    [SerializeField] private float minIdleDuration;
    [SerializeField] private float maxIdleDuration;

    private const float CollisionDetectionDistance = 3f;
    private Transform _thisTransform;
    private bool _collisionInFront, _isRotating, _isMoving;
    private float _timeCount, _interval, _movementDuration, _currentMoveTime, _idleDuration, _currentIdleTime;
    private Quaternion _targetRotation;
    private RaycastHit _hit;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _thisTransform = transform;
        _interval = Random.Range(2f, 5f);
        _isMoving = Random.value > 0.5f;
        if (_isMoving) _movementDuration = Random.Range(minMoveDuration, maxMoveDuration);
        else _idleDuration = Random.Range(minIdleDuration, maxIdleDuration);
        _targetRotation = Random.rotation;
        _animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;
        if (testing) DrawHelpers();
        ExecuteMovement();
        
        
    }

    private void ExecuteMovement()
    {
        if (!_isMoving)
        {
            _currentIdleTime += Time.deltaTime;
            if (_currentIdleTime >= _idleDuration)
            {
                _isMoving = true;
                _currentMoveTime = 0f;
                _movementDuration = Random.Range(minMoveDuration, maxMoveDuration);
            }
        }
        else
        {
            _currentMoveTime += Time.deltaTime;
            if (_currentMoveTime >= _movementDuration)
            {
                _isMoving = false;
                _currentIdleTime = 0f;
                _idleDuration = Random.Range(minIdleDuration, maxIdleDuration);
            }
            else
            {
                RotateEnemy();
                MoveEnemy();
            }
        }
        _animator.SetBool("walk", _isMoving);
    }

    private void RotateEnemy()
    {
        CheckFront();
        GetNewRotation();
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, slerpFactor * Time.deltaTime);
    }

    private void GetNewRotation()
    {
        if (!(_timeCount >= _interval)) return;
        _targetRotation = Random.rotation;
        _interval = Random.Range(2f, 5f);
        _timeCount = 0;
    } 

    private void MoveEnemy()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void CheckFront()
    {
        _collisionInFront = Physics.BoxCast(_thisTransform.position, transform.lossyScale, transform.forward, out _hit, transform.rotation, CollisionDetectionDistance);
        if (_collisionInFront && !_hit.collider.CompareTag("Surface"))
        {
            float randomRotation = Random.Range(0, 2) == 0 ? -90f : 90f;
            _targetRotation *= Quaternion.Euler(0f, randomRotation, 0f);
            _timeCount = 0;
        }
    }

    private void DrawHelpers()
    {
        Debug.DrawRay(_thisTransform.position, _thisTransform.forward * 3, Color.green);
    }
}
