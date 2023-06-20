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

    private const float CollisionDetectionDistance = 3f;
    private Transform _thisTransform;
    private bool _collisionInFront, _isRotating;
    private float _timeCount, _interval;
    private Quaternion _targetRotation;
    private RaycastHit _hit;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _thisTransform = transform;
        _interval = Random.Range(2f, 5f);
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
        //_animator.SetBool("walk", _isMoving);
        RotateEnemy();
        MoveEnemy();
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
