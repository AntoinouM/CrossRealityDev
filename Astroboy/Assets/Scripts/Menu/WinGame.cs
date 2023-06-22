using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameWinText;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Winning", gameObject);
        if (DataStorage.instance.GotLaika)
        {
            gameWinText.text = "You made it. You repaired the rocket.";
        }
        else
        {
            gameWinText.text = "You made it. You repaired the rocket. But where is Laika.";
        }
        Destroy(DataStorage.instance.gameObject);
    }
    
    public void StartGame()
    {
        AkSoundEngine.SetSwitch("Computer", "Click", gameObject);
        AkSoundEngine.PostEvent("Play_Computer", gameObject);
        StartCoroutine(StartGameAfterDelay(0.1f)); 
    }

    public void ToMenu()
    {
        AkSoundEngine.SetSwitch("Computer", "Click", gameObject);
        AkSoundEngine.PostEvent("Play_Computer", gameObject);
        StartCoroutine(ToMenuAfterDelay(0.1f));
    }

    IEnumerator StartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync("Moon");
        Destroy(gameObject);
    }

    IEnumerator ToMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync("Menu");
        Destroy(gameObject);
    }
}
