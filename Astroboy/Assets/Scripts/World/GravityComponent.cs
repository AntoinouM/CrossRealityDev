using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComponent : MonoBehaviour
{
    [SerializeField] private Transform gravitySource;
    [SerializeField] private bool testing = false;

    private float _gravity;

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
        ProcessGravity();
    }

    void ProcessGravity()
    {
        Vector3 distance = transform.position - gravitySource.position;
        _rigidbody.AddForce(-distance.normalized * (_gravity * _rigidbody.mass));
        if (testing)
        {
            Debug.DrawRay(transform.position, distance.normalized, Color.red);
        }
    }
}
