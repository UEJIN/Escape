using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//jsonを扱うのに必要

[System.Serializable]//jsonで扱うために必要
public class SaveData
{
    //セーブするデータの一覧
    //情報の本体は他で保持。ここではデータ元から持ってきたデータを保存できる形にして保存する。　５６

    //プレイヤーのステータス
    public int Life;
    public int Attack;
    public int Defense;
    public int GachaPoint;

    public float Volume = 1f;

    //アイテム関連
    public bool[] isPossession;
    public bool[] isEquip;


}


public class SaveLoadManager : MonoBehaviour
{
    string filePath;
    [SerializeField]
    SaveData saveData;

    void Awake()
    {
        //ダブったら削除
        int n = FindObjectsOfType<SaveLoadManager>().Length;
        if (n > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            //非破壊オブジェクトにしておく
            DontDestroyOnLoad(gameObject);


            //jsonデータのロード/////////////////////////////////////////////////////////////

            //保存場所の設定　エディターで起動したときはアセットフォルダ直下に保存場所を変える
#if UNITY_EDITOR
            filePath = Application.dataPath + "/savedata.json";
#else
            filePath = Application.persistentDataPath + "/savedata.json";
#endif

            Debug.Log("JsonFilePass : " + filePath);

            //セーブデータを受け取るインスタンス
            saveData = new SaveData();

            //セーブデータjsonのロード
            Load();
        }
    }

    void Start()
    {
        //ロードしたデータの反映////////////////////////////////////////////////////
        SaveDataApply();
        
    }

    // Update is called once per frame
    void Update()
    {
        //音量を代入
        saveData.Volume = AudioListener.volume; //なぜか終了時だと1になってしまうのでここで取得
    }

    
    private void OnApplicationQuit()  //アプリケーション終了時(androidで、タスクビュー画面から終了すると呼ばれない)
    {
        //セーブしたいデータのピックアップ/////////////////////////////////////////////////

        SaveDataSet();

        //json形式にしてデータを保存///////////////////////////////////////////////////////

        Save();
    }


    private void OnApplicationPause(bool pauseStatus)    //アプリケーションポーズ時(タスクビューから終了したとき対策)
    {
        if (pauseStatus)//ポーズtrue時
        {
            //DebugLog("<color=red>バックグラウンド行った</color>");

            //セーブしたいデータのピックアップ/////////////////////////////////////////////////

            SaveDataSet();

            //json形式にしてデータを保存///////////////////////////////////////////////////////

            Save();

        }
        else//ポーズでないとき
        {
            //Debug.Log("<color=red>復帰した</color>");
        }
    }

    public void SaveDataSet() //セーブしたいデータのピックアップ/////////////////////////////////////////////////
    {
        

        //テスト用
        saveData.Life = 100;
        saveData.Attack = 20;
        saveData.Defense = 7;

        //ガチャポイントを反映
        saveData.GachaPoint = GachaManager.GachaPoint;

        //配列の要素数を決めておく→いずれリストに変えたい
        saveData.isPossession = new bool[PlayersItem.ItemList.Length];
        saveData.isEquip = new bool[PlayersItem.ItemList.Length];

        saveData.isPossession = PlayersItem.isPossession;
        saveData.isEquip = PlayersItem.isEquip;

        //音量を代入(何故かここではうまく機能しない)
        //saveData.Volume = AudioListener.volume;

    }

    public void SaveDataApply() //ロードしたデータの反映////////////////////////////////////////////////////
    {
        //ガチャポイントを反映
        GachaManager.GachaPoint = saveData.GachaPoint;

        //前回の音量を反映
        AudioListener.volume = saveData.Volume;

        //アイテムの所持・装備フラグを反映
        for (int i = 0; i < PlayersItem.ItemList.Length; i++)
        {
            PlayersItem.ItemList[i].GetComponent<ItemData>().isPossession = saveData.isPossession[i];
            PlayersItem.ItemList[i].GetComponent<ItemData>().isEquip = saveData.isEquip[i];
        }
    }

    
    public void Save()  //SaveDataインスタンスをjsonにして保存
    {
        string jsonstr = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath, false);
        streamWriter.Write(jsonstr);
        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Save");
    }

    
    public void Load()  //jsonをSaveDataインスタンスにロード
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string datastr = streamReader.ReadToEnd();
            streamReader.Close();

            saveData = JsonUtility.FromJson<SaveData>(datastr);
            Debug.Log("Load");
        }
        
    }



}
