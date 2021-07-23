using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// タッチすると、シーンを切り換える
public class OnButtonDown_SwitchSceneAndDifficulty : MonoBehaviour {

	public string sceneName;  // シーン名：Inspectorで指定
	ButtonState SceneMoveButton;
    public int DifficultyNum;//変更先の難易度

    void OnEnable()
    {
        SceneMoveButton = this.gameObject.GetComponent<ButtonState>();
    }
    void Update() 
	{ // タッチしたら
      // シーンを切り換える

        if (SceneMoveButton.IsDown() == true)
        {
            DifficultyManager.Difficulty = DifficultyNum;
            SceneManager.LoadScene(sceneName);
        }
    }
	void FixedUpdate()
    {

	}
}
