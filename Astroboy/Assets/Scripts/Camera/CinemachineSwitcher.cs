using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    public static CinemachineSwitcher instance;

    private Animator animator;
    private bool defaultCamera = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchState()
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



