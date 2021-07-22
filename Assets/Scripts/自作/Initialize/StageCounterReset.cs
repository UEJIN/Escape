using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCounterReset : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDisable()
    {
        StageCounter.value = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
