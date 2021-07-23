using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// タッチすると、シーンを切り換える
public class OnButtonDown_DataDelete : MonoBehaviour {

	public ButtonState DeleteButton;

    void Update() 
	{ // タッチしたら
      // シーンを切り換える

        if (DeleteButton.IsDown() == true)
        {
            // 保存データの全てを削除する
            PlayerPrefs.DeleteAll();
        }
    }
	void FixedUpdate()
    {

	}
}
