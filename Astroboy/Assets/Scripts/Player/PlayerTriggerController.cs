using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTriggerController : MonoBehaviour
{
    public static string triggerTag;
    public static string sceneToLoad;

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
        
        if (triggerTag == "CameraSwitch")
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
    }
}
