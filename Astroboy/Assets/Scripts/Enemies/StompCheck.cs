using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPS;
    private ParticleSystem.MainModule _explosionPSMain;

    private void Awake()
    {
        explosionPS.Stop();
    }

    private void Start()
    {
        _explosionPSMain = explosionPS.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHeadStompCheck>())
        {
            explosionPS.Play();
            Destroy(this.transform.parent.gameObject, 0.1f);
        }
    }
}
