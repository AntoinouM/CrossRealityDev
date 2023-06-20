using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[Serializable] public struct Buttons
{
    public Button btnProgress;
    public Button btnLogs;
    public Button btnBackProgress;
    public Button btnBackLogs;
    //public Button logsDown;
    //public Button logsUp;
}

[Serializable]
public struct DynamicFields
{
    public Image progressBar;
    //public Text gemCollected;
    //public Text crystalCollected;
    public TextMeshProUGUI progressPercentage;
}

public class ComputerComponent : MonoBehaviour
{
    [SerializeField] private Buttons buttons;
    [SerializeField] private Canvas[] canvas;
    [SerializeField] private DynamicFields dynamicFields;

    private void SwitchCanvas(Canvas canvasOn)
    {
        foreach (Canvas canva in canvas)
        {
            canva.enabled = canva == canvasOn;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SwitchCanvas(canvas[0]);
        buttons.btnProgress.onClick.AddListener(delegate { SwitchCanvas(canvas[1]); });
        buttons.btnLogs.onClick.AddListener(delegate { SwitchCanvas(canvas[2]); });
        buttons.btnBackProgress.onClick.AddListener(delegate { SwitchCanvas(canvas[0]); });
        buttons.btnBackLogs.onClick.AddListener(delegate { SwitchCanvas(canvas[0]); });
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
