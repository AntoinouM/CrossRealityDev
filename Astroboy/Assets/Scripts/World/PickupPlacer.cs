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
        planetRadius = planet.transform.localScale.x;
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector3 direction = Random.onUnitSphere * planetRadius * 2;
            OnDrawGizmosSelected();
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(Random.onUnitSphere * planetRadius * 2, new Vector3(10, 10, 10));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
