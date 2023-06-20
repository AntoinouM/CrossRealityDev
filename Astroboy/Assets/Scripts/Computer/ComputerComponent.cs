using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerComponent : MonoBehaviour
{
    [SerializeField] private Button screenOnBtn;
    [SerializeField] private Canvas[] canvas;

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
        screenOnBtn.onClick.AddListener(delegate { SwitchCanvas(canvas[1]); });
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
