using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// タッチすると、ゲームをストップする
public class OnMouseDown_StartGame : MonoBehaviour {

	void Start () { // 最初に行う
		
	}

	void OnMouseDown() { // タッチしたら
		Time.timeScale = 1; // 時間を動かす
	}
}
