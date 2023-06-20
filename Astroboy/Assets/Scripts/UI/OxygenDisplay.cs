using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenDisplay : MonoBehaviour
{
    private Image oxygenBar;

    private TextMeshProUGUI text;

    private float lastValue;

    private bool isFading;

    private bool isInside;
    // Start is called before the first frame update
    void Start()
    {
        oxygenBar = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        lastValue = DataStorage.instance.CurrOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        float currentOxygen = DataStorage.instance.CurrOxygen;
        float maxOxygen = DataStorage.instance.MaxOxygen;
        
        oxygenBar.transform.localScale = new Vector3(currentOxygen / maxOxygen, 1, 1);
        text.transform.localScale = new Vector3(1 / (currentOxygen / maxOxygen), 1, 1);

        if (currentOxygen >= maxOxygen && !isFading && isInside)
        {
            StartCoroutine(FadeImage(true));
            isFading = true;
        }
        else if (currentOxygen < maxOxygen && !isFading && !isInside)
        {
            print("Fading in");
            StartCoroutine(FadeImage(false));
            isFading = true;
        }

        if (currentOxygen > lastValue) isInside = true;
        if (currentOxygen < lastValue) isInside = false;
        lastValue = currentOxygen;
    }
    
    private IEnumerator FadeImage(bool fadeAway)
    {
        //if (!fadeAway) this.gameObject.SetActive(true);
        
        float targetAlpha = fadeAway ? 0 : 1;
        float startAlpha = oxygenBar.color.a;
        
        for (float t = 0; t <= 1; t += Time.deltaTime)
        {
            Color newColorDisplay = oxygenBar.color;
            newColorDisplay.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            Color newColorText = text.color;
            newColorText.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            oxygenBar.color = newColorDisplay;
            text.color = newColorText;
            yield return null;
        }

        //if (fadeAway) this.gameObject.SetActive(false);
        isFading = false;
    }
}
