using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挟まれると、表示する
public class OnCollision_Show_Pless : MonoBehaviour {

	public string showObjectName;   // 表示オブジェクト名：Inspectorで指定
	public string groundTag = "ground";  // 地面判定タグ：Inspectorで指定
	public string ceilingTag = "ceiling";       // 天井判定タグ：Inspectorで指定
	//LevelManager levelManager;

	bool groundFlag = false;

	GameObject showObject;

	void Start() { // 最初に行う
		// 消す前に表示オブジェクトを覚えておいて
		showObject = GameObject.Find(showObjectName);
		showObject.SetActive(false); // 消す
		//Time.timeScale = 1; //時間を動かす
	}

	void OnTriggerStay2D(Collider2D collision)	{ // 接地

        //Debug.Log(collision.gameObject.tag);
        Debug.Log("name:"+collision.gameObject.name+"tag:"+collision.gameObject.tag);

		if (collision.gameObject.CompareTag(groundTag)) {
			groundFlag = true;
			
			//Time.timeScale = 0; //時間を止める
		}
		if (groundFlag && collision.gameObject.CompareTag(ceilingTag)){ //接地かつ天井接触
			showObject.SetActive(true); // 消していたものを表示する
			Time.timeScale = 0; //時間を止める


		}
	}
	void OnTriggerExit2D(Collider2D collision)	{ // 接地OFF
					groundFlag = false;
	}
	

}
