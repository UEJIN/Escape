using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// タッチすると、キャンバスを切り換える
public class OnButtonDown_SwitchCanvas : MonoBehaviour
{

    public GameObject NowCanvas;  // シーン名：Inspectorで指定
    public GameObject NextCanvas;  // シーン名：Inspectorで指定
    public float DelayTime = 5f;
    ButtonState SceneMoveButton;


    void OnEnable()
    {
        SceneMoveButton = this.gameObject.GetComponent<ButtonState>();
    }

    void FixedUpdate()
    { // タッチしたら
      // シーンを切り換える
        Invoke("SwitchCanvas", DelayTime);
        //SwitchCanvas();
    }

    void SwitchCanvas()
    {
        if (SceneMoveButton.IsDown() == true)
        {
            NowCanvas.SetActive(false);
            NextCanvas.SetActive(true);
        }
    }
}
