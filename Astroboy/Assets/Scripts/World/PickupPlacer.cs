using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public struct Objects
{
    public GameObject[] objectToPlace;
    public GameObject parentObject;
    public int amountOfObjects;
    public GameObject objectToCenterAround;
    public string minOffsetToGround;
    public string maxOffsetToGround;

}

public class PickupPlacer : MonoBehaviour
{
    [SerializeField] private GameObject moon;
    [SerializeField] private Objects[] objects;
    [SerializeField] private GameObject parentObject;

    [Space(10)]
    
    [SerializeField] private GameObject pickupObject;
    [SerializeField] private int amountOfObjects = 10;
    [SerializeField] private float offsetToGround = 0;
    [SerializeField] private GameObject centerPositionObject;
    [SerializeField] private float rotationSpeed = 30;

    [Space(10)] private List<GameObject> pickupArray;

    void Start()
    {
        Transform centerTransform = centerPositionObject.transform;
        Vector3 centerPosition = centerTransform.position;
        Quaternion centerRotation = centerTransform.rotation;
        pickupArray = new List<GameObject>();
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector3 position = Random.onUnitSphere * (moon.transform.localScale.x + offsetToGround) + centerPosition;
            GameObject newPickUp = Instantiate(pickupObject, position, Quaternion.identity);

            Vector3 targetDirection = moon.transform.position - newPickUp.transform.position;
            Quaternion targetRotation = Quaternion.FromToRotation(centerTransform.up, -targetDirection) * centerRotation;
            newPickUp.transform.rotation = targetRotation;

            newPickUp.transform.SetParent(parentObject.transform);
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
