using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupPlacer : MonoBehaviour
{
    [SerializeField] private int amountOfObjects = 10;

    [SerializeField] private GameObject moon;

    [SerializeField] private float offsetToGround;

    private float planetRadius;
    // Start is called before the first frame update
    void Start()
    {
        //planetRadius = moon.GetComponent<SphereCollider>().radius;
        for (int i = 0; i < amountOfObjects; i++)
        {
            //Vector3 direction = Random.onUnitSphere * planetRadius * 2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(Random.onUnitSphere * (moon.transform.localScale.x + offsetToGround) + transform.position , new Vector3(1, 1, 1));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
