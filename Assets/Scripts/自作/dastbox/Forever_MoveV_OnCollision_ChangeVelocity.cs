using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと移動して、衝突すると変速する（垂直）
public class Forever_MoveV_OnCollision_ChangeVelocity : MonoBehaviour {

	public float speed = 1; // スピード：Inspectorで指定
	public float speed2 = 0; //衝突後のスピード：Inspectorで指定

	Rigidbody2D rbody;

	void Start () { // 最初に行う
		// 重力を0にして、衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		rbody.gravityScale = 0;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// 垂直に移動する
		rbody.velocity = new Vector2(0, speed); 
	}

	void OnCollisionEnter2D(Collision2D collision) { // 衝突したとき
		speed = speed2;	// 進む向きを反転する
		// 進む向きで上下の向きを変える
		this.GetComponent<SpriteRenderer>().flipY = (speed < 0); 
	}
}
