using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpAligner : MonoBehaviour
{
    [SerializeField] private Camera vcamTarget = null;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Image button;

    [SerializeField] private float offsetTextToImage = 0.5f;

    [SerializeField] private bool isOutside;

    private RectTransform parentTransform;

    private float UIHeight = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        parentTransform = GetComponent<RectTransform>();
        if (isOutside) parentTransform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOutside) AlignWithCamera();
        AlignUIElements();
    }

    private void AlignWithCamera()
    {
        if (!vcamTarget) return;
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
