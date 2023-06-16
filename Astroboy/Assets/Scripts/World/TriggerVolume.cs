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
    [SerializeField] private string text;
    [SerializeField] private string sceneToLoad = "none";
    [SerializeField] private GameObject pickupObject = null;

    private TextMeshProUGUI textElement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Entering: " + gameObject.name);
            other.gameObject.GetComponent<PlayerInput>().actions["Interact"].Enable();
            PlayerTriggerController.triggerTag = tag;
            PlayerTriggerController.sceneToLoad = sceneToLoad;
            PlayerTriggerController.pickupObject = pickupObject;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
            other.gameObject.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Leaving: " + gameObject.name);
            other.gameObject.GetComponent<PlayerInput>().actions["Interact"].Disable();
            other.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        }
    }
}
