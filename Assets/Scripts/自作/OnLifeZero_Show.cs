using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挟まれると、表示する
public class OnLifeZero_Show : MonoBehaviour {

    public string showObjectName;   // 表示オブジェクト名：Inspectorで指定
    public string groundTag = "ground";  // 地面判定タグ：Inspectorで指定
	public string ceilingTag = "ceiling";       // 天井判定タグ：Inspectorで指定
    GameObject showObject;

    void Start() { // 最初に行う
                   // 消す前に表示オブジェクトを覚えておいて
        showObject = GameObject.Find(showObjectName);
		showObject.SetActive(false); // 消す
	}

	void Update()
	{
		if (LifeManager.LifeNum == 0)
		{
			showObject.SetActive(true); // 消していたものを表示する

		}

	}
	
}
