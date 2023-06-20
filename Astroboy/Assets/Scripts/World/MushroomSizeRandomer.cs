using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSizeRandomer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            float rdmSize = Random.Range(1.5f, 5.5f);
            child.localScale = new Vector3(rdmSize, rdmSize, rdmSize);
        }
    }

}
