using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour
{
	public string LifeText = "LIFE x ";
	LifeManager lifeManager;


	void Start()
	{ // 最初に行う
		
	}
	void Update()
	{
		GetComponent<Text>().text = LifeText + LifeManager.LifeNum;
	}
}
