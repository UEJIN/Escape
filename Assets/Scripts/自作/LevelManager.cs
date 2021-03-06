using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 最初に天井を並べ替える
public class LevelManager : MonoBehaviour {

	public float yMargin = 14.5f; // 天井と床のマージン。inspectorで設定
	public int LevelRange = 1;
	public int AddPosX = 1; //横軸の移動量
    public GameObject[] CeilingOrder;
	public GameObject[] GroundOrder;
	public static GameObject[] LevelObjects; //LevelObject
	public GameObject LevelParent;
	public int MaxGoal = 3; //ゴールの最大数。easyのときのゴール数になる
	[SerializeField]
	Vector3 IniPosition = new Vector3(-8.5f, 7f, 0f); // 基準位置。inspectorで設定

	private int n = 0; //カウンタ
	private int GoalNum; //ゴールの位置
	Vector3 AddPosition = new Vector3(0, 0, 0); // 移動量

	public static　int level = 1; //現在のレベル
	public int Debuglevel = 1;//デバッグ用開始レベル
	public int DebugDifficulty = 1;//デバッグ用開始難易度
	void Awake()
	{
		//LevelObjects = GameObject.FindGameObjectsWithTag(LevelTag);//アクティブ状態の特定タグを配列化 
	}

	void OnEnable()
	{ // 最初に行う
	  //Debug.Log("level"+ level);
	  //Debug.Log("Stage"+StageCounter.value);		
		
		//Level自動配列化
		GetAllChildObject();

		//レベルの子オブジェクトを一度非アクティブ化
		for (n = 1; n < LevelObjects.Length; n++)
        {
            //Debug.Log("levelLength" + LevelObjects.Length);
            LevelObjects[n].SetActive(false);//レベルの子オブジェクトを一度非アクティブ化
        }
		//デバッグ用。このシーンから始めてたら以下の設定で開始する
		if (StageCounter.value == 0)
		{
			StageCounter.value++;
			level = Debuglevel;
			DifficultyManager.Difficulty = DebugDifficulty;
		}

		//Level1
		if (level == 1) 
		{
			for (n = 0; n < CeilingOrder.Length; n++) // タグの数だけ繰り返し
			{
				//天井を並べる
				AddPosition.x = n * AddPosX; //ｘの移動量にｎ*移動量を代入
				CeilingOrder[n].transform.position = IniPosition + AddPosition; //位置を決定
			}
			LevelObjects[level].SetActive(true);
			

		}
		//Level2以上
		else if (level >= 2) 
		{	
			if (level <= LevelObjects.Length - 1)//Levelが上限になっていなければ難易度を反映
			{
				LevelObjects[level - 1].SetActive(false);
				StageSoat();
				LevelObjects[level].SetActive(true);
			}
			else　//レベルが上限なら難易度を変更しない
			{
				StageSoat();
				LevelObjects[LevelObjects.Length - 1].SetActive(true);
			}

		}
			
		if (LevelRange * level == StageCounter.value)
		{
			level++;
		}

        CreatGoal();

    }

    void StageSoat()
	{
        for (n = 0; n < 18; n++) // タグの数だけ繰り返し
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
		AddPosition.x = 0;
		AddPosition.y = 1;
		//安置の設定、難易度に合わせて数を変更
		for (int i = 1; i <= MaxGoal - DifficultyManager.Difficulty + 1; i++)
        {
            GoalNum = Random.Range(0, CeilingOrder.Length - 1); //安置をランダムに決定
			CeilingOrder[GoalNum].transform.position += AddPosition; //安置を作成
        }
    }

	private void GetAllChildObject()
	{
		LevelObjects = new GameObject[LevelParent.transform.childCount];

		for (int i = 0; i < LevelParent.transform.childCount; i++)
		{
			LevelObjects[i] = LevelParent.transform.GetChild(i).gameObject;
		}
	}
}
