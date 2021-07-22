using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    private void Awake()
    {
        int n = FindObjectsOfType<DontDestroyBGM>().Length;
        if (n > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
