using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float maximumAngle;
    
    private Transform playerTransform;
    
    void Start()
    {
        playerTransform = player.transform;
    }

    void OnCameraMovement(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        CameraRotationYAxis(inputVector);
        CameraRotationXAxis(inputVector);
    }
    
    void CameraRotationYAxis(Vector2 inputVector)
    {
        this.transform.RotateAround(playerTransform.position, new Vector3(0,1,0), inputVector.x);
        //playerTransform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);
    }
    
    void CameraRotationXAxis(Vector2 inputVector)
    {
        var upValue = inputVector.y * 0.2f;
        var originalPosition = transform.position;
        var originalRotation = transform.rotation;
        this.transform.RotateAround(playerTransform.position, transform.right, upValue);

        if (Vector3.Angle(playerTransform.forward, transform.forward) > maximumAngle)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }
}
