using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 最初に天井を並べ替える
public class ShuffleStage : MonoBehaviour {

	public string CeilingTag = "ceiling";
	public string GroundTag = "ground";
	public string LevelTag = "level";
	public float yMargin = 14.5f; // 天井と床のマージン。inspectorで設定
	public int StartLevel2 = 3;
	public int StartLevel3 = 6;
	public int StartLevel4 = 7;
	public int LevelRange = 1;

	public int AddPosX = 1; //横軸の移動量
	[SerializeField]
	Vector3 IniPosition = new Vector3(0, 0, 0); // 基準位置。inspectorで設定

	GameObject[] CeilingOrder;
	GameObject[] GroundOrder;
    GameObject[] LevelObjects; //LevelObject
    private int n = 0; //カウンタ
	private int GoalNum; //ゴールの位置
    private static　int level = 1; //現在のレベル
    Vector3 AddPosition = new Vector3(0, 0, 0); // 移動量

	void Awake()
	{
		LevelObjects = GameObject.FindGameObjectsWithTag(LevelTag);//特定タグを配列化 
		for (n = 1; n < LevelObjects.Length; n++)
		{
			LevelObjects[n].SetActive(false);//レベルの子オブジェクトを非アクティブ化
			
		}
	}

	void OnEnable()
	{ // 最初に行う
		
		CeilingOrder = GameObject.FindGameObjectsWithTag(CeilingTag);//特定タグを配列化
		GroundOrder = GameObject.FindGameObjectsWithTag(GroundTag);//特定タグを配列化
		
		Debug.Log(level);
		Debug.Log(StageCounter.value);

		if (level == 1) //Level1
		{
			for (n = 0; n < CeilingOrder.Length; n++) // タグの数だけ繰り返し
			{
				//天井を並べる
				AddPosition.x = n * AddPosX; //ｘの移動量にｎ*移動量を代入
				CeilingOrder[n].transform.position = IniPosition + AddPosition; //位置を決定
			}
			Debug.Log(level);
			//LevelObjects[level].SetActive(true);
			
			if (LevelRange * level == StageCounter.value)
			{
				level++;
			}
		}
		else if (level >= 2) //Level2以上
		{
			 //&& (LevelRange * (level - 1) <= StageCounter.value) && (StageCounter.value < LevelRange * level)
			LevelObjects[level - 1].SetActive(false);
			StageSoat();
			LevelObjects[level].SetActive(true);
			
			if (LevelRange * level == StageCounter.value)
			{
				level++;
			}
		}

		//if (StageCounter.value < StartLevel2) //Level1
		//{
		//    level = 1;
		//    for (n = 0; n < CeilingOrder.Length; n++) // タグの数だけ繰り返し
		//    {
		//        天井を並べる
		//        AddPosition.x = n * AddPosX; //ｘの移動量にｎ*移動量を代入
		//        CeilingOrder[n].transform.position = IniPosition + AddPosition; //位置を決定
		//    }
		//    LevelObjects[level].SetActive(true);
		//}
		//else if ((StartLevel2 <= StageCounter.value) && (StageCounter.value < StartLevel3)) //Level2
		//{
		//    level = 2;
		//    LevelObjects[level - 1].SetActive(false);
		//    StageSoat();
		//    LevelObjects[level].SetActive(true);

		//}
		//else if ((StartLevel3 <= StageCounter.value) && (StageCounter.value < StartLevel4)) //Level3
		//{
		//    level = 3;
		//    LevelObjects[level - 1].SetActive(false);
		//    StageSoat();
		//    LevelObjects[level].SetActive(true);

		//}

		CreatGoal();

	}

	void StageSoat()
	{
		for (n = 0; n < CeilingOrder.Length; n++) // タグの数だけ繰り返し
		{
			//天井を配置
			AddPosition.x = n * AddPosX; //ｘ位置を決定（ｘの移動量にｎ*移動量を代入
			AddPosition.y = Random.Range(-1, 2);//y位置をランダムに決定
			CeilingOrder[n].transform.position = IniPosition + AddPosition; //位置を反映

			//床を配置
			AddPosition.x = 0; //	床ｘは天井に合わせるので不要
			AddPosition.y = -1.0f * yMargin; //床ｙを天井からマージン分下げたところに配置
			GroundOrder[n].transform.position = CeilingOrder[n].transform.position + AddPosition;
		}
	}

	void CreatGoal()
	{
		//安置の設定
		GoalNum = Random.Range(0, CeilingOrder.Length - 1); //安置をランダムに決定
		AddPosition.x = 0;
		AddPosition.y = 1;
		CeilingOrder[GoalNum].transform.position += AddPosition; //安置を作成

	}
}
