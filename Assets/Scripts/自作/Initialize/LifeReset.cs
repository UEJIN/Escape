using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LifeManager.LifeNum = LifeManager.IniLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
