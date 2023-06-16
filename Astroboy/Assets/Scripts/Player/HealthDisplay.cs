using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private static Image[] healthPoints;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoseHealth(int amount, int originalHealth)
    {
        for (int i = 1; i <= amount; i++)
        {
            healthPoints[originalHealth - i].enabled = false;
        }
        
    }
}
