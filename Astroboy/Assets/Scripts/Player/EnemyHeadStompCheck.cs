using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadStompCheck : MonoBehaviour
{
    [SerializeField] private float jumpBoost;
    private Rigidbody _rb;
    private bool _onSurface;

    public bool OnSurface => _onSurface;
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
            DataStorage.instance.AddHealth(1);
        }

        _onSurface = collision.GetComponent<GravityAttractor>();
    }

    private void OnTriggerExit(Collider other)
    {
        _onSurface = false;
    }
}
