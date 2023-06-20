using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    [SerializeField] private GravityAttractor attractor;
    [SerializeField] [Range(0, 1)] private float smoothInterpolationParam = 1f;
    [SerializeField][Range(1, 1000)] private float objectMass = 500f;
    [Space(10)]

    private Rigidbody _myRigidBody;
    private Transform _myTransform;
    
    // Start is called before the first frame update
    private void Awake()
    {

    }

    void Start()
    {
        // set RigidBody parameters
        _myRigidBody = GetComponent<Rigidbody>();
        _myRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        _myRigidBody.useGravity = false;
        _myRigidBody.mass = objectMass;
        _myRigidBody.interpolation = RigidbodyInterpolation.Extrapolate;
        _myRigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(_myTransform, _myRigidBody, smoothInterpolationParam);
    }
}
