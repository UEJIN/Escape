using System.Collections;
using UnityEngine;
using System;


public class ScreenShot : MonoBehaviour
{

	int screenshotCount;
	Coroutine burstCapture;

	//1��̘A�ʂ̎B�e������B
	int burstCaptureCountMax = 100;
	//�A�ʂ̃C���^�[�o���B���̂܂܂̐ݒ肾�Ɩ��t���[���ɂȂ�B
	float burstCaptureInterval = 0.01f;

	void Awake()
	{

		//�V�[���ׂ��ɑΉ��B
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

		//�ꎞ��~�ƍĊJ��؂�ւ��B
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