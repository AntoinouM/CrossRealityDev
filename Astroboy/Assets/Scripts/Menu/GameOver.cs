using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

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
        Destroy(DataStorage.instance.gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Moon");
    }
    
    public void ToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    
}
