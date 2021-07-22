using UnityEngine;
using System.Collections;

public class LinerMove : MonoBehaviour
{

	[SerializeField, Range(0, 10)]
	float time = 1;

	//[SerializeField]
	//Vector3	endPosition;

	[SerializeField]
	Vector3 movePosition;

	[SerializeField]
	AnimationCurve curve;

	private float startTime;
	public  Vector3 startPosition;
	private Vector3 endPosition;

	//void LinerMove(float x, float y, float z) //コンストラクタ
	//{
	//	movePosition = Vector3(x, y, z);

	//}

	void OnEnable ()
	{
		if (time <= 0) {
			transform.position = endPosition;
			enabled = false;
			return;
		}

		//startTime = Time.timeSinceLevelLoad;	
		startTime = 0;
        startPosition = transform.position;
        endPosition = transform.position + movePosition;
        //endPosition = startPosition + movePosition;

    }

    void Update ()
	{
		var diff = Time.timeSinceLevelLoad - startTime;
		if (diff > time) {
			transform.position = endPosition;
			enabled = false;
		}

		var rate = diff / time;
		var pos = curve.Evaluate(rate);
		
		transform.position = Vector3.Lerp (startPosition, endPosition, rate);
		transform.position = Vector3.Lerp (startPosition, endPosition, pos);
	}

    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR

		if( !UnityEditor.EditorApplication.isPlaying || enabled == false ){
			startPosition = transform.position;
			endPosition = transform.position + movePosition;
		}

		UnityEditor.Handles.Label(endPosition, endPosition.ToString());
		UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
		Gizmos.DrawSphere(endPosition, 0.1f);
        Gizmos.DrawSphere(startPosition, 0.1f);

        Gizmos.DrawLine(startPosition, endPosition);
    }
}