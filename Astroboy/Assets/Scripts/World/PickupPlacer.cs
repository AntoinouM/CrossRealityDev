using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupPlacer : MonoBehaviour
{
    [SerializeField] private int amountOfObjects = 10;

    [SerializeField] private GameObject planet;

    private float planetRadius;
    // Start is called before the first frame update
    void Start()
    {
        planetRadius = planet.GetComponent<SphereCollider>().radius;
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector3 direction = Random.onUnitSphere * planetRadius * 2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(Random.onUnitSphere * 75, new Vector3(10, 10, 10));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
