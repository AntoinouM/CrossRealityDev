using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    TextMeshProUGUI txt;
    Color baseColor;
    Button btn;
    bool interactableDelay;

    void Start ()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
        baseColor = txt.color;
        btn = gameObject.GetComponent<Button>();
        interactableDelay = btn.interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        txt.color = new Color(0.95f, 0.54f, 0.82f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //btn.image.color = new Color(0.4f, 0.1f, 0.6f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //btn.image.color = new Color(0.4f, 0.1f, 0.6f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        txt.color = baseColor;
    }
}
