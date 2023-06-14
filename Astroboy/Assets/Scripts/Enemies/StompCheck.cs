using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHeadStompCheck>())
        {
            Destroy(this.transform.parent.gameObject, 0.1f);
        }
    }
}
