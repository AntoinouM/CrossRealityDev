using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadPop : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
    }
}
