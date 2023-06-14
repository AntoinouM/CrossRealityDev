using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadScene(string scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        print("Colliding");
        if (other.gameObject.CompareTag("Player"))
        {
            print("Registered as player");
            SceneManager.LoadSceneAsync(scene);
        }
            
    }*/
}
