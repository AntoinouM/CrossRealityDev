using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour
{    
    [SerializeField] private bool isTest = false;
    [Space(10)]
    [SerializeField] private GameObject gravitySource;
    [SerializeField] [Range(0f, 10f)] private float btmAlignmentSpeed = 2.5f;


    private float _gravity;
    private float _distanceBetweenObjects;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gravity = DataStorage.instance.Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        _distanceBetweenObjects = Vector3.Distance(transform.position, gravitySource.transform.position) - (gravitySource.GetComponent<MeshRenderer>().bounds.size.z / 2);
        ProcessGravity();
    }

    void ProcessGravity()
    {
        if (isTest)
        {
            Debug.DrawRay(transform.position, transform.up * 10, Color.magenta);
            Debug.Log(_distanceBetweenObjects);
        }
        
        Vector3 distance = transform.position - gravitySource.transform.position;
        _rigidbody.AddForce(-distance.normalized * (_gravity * _rigidbody.mass));
        if (btmAlignmentSpeed > 0)
        {
           AutoOrient(-distance);
        }
    }

    private void AutoOrient(Vector3 down)
    {
        Quaternion targetRotation = Quaternion.FromToRotation(-transform.up, down.normalized) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 - Mathf.Exp(-btmAlignmentSpeed * Time.deltaTime));
    }
}
