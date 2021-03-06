using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挟まれると、表示する
public class OnLifeZero_Show : MonoBehaviour {

    public string showObjectName;   // 表示オブジェクト名：Inspectorで指定
	public float DelayTime = 0.5f;
	bool isFinish;
    GameObject showObject;

    void Start() { // 最初に行う
                   // 消す前に表示オブジェクトを覚えておいて
        showObject = GameObject.Find(showObjectName);
		showObject.SetActive(false); // 消す
	}

	void Update()
	{
		if (!isFinish && LifeManager.LifeNum == 0)
		{
			isFinish = true;
			Invoke("ShowwObject", DelayTime);//秒後に呼び出す

		}

	}
	void ShowwObject()
    {
		showObject.SetActive(true); // 消していたものを表示する
	}
}
