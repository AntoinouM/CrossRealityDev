using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


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

    public void Sleep(float fadeTime)
    {
        print("Starting to sleep");
        float timeStart = Time.time;
        fadeEffect.m_Priority = 11;
        print("Before while loop");
        while (Time.time - timeStart < fadeTime)
        {
            print(Time.time - timeStart);
        }
        fadeEffect.m_Priority = 0;
    }
}
