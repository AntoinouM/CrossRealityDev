using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTriggerController : MonoBehaviour
{
    public static string triggerTag;
    public static string sceneToLoad;
    public static GameObject pickupObject;

    private PlayerInput playerInput;
    private bool insideComputer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInteract()
    {
        switch (triggerTag)
        {
            case "CameraSwitch":
                if (insideComputer)
                {
                    playerInput.actions.Enable();
                }
                else
                {
                    playerInput.actions.Disable();
                    playerInput.actions["Interact"].Enable();
                }
                insideComputer = !insideComputer;
                CinemachineSwitcher.SwitchState();
                break;
            
            case "SceneSwitch":
                SceneSwitcher.instance.LoadScene(sceneToLoad);
                break;
            
            case "Pickup":
                //Destroy(pickupObject);
                pickupObject.SetActive(false);
                print("Picked up Object");
                playerInput.actions["Interact"].Disable();
                GetComponentInChildren<Canvas>().enabled = false;
                break;
            
            case "Sleep":
                print("Restored Health");
                playerInput.actions["Interact"].Disable();
                CinemachineEffects.instance.Sleep(3);
                DataStorage.instance.RestoreHealth(5);
                playerInput.actions["Interact"].Enable();
                break;

            default:
                print("tag of object not in possible cases");
                break;
        }
        
        /*if (triggerTag == "CameraSwitch")
        {
            if (insideComputer)
            {
                playerInput.actions.Enable();
            }
            else
            {
                playerInput.actions.Disable();
                playerInput.actions["Interact"].Enable();
            }

            insideComputer = !insideComputer;
            CinemachineSwitcher.SwitchState();
        }

        if (triggerTag == "SceneSwitch")
        {
            SceneSwitcher.instance.LoadScene(sceneToLoad);
        }

        if (triggerTag == "Pickup")
        {
            Destroy(pickupObject);
        }*/
    }
}
