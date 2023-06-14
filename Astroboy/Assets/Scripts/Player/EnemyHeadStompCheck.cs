using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadStompCheck : MonoBehaviour
{
    [SerializeField] private float jumpBoost;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.parent.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<StompCheck>())
        {
            _rb.AddForce(transform.up * jumpBoost, ForceMode.VelocityChange);
        }
    }
}
