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
    public Button logsDown1;
    public Button logsDown2;
    public Button logsUp2;
    public Button logsUp3;
}

[Serializable]
public struct DynamicFields
{
    public Image progressBar;
    public TextMeshProUGUI gemCollected;
    public TextMeshProUGUI crystalCollected;
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
        buttons.logsDown1.onClick.AddListener(delegate { SwitchCanvas(canvas[3]); });
        buttons.logsDown2.onClick.AddListener(delegate { SwitchCanvas(canvas[4]); });
        buttons.logsUp2.onClick.AddListener(delegate { SwitchCanvas(canvas[2]); });
        buttons.logsUp3.onClick.AddListener(delegate { SwitchCanvas(canvas[3]); });
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
