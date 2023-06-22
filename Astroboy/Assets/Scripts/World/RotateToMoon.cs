using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMoon : MonoBehaviour
{
    [SerializeField] private Transform moonTransform;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {

            Quaternion rotation = child.rotation;
            Vector3 gravityUp = (child.position - moonTransform.position).normalized;
            Vector3 bodyUp = child.up;

            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * rotation;
            rotation = Quaternion.Slerp(rotation, targetRotation, 1);
            child.rotation = rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
