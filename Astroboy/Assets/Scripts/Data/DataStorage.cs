using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    [SerializeField] private GravityForce gravityForce;
    [SerializeField] private float personalizedForce;

    public float Gravity
    {
        get;
        private set;
    }
    
    
    void Awake()
    {
        
    }
    void Start()
    {
        Gravity = gravityForce switch
        {
            GravityForce.Earth => 9.81f,
            GravityForce.Moon => 1.62f,
            GravityForce.Personalized => personalizedForce,
            _ => Gravity
        };
    }

    void Update()
    {
        
    }
}
