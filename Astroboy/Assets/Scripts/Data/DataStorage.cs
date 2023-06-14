using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataStorage : MonoBehaviour
{
    [SerializeField] private GravityForce gravityForce;
    [SerializeField][Range(1,20)] private float personalizedForce;

    public static DataStorage instance;

    public float Gravity
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
        
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
        
        Gravity = gravityForce switch
        {
            GravityForce.Earth => -9.81f,
            GravityForce.Moon => -1.62f,
            GravityForce.Personalized => -personalizedForce,
            _ => Gravity
        };
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
