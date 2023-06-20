using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionWithEnemy : MonoBehaviour
{
    [SerializeField] private float bumpForce;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<Enemy>())
        {
            var originalHealth = DataStorage.instance.Health;
                DataStorage.instance.TakeDamage(1);
                HealthDisplay.instance.LoseHealth(1, originalHealth);
        }
    }
}
