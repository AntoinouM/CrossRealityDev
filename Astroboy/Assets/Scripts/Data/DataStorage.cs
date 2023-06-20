using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataStorage : MonoBehaviour
{
    [SerializeField] private GravityForce gravityForce;
    [SerializeField][Range(1,20)] private float personalizedForce;
    [SerializeField] private InputActionAsset inputSystem;

    public static DataStorage instance;

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

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.Health = MaxHealth;
            instance.CurrOxygen = MaxOxygen;
            instance.MaxBackpackSpace = 5;

            BackpackItems = new List<GameObject>();
            ItemsAtRocket = new List<GameObject>();
            DontDestroyOnLoad(gameObject);
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
    }

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
        }
        else
        {
            SceneSwitcher.instance.LoadScene("GameOver");
        }
    }

    public void RestoreHealth(int amount)
    {
        Health += amount;
        if (Health > MaxHealth) Health = MaxHealth;
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
    }
    
    public void RefillOxygen()
    {
        CurrOxygen += 10 * Time.deltaTime;
        if (CurrOxygen > MaxOxygen) CurrOxygen = MaxOxygen;
    }
    
    void Start()
    {

    }

    void Update()
    {

    }
}
