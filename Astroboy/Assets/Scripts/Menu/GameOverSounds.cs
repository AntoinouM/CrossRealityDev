using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSounds : MonoBehaviour
{
    private bool isPlaying = false;
    // Start is called before the first frame update

    void Awake()
    {
        Debug.Log("GameOverSounds script attached to: " + this.name);
    }
    
    void Start()
    {
        if (!isPlaying)
        {
            AkSoundEngine.SetSwitch("GameOver", GameOver.instance.deathreason, gameObject);
            AkSoundEngine.PostEvent("Play_GameOver", gameObject);
            
            Debug.Log("Sound event posted with reason: " + GameOver.instance.deathreason);
            
            isPlaying = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
