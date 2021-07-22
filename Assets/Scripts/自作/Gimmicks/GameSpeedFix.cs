using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedFix : MonoBehaviour
{
    public float GameSpeed = 2f;

    void OnEnable()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = GameSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
