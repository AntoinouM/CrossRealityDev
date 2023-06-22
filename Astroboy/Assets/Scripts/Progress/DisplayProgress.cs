using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProgress : MonoBehaviour
{
    
    public static DisplayProgress instance;
    [SerializeField] private ProgressDisplay display;
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI percentage;
    [SerializeField] private TextMeshProUGUI item1Needed;
    [SerializeField] private TextMeshProUGUI item2Needed;
    [SerializeField] private TextMeshProUGUI item1Current;
    [SerializeField] private TextMeshProUGUI item2Current;
    [SerializeField] private string instanceTag1;
    [SerializeField] private string instanceTag2;
    

    private int totalItemsAtRocket;
    private WinCondition[] winCondition;
    private int totalItemsToWin;
    private float progressPercentage;
    private int numberOfIndividualItemsNeeded1;
    private int numberOfIndividualItemsNeeded2;
    private int numberOfItemsInRocket1;
    private int numberOfItemsInRocket2;
    private float progressPercentageItem1;
    private float progressPercentageItem2;
    private List<GameObject> itemsAtRocket;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        RecalculateProgress();
        CheckWin();
    }

    public void RecalculateProgress()
    {
        totalItemsAtRocket = DataStorage.instance.ItemsAtRocket.Count;
        print(totalItemsAtRocket);
        winCondition = DataStorage.instance.winCondition;
        totalItemsToWin = 0;
        foreach (var item in winCondition)
        {
            totalItemsToWin += item.numberOfItemsToCollect;
        }
        print(totalItemsToWin);

        //progressPercentage = (float)totalItemsAtRocket / totalItemsToWin;

        numberOfIndividualItemsNeeded1 = winCondition[0].numberOfItemsToCollect;
        item1Needed.text = "/" + numberOfIndividualItemsNeeded1;
        numberOfIndividualItemsNeeded2 = winCondition[1].numberOfItemsToCollect;
        item2Needed.text = "/" + numberOfIndividualItemsNeeded2;
        
        itemsAtRocket = DataStorage.instance.ItemsAtRocket;

        numberOfItemsInRocket1 = 0;
        numberOfItemsInRocket2 = 0;
        foreach (var item in itemsAtRocket)
        {
            if (item.CompareTag(instanceTag1)) numberOfItemsInRocket1++;
            if (item.CompareTag(instanceTag2)) numberOfItemsInRocket2++;
        }

        item1Current.text = numberOfItemsInRocket1.ToString();
        item2Current.text = numberOfItemsInRocket2.ToString();
        
        progressPercentageItem1 = (float)numberOfItemsInRocket1 / numberOfIndividualItemsNeeded1;
        if (progressPercentageItem1 > 1) progressPercentageItem1 = 1;
        progressPercentageItem2 = (float)numberOfItemsInRocket2 / numberOfIndividualItemsNeeded2;
        if (progressPercentageItem2 > 1) progressPercentageItem2 = 1;
        progressPercentage = (progressPercentageItem1 + progressPercentageItem2) / 2;
        
        progressBar.transform.localScale = new Vector3(progressPercentage, 1, 1);
        percentage.text = Mathf.Round(progressPercentage * 100 ) + " %";
    }

    public void CheckWin()
    {
        if (numberOfItemsInRocket1 >= numberOfIndividualItemsNeeded1 &&
            numberOfItemsInRocket2 >= numberOfIndividualItemsNeeded2)
        {
            SceneSwitcher.instance.LoadScene("WinGame");
        }
    }
}
