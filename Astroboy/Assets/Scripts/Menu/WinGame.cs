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
        SceneManager.LoadSceneAsync("Moon");
    }
    
    public void ToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
