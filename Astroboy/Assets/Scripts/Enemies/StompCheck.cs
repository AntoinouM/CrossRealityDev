using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    [SerializeField] private GameObject enemyFigure;
    private ParticleSystem _explosionPS;
    private bool _hasExploded = false;

    private bool _hasTriggered = false;

  
    private void Start()
    {
        _explosionPS = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_hasExploded && _explosionPS.isStopped)
        {
            //Destroy(transform.parent.gameObject);
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<EnemyHeadStompCheck>()) return;
        
        _explosionPS.Play();
        _hasExploded = true;

        //Destroy(enemyFigure, 0.1f);
        enemyFigure.SetActive(false);
        
        
        if (!_hasTriggered)
        {
            DeathSounds.instance.playDeathSound(transform.tag, this.gameObject);
        }
        else
        {
            return;
        } 

        _hasTriggered = true;

    }
}


