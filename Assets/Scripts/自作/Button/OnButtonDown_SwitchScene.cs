using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// タッチすると、シーンを切り換える
public class OnButtonDown_SwitchScene : MonoBehaviour {

	public string sceneName;  // シーン名：Inspectorで指定
	public ButtonState SceneMoveButton;

	void Update() 
	{ // タッチしたら
	  // シーンを切り換える
		
		if (SceneMoveButton.IsDown() == true)
		{
            SceneManager.LoadScene(sceneName);
        }
    }
}
