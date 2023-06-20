using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerTriggerHandler : MonoBehaviour
{
    private Canvas canvasInteraction;

    private TextMeshProUGUI textInteraction;

    private InputActionAsset inputs;

    private bool insideInteractionTrigger = false;

    private string tagOfInteractionTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        canvasInteraction = GetComponentInChildren<Canvas>();
        textInteraction = canvasInteraction.GetComponentInChildren<TextMeshProUGUI>();
        inputs = GetComponent<PlayerInput>().actions;
        inputs.FindAction("Interact").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInteract()
    {
        print("Interacting");
        if (insideInteractionTrigger)
        {
            if (tagOfInteractionTrigger == "CameraSwitch")
            {
                //print("Performed CameraSwitch on: " + gameObject.name);
                CinemachineSwitcher.instance.SwitchState();
            }

            if (tagOfInteractionTrigger == "SceneSwitch")
            {
                //print("Performed SceneSwitch on: " + gameObject.name);
                //SceneSwitcher.instance.LoadScene("Moon");
                if (SceneManager.GetActiveScene().name == "Moon")
                {
                    SceneManager.LoadSceneAsync("Rocket");
                }
                else
                {
                    SceneManager.LoadSceneAsync("Moon");
                }
                
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraSwitch") || other.gameObject.CompareTag("SceneSwitch"))
        {
            print("Entered " + other.gameObject.name);
            insideInteractionTrigger = true;
            tagOfInteractionTrigger = other.gameObject.tag;
            textInteraction.SetText("Enter");
            canvasInteraction.enabled = true;
            inputs.FindAction("Interact").Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.gameObject.CompareTag("CameraSwitch") || other.gameObject.CompareTag("SceneSwitch"))
        {
            print("Exited " + other.gameObject.name);
            insideInteractionTrigger = false;
            textInteraction.SetText("Exit");
            canvasInteraction.enabled = false;
            inputs.FindAction("Interact").Disable();
        }
    }
}
