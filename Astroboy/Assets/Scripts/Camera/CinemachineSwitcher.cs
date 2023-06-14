using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{

    [SerializeField] private InputAction action;

    private Animator animator;

    private bool defaultCamera = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {
        action.performed += _ => SwitchState();
    }

    private void SwitchState()
    {
        if (defaultCamera)
        {
            animator.Play("ComputerCamera");
        }
        else
        {
            animator.Play("DefaultCamera");
        }

        defaultCamera = !defaultCamera;
    }
    
    void Update()
    {
        
    }
}
