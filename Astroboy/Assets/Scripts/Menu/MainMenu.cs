using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        PlayClickSound();
        StartCoroutine(StartGameAfterDelay(0.1f));
    }

    public void QuitGame()
    {
        PlayClickSound();
        StartCoroutine(QuitAfterDelay(0.1f));
    }
    
    IEnumerator StartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync("Moon");
        Destroy(gameObject);
    }

    IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AkSoundEngine.StopAll();
        Application.Quit();
        print("Quitting");
    }

    public void PlayClickSound()
    {
        AkSoundEngine.SetSwitch("Computer", "Click", gameObject);
        AkSoundEngine.PostEvent("Play_Computer", gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
