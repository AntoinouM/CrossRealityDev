using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickupPlacer : MonoBehaviour
{
    [SerializeField] private GameObject moon;
    
    [Space(10)]
    
    [SerializeField] private GameObject pickupObject;
    [SerializeField] private int amountOfObjects = 10;
    [SerializeField] private float offsetToGround = 0;
    [SerializeField] private float rotationSpeed = 30;

    [Space(10)] private List<GameObject> pickupArray;

    void Start()
    {
        pickupArray = new List<GameObject>();
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector3 position = Random.onUnitSphere * (moon.transform.localScale.x + offsetToGround) + transform.position;
            GameObject newPickUp = Instantiate(pickupObject, position, Quaternion.identity);

            Vector3 targetDirection = moon.transform.position - newPickUp.transform.position;
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -targetDirection) * transform.rotation;
            newPickUp.transform.rotation = targetRotation;

            pickupArray.Add(newPickUp);
        }
        print(pickupArray);
    }
    
    void Update()
    {
        foreach (var pickup in pickupArray)
        {
            pickup.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
