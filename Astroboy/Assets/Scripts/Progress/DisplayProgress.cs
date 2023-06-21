using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayProgress : MonoBehaviour
{
    [SerializeField] private ProgressDisplay display;

    private int totalItemsAtRocket;
    private WinCondition[] winCondition;
    private int totalItemsToWin;
    private float progressPercentage;
    void Start()
    {
        totalItemsAtRocket = DataStorage.instance.ItemsAtRocket.Count;
        winCondition = DataStorage.instance.winCondition;

        foreach (var item in winCondition)
        {
            totalItemsToWin += item.numberOfItemsToCollect;
        }

        progressPercentage = Mathf.Round((float)totalItemsAtRocket / totalItemsToWin);
        if (display == ProgressDisplay.ProgressBar)
        {
            GetComponent<Image>().transform.localScale = new Vector3(progressPercentage, 1, 1);
        }

        if (display == ProgressDisplay.Percentage)
        {
            GetComponent<TextMeshProUGUI>().text = progressPercentage * 100 + " %";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
