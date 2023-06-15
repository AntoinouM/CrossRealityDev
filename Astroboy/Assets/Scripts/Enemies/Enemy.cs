using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float bumpForce;
    [SerializeField] private Rigidbody rigidBody;

    private void OnCollisionEnter(Collision other)
    {
        print("bump");
    }
}

