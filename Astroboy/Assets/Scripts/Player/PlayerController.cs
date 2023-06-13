using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed = 0.1f;

    private Vector3 moveBy;
    private Vector3 lookDir;
    private bool isMoving;

    //private Vector2 lookDirection;
    private float xRotation;
    private float yRotation;
    
    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteMovement();
    }
    
    void ExecuteMovement()
    {

        float targetRotation =
            Quaternion.LookRotation(lookDir).eulerAngles.y + mainCamera.transform.eulerAngles.y;

        if (moveBy == Vector3.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (!isMoving)
        {
            transform.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0);
            return;
        }
        
        RotatePlayerFigure(moveBy);
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        //transform.Translate(moveBy * (speed * Time.deltaTime));
    }
    
    private void RotatePlayerFigure(Vector3 rotateVector)
    {
        rotateVector = Vector3.Normalize(rotateVector);
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        var rotationY = 90 * rotateVector.x;

        if (rotateVector.z < 0)
        {
            transform.Rotate(0, 180, 0);
            rotationY *= -1;
        }
        transform.Rotate(0, rotationY, 0);
    }
    
    void OnLook(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        lookDir = new Vector3(inputValue.x, 0, inputValue.y);
    }
}
