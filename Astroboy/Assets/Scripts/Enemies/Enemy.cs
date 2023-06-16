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
        if (other.transform.CompareTag("Player"))
        {
            print("bump");
            var originalHealth = DataStorage.instance.Health;
            DataStorage.instance.TakeDamage(1);
            HealthDisplay.instance.LoseHealth(1, originalHealth);
        }
    }
}

