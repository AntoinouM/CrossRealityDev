using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private InputAction action;
    [SerializeField] private InputActionAsset inputs;
    [SerializeField] private Canvas popUp;
    [SerializeField] private string text;

    [SerializeField] private string sceneToLoad = "none";

    private TextMeshProUGUI textElement;
    // Start is called before the first frame update
    void Start()
    {
        textElement = popUp.GetComponentInChildren<TextMeshProUGUI>();
        /*if (action != null)
        {
            action.performed += _ =>
            {
                //print("Performed action of: " + gameObject.name);
            
                if (this.CompareTag("CameraSwitch"))
                {
                    //print("Performed CameraSwitch on: " + gameObject.name);
                    CinemachineSwitcher.SwitchState();
                }

                if (this.CompareTag("SceneSwitch"))
                {
                    //print("Performed SceneSwitch on: " + gameObject.name);
                    SceneSwitcher.instance.LoadScene(sceneToLoad);
                }
            
            };
        }*/
    }
    /*private void OnInteract()
    {
        if (this.CompareTag("CameraSwitch"))
        {
            //print("Performed CameraSwitch on: " + gameObject.name);
            CinemachineSwitcher.SwitchState();
        }

        if (this.CompareTag("SceneSwitch"))
        {
            //print("Performed SceneSwitch on: " + gameObject.name);
            SceneSwitcher.instance.LoadScene(sceneToLoad);
        }
    }*/

    private void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Entering: " + gameObject.name);
            
            inputs.FindAction("Interact").Enable();
            PlayerTriggerController.triggerTag = tag;
            PlayerTriggerController.sceneToLoad = sceneToLoad;
            textElement.SetText(text);
            popUp.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Leaving: " + gameObject.name);
            inputs.FindAction("Interact").Disable();
            popUp.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
