using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackDisplay : MonoBehaviour
{

    public static BackpackDisplay instance;

    [field: SerializeField]
    public Image[] backpackSpace
    {
        get;
        private set;
    }
    
    [field: SerializeField]
    public Sprite empty
    {
        get;
        private set;
    }
    
    [field: SerializeField]
    public Sprite full
    {
        get;
        private set;
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void PickUpItem(int backpackSpaceNeeded)
    {
        foreach (var slot in backpackSpace)
        {
            if (slot.sprite == empty)
            {
                slot.sprite = full;
                backpackSpaceNeeded--;
            }

            if (backpackSpaceNeeded == 0) return;
        }
    }

    public void ReleaseItems()
    {
        foreach (var slot in backpackSpace)
        {
            slot.sprite = empty;
        }
    }
}
