using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挟まれると、表示する
public class OnLifeZero_GetGachaPoint : MonoBehaviour 
{

	public int GetPoint;
	bool isFinish;

    void Start() 
	{

	}

	void Update()
	{
		if (!isFinish && LifeManager.LifeNum == 0)
		{
			isFinish = true;
			GetPoint = StageCounter.value * DifficultyManager.Difficulty;
			GachaManager.GachaPoint += GetPoint;
			Debug.Log("GetPoint:" + GetPoint);
		}

	}

}
