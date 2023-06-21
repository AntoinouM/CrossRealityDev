using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSizeRandomer : MonoBehaviour
{
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    [SerializeField] private Transform moonTransform;
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            // rotate
            Quaternion rotation = child.rotation;
            Vector3 gravityUp = (child.position - moonTransform.transform.position).normalized;
            Vector3 bodyUp = child.up;

            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * rotation;
            rotation = Quaternion.Slerp(rotation, targetRotation, 1);
            child.rotation = rotation;

            // scale
            float rdmSize = Random.Range(minSize, maxSize);
            child.localScale = new Vector3(rdmSize, rdmSize, rdmSize);
        }
    }

}
