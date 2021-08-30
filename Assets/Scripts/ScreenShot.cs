using System.Collections;
using UnityEngine;
using System;


public class ScreenShot : MonoBehaviour
{

	int screenshotCount;
	Coroutine burstCapture;

	//1回の連写の撮影上限数。
	int burstCaptureCountMax = 100;
	//連写のインターバル。このままの設定だと毎フレームになる。
	float burstCaptureInterval = 0.01f;

	void Awake()
	{

		//シーン跨ぎに対応。
		DontDestroyOnLoad(gameObject);
	}

	void Update()
	{

		if (Input.GetKeyDown("z"))
		{
			Capture();
		}

		if (Input.GetKeyDown("x"))
		{
			if (burstCapture != null)
			{
				StopCoroutine(burstCapture);
				burstCapture = null;
			}

			burstCapture = StartCoroutine("BurstCapture");
		}

		//一時停止と再開を切り替え。
		if (Input.GetKeyDown("q"))
		{
			if (Time.timeScale == 1.0f)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1.0f;
			}
		}
	}

	void Capture()
	{
		ScreenCapture.CaptureScreenshot(Screen.width.ToString("") + "x" + Screen.height.ToString("") + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
	}



	IEnumerator BurstCapture()
	{
		screenshotCount = 0;

		while (true)
		{

			Capture();
			screenshotCount++;

			if (burstCaptureCountMax < screenshotCount)
			{
				yield break;
			}

			yield return new WaitForSecondsRealtime(burstCaptureInterval);
		}
	}


}