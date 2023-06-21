using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTriggerController : MonoBehaviour
{
    public static string triggerTag;
    public static string sceneToLoad;
    public static int backpackSpace;
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
                    AkSoundEngine.SetSwitch("Computer", "Turn_off", gameObject);
                    AkSoundEngine.PostEvent("Play_Computer", gameObject);
                    playerInput.actions.Enable();
                }
                else
                {
                    AkSoundEngine.SetSwitch("Computer", "Boot", gameObject);
                    AkSoundEngine.PostEvent("Play_Computer", gameObject);
                    playerInput.actions.Disable();
                    playerInput.actions["Interact"].Enable();
                }
                insideComputer = !insideComputer;
                CinemachineSwitcher.instance.SwitchState();
                UIController.instance.ChangeVisibility();
                break;
            
            case "SceneSwitch":
                
                AkSoundEngine.StopAll();
                AkSoundEngine.PostEvent("Play_Door", gameObject);

                if (sceneToLoad == "Moon") // inside Rocket
                {
                    Debug.Log("Hello");
                }
                else
                {
                    AkSoundEngine.PostEvent("Play_Ambience", gameObject);
                }
                
                SceneSwitcher.instance.LoadScene(sceneToLoad);
                break;
            
            case "Pickup":
                //Destroy(pickupObject);
                pickupObject.SetActive(false);
                print("Picked up Object");
                DataStorage.instance.FillBackpack(backpackSpace, pickupObject);
                BackpackDisplay.instance.PickUpItem(backpackSpace);
                playerInput.actions["Interact"].Disable();
                GetComponentInChildren<Canvas>().enabled = false;
                break;
            
            case "Sleep":
                print("Restored Health");
                AkSoundEngine.PostEvent("Play_Sleep", gameObject);
                playerInput.actions.Disable();
                UIController.instance.ChangeVisibility();
                CinemachineEffects.instance.Sleep(3, playerInput);
                var originalHealth = DataStorage.instance.Health;
                DataStorage.instance.RestoreHealth();
                var healthAfterHeal = DataStorage.instance.Health;
                HealthDisplay.instance.RestoreHealth(healthAfterHeal - originalHealth);
                //playerInput.actions.Enable();
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
