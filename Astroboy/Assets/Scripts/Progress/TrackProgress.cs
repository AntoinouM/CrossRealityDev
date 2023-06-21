using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrackProgress : MonoBehaviour
{
    public static WinCondition[] winCondition;
    public static List<GameObject> allItems;
    public static int totalItemsToWin;
    public static int[] collectedCounts;
    public static bool winGame = true;
    
    // Start is called before the first frame update
    void Start()
    {
        winCondition = DataStorage.instance.winCondition;
        allItems = DataStorage.instance.ItemsAtRocket;
        collectedCounts = new int[winCondition.Length];

        for (int i = 0; i < winCondition.Length; i++)
        {
            GameObject itemToCollect = winCondition[i].typeOfItemToCollect;
            int numberOfItemsToCollect = winCondition[i].numberOfItemsToCollect;
            totalItemsToWin += numberOfItemsToCollect;
            int collectedCount = allItems.Count(item => item.CompareTag(itemToCollect.tag));
            collectedCounts[i] = collectedCount;
            if (collectedCount < numberOfItemsToCollect) winGame = false;
            Debug.Log(itemToCollect.name + " - Collected: " + collectedCount + "/" + numberOfItemsToCollect);
        }
        
        if (winGame) SceneSwitcher.instance.LoadScene("WinGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
