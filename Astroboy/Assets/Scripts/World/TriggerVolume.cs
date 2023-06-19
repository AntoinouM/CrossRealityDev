using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private string sceneToLoad = "none";
    [SerializeField] private int backpackSpace = 0;
    [SerializeField] private GameObject pickupObject = null;
    [SerializeField] private string textOnFullBackpack = "Backpack full";

    //private TextMeshProUGUI textElement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Entering: " + gameObject.name);
            if (DataStorage.instance.BackpackSpace < backpackSpace)
            {
                other.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(textOnFullBackpack);
                other.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
                other.gameObject.GetComponentInChildren<Canvas>().enabled = true;
                other.gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().enabled = false;
                return;
            }
            other.gameObject.GetComponent<PlayerInput>().actions["Interact"].Enable();
            PlayerTriggerController.backpackSpace = backpackSpace;
            PlayerTriggerController.triggerTag = tag;
            PlayerTriggerController.sceneToLoad = sceneToLoad;
            PlayerTriggerController.pickupObject = pickupObject;
            other.gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
            other.gameObject.GetComponentInChildren<Canvas>().enabled = true;
            other.gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Image>().enabled = true;
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
