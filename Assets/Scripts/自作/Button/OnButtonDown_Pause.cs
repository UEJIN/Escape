using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// タッチすると、キャンバスを切り換える
public class OnButtonDown_Pause : MonoBehaviour
{
    //public float DelayTime = 1f;
    ButtonState buttonState;


    void OnEnable()
    {
        buttonState = this.gameObject.GetComponent<ButtonState>();
    }

    void Update()
    { // タッチしたら
      // シーンを切り換える
        //Invoke("SwitchCanvas", DelayTime);
        SwitchCanvas();
    }

    void SwitchCanvas()
    {
        if (buttonState.IsDown() == true)
        {
            if (Time.timeScale != 0f)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

        }
    }
}
