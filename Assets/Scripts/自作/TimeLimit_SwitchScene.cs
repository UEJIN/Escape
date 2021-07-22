using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// 衝突すると、シーンを切り換える
public class TimeLimit_SwitchScene : MonoBehaviour {

	public int TimeLimit; // 目標オブジェクト名：Inspectorで指定
	public string sceneName;  // シーン名：Inspectorで指定

	int count = 0; // カウンター用

	void Start()
	{ // 最初に行う
		count = 0;  // カウンターをリセット
	}

	void FixedUpdate()
	{ // ずっと行う（一定時間ごとに）

		count = count + 1; // カウンターに1を足して


	}
	void Update()
    {
		if (count >= TimeLimit)
		{ // もし、maxCountになったら
			SceneManager.LoadScene(sceneName); //シーン移動
		}

	}
}
