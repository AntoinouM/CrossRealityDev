using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        print(timeStart);
        fadeEffect.m_Priority = 11;
        print("Before while loop");
        
        // This is why it doesnt work. Time.time always == timeStart because same frame
        for (int i = 0; i < 5; i++)
        {
            print(Time.time - timeStart);
        }
        
        //Do it in coroutine, the while. German good
        
        /*while (Time.time - timeStart < fadeTime)
        {
            print(Time.time - timeStart);
        }*/
        fadeEffect.m_Priority = 0;
    }
}
