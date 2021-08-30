using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 挟まれると、表示する
public class OnLifeZero_GetGachaPoint : MonoBehaviour 
{
	public GameObject showObject;   // 表示オブジェクト名：Inspectorで指定
	public GameObject showObject2;
	public float DelayTime = 0.5f;
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
			Invoke("ShowwObject", DelayTime);//秒後に呼び出す

		}

	}

	void ShowwObject()
	{

		showObject.GetComponent<Text>().text = "Gacha Point + " + GetPoint;
		showObject2.GetComponent<Text>().text = "Gacha Point + " + GetPoint;


	}

}
