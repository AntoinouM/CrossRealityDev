using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayIndividualItemsInRocket : MonoBehaviour
{
    [SerializeField] private string instanceTag;

    private List<GameObject> itemsAtRocket;

    private int numberOfItemsInRocket;
    // Start is called before the first frame update
    void Start()
    {
        itemsAtRocket = DataStorage.instance.ItemsAtRocket;
        foreach (var item in itemsAtRocket)
        {
            if (item.CompareTag(instanceTag)) numberOfItemsInRocket++;
        }
        GetComponent<TextMeshProUGUI>().text = numberOfItemsInRocket.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
