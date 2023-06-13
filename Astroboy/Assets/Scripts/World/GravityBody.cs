using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    [SerializeField] private GravityAttractor attractor;

    private Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(myTransform);
    }
}
