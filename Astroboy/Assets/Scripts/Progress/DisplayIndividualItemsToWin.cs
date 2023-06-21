using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayIndividualItemsToWin : MonoBehaviour
{
    [SerializeField] private int itemIndex = 0;
    private WinCondition[] winCondition;

    private int numberOfItemsNeeded;
    // Start is called before the first frame update
    void Start()
    {
        winCondition = DataStorage.instance.winCondition;
        numberOfItemsNeeded = winCondition[itemIndex].numberOfItemsToCollect;
        GetComponent<TextMeshProUGUI>().text = "/" + numberOfItemsNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
