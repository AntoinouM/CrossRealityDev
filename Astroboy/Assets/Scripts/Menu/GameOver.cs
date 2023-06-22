using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

    public static GameOver instance;

    public string deathreason;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("An instance of GameOver already exists!");
            Destroy(this.gameObject);
            return;
        }

        if (DataStorage.instance.Health <= 0)
        {
            deathreason = "Hit";
        }
        else if (DataStorage.instance.CurrOxygen <= 0)
        {
            deathreason = "Breath";
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        //UIController.instance.ChangeVisibility();
        if (DataStorage.instance.Health <= 0)
        {
            gameOverText.text = "You got a bit too close to the aliens. Laika be with you.";
        }
        else if (DataStorage.instance.CurrOxygen <= 0)
        {
            gameOverText.text = "Didn't find the ship in time?. Laika be with you.";
        }
        
        if (DataStorage.instance != null)
        {
            Destroy(DataStorage.instance.gameObject);
        }
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
        instance = null;
        Destroy(gameObject);
    }

    IEnumerator ToMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        AkSoundEngine.StopAll();
        SceneManager.LoadSceneAsync("Menu");
        instance = null;
        Destroy(gameObject);
    }

    
}
