using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    
    private float _gravity;

    public void Attract(Transform body, Rigidbody rb, float smoothInterpolator)
    {
        Quaternion rotation = body.rotation;
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        
        rb.AddForce(gravityUp * (_gravity * rb.mass));
        
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * rotation;
        rotation = Quaternion.Slerp(rotation, targetRotation, smoothInterpolator);
        body.rotation = rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gravity = DataStorage.instance.Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
