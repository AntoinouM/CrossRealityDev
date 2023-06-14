using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class InteractionText : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcamTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(vcamTarget.transform);
        
    }
}
