using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと移動して、時間が経過すると変速する（垂直）
public class PositionReset_TimeLimit : MonoBehaviour {

	public int TimiLimit = 50; // 時間：Inspectorで指定

	int count = 0; // カウンター用
	private Vector3 iniPos;

	void Start () { // 最初に行う
		count = 0;  // カウンターをリセット
		iniPos = transform.position;
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		
		count = count + 1; // カウンターに1を足して
		if (count >= TimiLimit)
		{ // もし、maxCountになったら
			transform.position = iniPos; //位置をリセット
		}
		
	}
}
