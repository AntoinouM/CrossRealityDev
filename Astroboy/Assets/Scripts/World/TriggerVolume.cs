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
    [SerializeField] private Canvas popUp;
    [SerializeField] private string text;

    [SerializeField] private string sceneToLoad = "none";

    private TextMeshProUGUI textElement;
    // Start is called before the first frame update
    /*void Start()
    {
        textElement = popUp.GetComponentInChildren<TextMeshProUGUI>();
        action.Disable();
        action.performed += _ =>
        {
            if (!gameObject.IsDestroyed())
            {
                if (this.gameObject.CompareTag("CameraSwitch"))
                {
                    //print("Performed CameraSwitch on: " + gameObject.name);
                    CinemachineSwitcher.SwitchState();
                }

                if (this.gameObject.CompareTag("SceneSwitch"))
                {
                    //print("Performed SceneSwitch on: " + gameObject.name);
                    SceneSwitcher.instance.LoadScene(sceneToLoad);
                }
                //print("Performed action of: " + gameObject.name);
            }
        };
    }

    private void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Entering: " + gameObject.name);
            textElement.SetText(text);
            popUp.enabled = true;
            action.Enable();
            //CinemachineSwitcher.SwitchState();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Leaving: " + gameObject.name);
            popUp.enabled = false;
            action.Disable();
            //CinemachineSwitcher.SwitchState();
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        
    }
}
