using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeReset : MonoBehaviour
{
    public int IniLife = 1;
    // Start is called before the first frame update
    void Start()
    {
        LifeManager.LifeNum = IniLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
