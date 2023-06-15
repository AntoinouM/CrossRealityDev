using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    public static string triggerTag;
    public static string sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInteract()
    {
        
        if (triggerTag == "CameraSwitch")
        {
            //print("Performed CameraSwitch on: " + gameObject.name);
            CinemachineSwitcher.SwitchState();
        }

        if (triggerTag == "SceneSwitch")
        {
            //print("Performed SceneSwitch on: " + gameObject.name);
            SceneSwitcher.instance.LoadScene(sceneToLoad);
        }
    }
}
