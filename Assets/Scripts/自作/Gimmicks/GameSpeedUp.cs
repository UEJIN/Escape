using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedUp : MonoBehaviour
{
    public static float GameSpeed = 1f;
    public float PlusSpeed = 0.5f;
    public float MaxSpeed = 4f;

    void OnEnable()
    {
        //初期値
        Time.timeScale = GameSpeed;
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        //もとに戻す
        Time.timeScale = 1f;

        //次読んだときはスピードアップした状態
        GameSpeed += PlusSpeed;

        //上限で止まる
        if (GameSpeed > MaxSpeed)
        {
            GameSpeed = MaxSpeed;
        }
    }
}
