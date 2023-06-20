using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class CinemachineEffects : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera fadeEffect;
    
    public static CinemachineEffects instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sleep(float fadeTime, PlayerInput inputs)
    {
        StartCoroutine(ISleep(fadeTime, inputs));
    }
    
    private IEnumerator ISleep(float fadeTime, PlayerInput inputs)
    {
        print("Starting to sleep");
        float timeStart = Time.time;
        fadeEffect.m_Priority = 11;
        print("Before WaitForSeconds");

        yield return new WaitForSeconds(fadeTime);

        fadeEffect.m_Priority = 0;
        inputs.actions.Enable();
        UIController.instance.ChangeVisibility();
    }
}
