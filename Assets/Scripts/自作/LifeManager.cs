using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

// 挟まれると、表示する
public class LifeManager : MonoBehaviour {
	[ShowNonSerializedField]
	public static int LifeNum = 1;   // ライフカウンター、ここの初期値はデバッグ用の初期値
	[ShowNonSerializedField]
	public static int IniLife = 3;	//タイトル画面でこの値にリセットされる
	public string groundTag = "ground";  // 地面判定タグ：Inspectorで指定
	public string ceilingTag = "ceiling";       // 天井判定タグ：Inspectorで指定
	bool groundFlag = false;
	public bool isFinish = false;

	void Start() 
	{ // 最初に行う

	}
	void Update()
    {
		if(LifeNum == 0)
        {
            //Time.timeScale = 0; //時間を止める
        }
    }

	void OnTriggerStay2D(Collider2D collision)	
	{ 
		//接地判定
		if (collision.gameObject.CompareTag(groundTag))
		{
			groundFlag = true;
		}

		if (isFinish == false)
		{
			//接地かつ天井接触
			if (groundFlag && collision.gameObject.CompareTag(ceilingTag))
			{
				LifeNum--; // ライフを一つ消す
				isFinish = true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collision)	
	{ // 接地OFF
					groundFlag = false;
	}
	

}
