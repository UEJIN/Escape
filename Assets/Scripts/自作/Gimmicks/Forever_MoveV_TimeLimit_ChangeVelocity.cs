using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと移動して、時間が経過すると変速する（垂直）
public class Forever_MoveV_TimeLimit_ChangeVelocity : MonoBehaviour {

	public float speed = 1; // スピード：Inspectorで指定
	public float speed2 = 0; //衝突後のスピード：Inspectorで指定
	public int TimiLimit = 50; // 移動時間：Inspectorで指定

	int count = 0; // カウンター用

	void Start () { // 最初に行う
		count = 0;  // カウンターをリセット
		
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		this.transform.Translate(0, speed / 50, 0); // 垂直移動する
		count = count + 1; // カウンターに1を足して
		if (count >= TimiLimit)
		{ // もし、maxCountになったら
			speed = speed2; // 速度を変更する
		}
		
	}
}
