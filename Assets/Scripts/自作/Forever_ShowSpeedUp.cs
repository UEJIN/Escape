using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ずっと、カウントの値を表示する
public class Forever_ShowSpeedUp: MonoBehaviour {

	public string showtext1= "Speed Up";
	public string showtext2 = "Max Speed";

	void Update() { // ずっと


		if (GameSpeedUp.GameSpeed >= GameSpeedUp.MaxSpeed)
		{
			// カウンターの値を表示する
			GetComponent<Text>().text = showtext2;
		}
		else if (GameSpeedUp.GameSpeed > 1.0f)
		{
			// カウンターの値を表示する
			GetComponent<Text>().text = showtext1;
		}


	}
}
