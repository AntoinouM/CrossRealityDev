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
            int originalHealth = DataStorage.instance.Health;
            
            BumpPlayerBack(other);
            DataStorage.instance.TakeDamage(1);
            HealthDisplay.instance.LoseHealth(1, originalHealth);
        }
    }

    private void BumpPlayerBack(Collision other)
    {
        this.GetComponent<Rigidbody>().AddForce((transform.up) * bumpForce/3, ForceMode.VelocityChange);
        this.GetComponent<Rigidbody>().AddForce((transform.forward * -1) * bumpForce, ForceMode.VelocityChange);
    }
}
