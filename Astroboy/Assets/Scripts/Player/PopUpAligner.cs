using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpAligner : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcamTarget;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Image button;

    [SerializeField] private float offsetTextToImage = 0.5f;

    private RectTransform parentTransform;
    
    private float UIHeight = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        AlignWithCamera();
        AlignUIElements();
    }

    private void AlignWithCamera()
    {
        transform.LookAt(vcamTarget.transform);
    }

    private void AlignUIElements()
    {
        text.rectTransform.anchoredPosition = new Vector2(-text.preferredWidth / 2, 0);
        text.rectTransform.sizeDelta = new Vector2(text.preferredWidth, UIHeight);
        button.rectTransform.anchoredPosition = new Vector2(-0.5f - text.rectTransform.sizeDelta.x - offsetTextToImage, 0);
        parentTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x + button.rectTransform.sizeDelta.x + offsetTextToImage, UIHeight);
    }
}
