using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour
{
	public string LifeText = "LIFE x ";
	LifeManager lifeManager;


	void Start()
	{ // ç≈èâÇ…çsÇ§
		
	}
	void Update()
	{
		GetComponent<Text>().text = LifeText + LifeManager.LifeNum;
	}
}
