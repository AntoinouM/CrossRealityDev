using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPS;
    private void Awake()
    {
    }

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHeadStompCheck>())
        {
            if(!explosionPS.isPlaying) explosionPS.Play();
            Destroy(this.transform.parent.gameObject, 0.1f);
        }
    }
}
