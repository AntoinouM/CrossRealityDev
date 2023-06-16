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
            DontDestroyOnLoad(gameObject);
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
        float timeStart = Time.time;
        fadeEffect.m_Priority = 100;
        while (Time.time - timeStart < fadeTime) ;
        fadeEffect.m_Priority = 0;
    }
}
