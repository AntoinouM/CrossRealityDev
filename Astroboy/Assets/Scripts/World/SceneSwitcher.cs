using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject objectsOnMoon;
    
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
        if (scene != "Moon")
        {
            objectsOnMoon.SetActive(false);
            DataStorage.instance.EmptyBackpack();
            BackpackDisplay.instance.ReleaseItems();
        }
        else
        {
            objectsOnMoon.SetActive(true);
        }
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
