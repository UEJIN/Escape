using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        GameSpeedUp.GameSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
