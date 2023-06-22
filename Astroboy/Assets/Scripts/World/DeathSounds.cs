using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour
{

    public static DeathSounds instance;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playDeathSound(string enemy, GameObject enemyObject)
    {
        AkSoundEngine.PostEvent("Play_Particles", gameObject);
        if (enemy == "Squid")
        {
            AkSoundEngine.PostEvent("Stop_Squid", enemyObject.transform.parent.gameObject);
            AkSoundEngine.PostEvent("Play_Squid_Death", gameObject);
        }  else if (enemy == "SquaredEnemy")
        {
            AkSoundEngine.PostEvent("Stop_Squared_Enemy", enemyObject.transform.parent.gameObject);
            Debug.Log("Before Death Sound");
            AkSoundEngine.PostEvent("Play_Squared_Death", gameObject);
            Debug.Log("After Death Sound");
        } 
    }
}
