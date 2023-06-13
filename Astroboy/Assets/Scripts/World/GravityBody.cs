using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{    
    [SerializeField] private bool isTest;
    [Space(10)]
    [SerializeField] private GravityAttractor attractor;
    [SerializeField] [Range(0, 1)] private float smoothInterpolationParam = 1f;
    [SerializeField] private GameObject gravitySource;
    [Space(10)]

    private float _distanceBetweenObjects;
    private Rigidbody _myRigidBody;
    private Transform _myTransform;
    private MeshRenderer _gravitySourceMeshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
        _myRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        _myRigidBody.useGravity = false;
        _myTransform = transform;
        _gravitySourceMeshRenderer = gravitySource.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _distanceBetweenObjects = Vector3.Distance(transform.position, gravitySource.transform.position) - (_gravitySourceMeshRenderer.bounds.size.z / 2);
        attractor.Attract(_myTransform, _myRigidBody, smoothInterpolationParam);
        
        if (isTest)
        {
            Debug.DrawRay(transform.position, transform.up * 10, Color.magenta);
            Debug.DrawRay(transform.position, transform.forward * 10, Color.magenta);
            Debug.Log(_distanceBetweenObjects);
        }
    }
}
