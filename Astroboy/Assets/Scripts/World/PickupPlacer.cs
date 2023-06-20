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
    public int minOffsetToGround;
    public int maxOffsetToGround;
    public int minSize;
    public int maxSize;
    public bool keepOriginalSize;
    public bool rotateBottomToMoon;
}

public class PickupPlacer : MonoBehaviour
{
    [SerializeField] private Objects[] objects;

    void Start()
    {


        foreach (var obj in objects)
        {
            Transform centerTransform = obj.objectToCenterAround.transform;
            Vector3 centerPosition = centerTransform.position;
            Quaternion centerRotation = centerTransform.rotation;
            for (int i = 0; i < obj.amountOfObjects; i++)
            {
                int offsetToGround = Random.Range(obj.minOffsetToGround, obj.maxOffsetToGround);
                Vector3 position =
                    Random.onUnitSphere * (obj.objectToCenterAround.transform.localScale.x + offsetToGround) +
                    centerPosition;

                GameObject newObj = Instantiate(obj.objectToPlace[Random.Range(0, obj.objectToPlace.Length)],
                    position, Quaternion.identity);
                newObj.transform.SetParent(obj.parentObject.transform);
                int scale = Random.Range(obj.minSize, obj.maxSize);

                if (!obj.keepOriginalSize)
                {
                    newObj.transform.localScale = new Vector3(scale, scale, scale);
                }
                
                if (obj.rotateBottomToMoon)
                {
                    Vector3 targetDirection = obj.objectToCenterAround.transform.position - newObj.transform.position;
                    Quaternion targetRotation = Quaternion.FromToRotation(centerTransform.up, -targetDirection) *
                                                centerRotation;
                    newObj.transform.rotation = targetRotation;
                }
            }
        }
    }
}
