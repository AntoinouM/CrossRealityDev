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
    
    public int Health
    {
        get;
        private set;
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Gravity = gravityForce switch
        {
            GravityForce.Earth => -9.81f,
            GravityForce.Moon => -1.62f,
            GravityForce.Personalized => -personalizedForce,
            _ => Gravity
        };

        Health = 5;
        
        inputSystem.FindAction("Interact").Disable();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        print(Health);
    }
    
    void Start()
    {

    }

    void Update()
    {

    }
}
