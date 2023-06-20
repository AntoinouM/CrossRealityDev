using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    public static HealthDisplay instance;

    [field: SerializeField] public Image[] healthPoints { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseHealth(int amount, int originalHealth)
    {
        for (int i = 1; i <= amount; i++)
        {
            healthPoints[originalHealth - i].enabled = false;
        }
    }

    public void RestoreHealth(int amount)
    {
        foreach (var healthPoint in healthPoints)
        {
            healthPoint.enabled = true;
        }
    }
}