using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[Serializable]
public struct WinCondition
{
    public GameObject typeOfItemToCollect;
    public int numberOfItemsToCollect;
}

public class DataStorage : MonoBehaviour
{
    [SerializeField] private GravityForce gravityForce;
    [SerializeField][Range(1,20)] private float personalizedForce;
    [SerializeField] private InputActionAsset inputSystem;
    
    [SerializeField] private AK.Wwise.RTPC oxygen;

    public static DataStorage instance;

    [field: SerializeField]
    public WinCondition[] winCondition
    {
        get;
        private set;
    }

    public float Gravity
    {
        get;
        private set;
    }
    
    [field: SerializeField, Range(3,5)]
    public int MaxHealth
    {
        get;
        private set;
    }
    
    public int Health
    {
        get;
        private set;
    }
    
    public int MaxBackpackSpace
    {
        get;
        private set;
    }
    
    public int BackpackSpaceUsed
    {
        get;
        private set;
    }

    public List<GameObject> BackpackItems
    {
        get;
        private set;
    }

    public List<GameObject> ItemsAtRocket
    {
        get;
        private set;
    }

    [field: SerializeField]
    public float MaxOxygen
    {
        get;
        private set;
    }

    public float CurrOxygen
    {
        get;
        private set;
    }

    public bool GotLaika
    {
        get;
        private set;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if (instance == null)
        {
            instance = this;
            instance.Health = MaxHealth;
            instance.CurrOxygen = MaxOxygen;
            instance.MaxBackpackSpace = 5;

            BackpackItems = new List<GameObject>();
            ItemsAtRocket = new List<GameObject>();
        }
        else Destroy(this.gameObject);

        Gravity = gravityForce switch
        {
            GravityForce.Earth => -9.81f,
            GravityForce.Moon => -1.62f,
            GravityForce.Personalized => -personalizedForce,
            _ => Gravity
        };
        
        inputSystem.FindAction("Interact").Disable();
        
        oxygen.SetGlobalValue(100);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            SceneSwitcher.instance.LoadScene("GameOver");
            //SceneManager.LoadSceneAsync("GameOver");
            //Destroy(gameObject);
        }
    }

    public void AddHealth(int heal)
    {
        if (Health < MaxHealth) Health += heal;
    }

    public void RestoreHealth()
    {
        Health = MaxHealth;
    }

    public void FillBackpack(int backpackSpaceNeeded, GameObject pickupObject)
    {
        BackpackSpaceUsed += backpackSpaceNeeded;
        BackpackItems.Add(pickupObject);
    }

    public void EmptyBackpack()
    {
        BackpackSpaceUsed = 0;
        print(BackpackItems);
        ItemsAtRocket.AddRange(BackpackItems);
        print(ItemsAtRocket);
        BackpackItems.Clear();

    }

    public void LoseOxygen()
    {
        CurrOxygen -= 1 * Time.deltaTime;
        if (CurrOxygen <= 0)
        {
            SceneSwitcher.instance.LoadScene("GameOver");
            //SceneManager.LoadSceneAsync("GameOver");
            //Destroy(gameObject);
        }
    }
    
    public void RefillOxygen()
    {
        CurrOxygen += 10 * Time.deltaTime;
        if (CurrOxygen > MaxOxygen) CurrOxygen = MaxOxygen;
    }

    public void TookBone()
    {
        GotLaika = true;
    }
    
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Heartbeat", gameObject);
    }

    void Update()
    {
        oxygen.SetGlobalValue(CurrOxygen);
    }
}
