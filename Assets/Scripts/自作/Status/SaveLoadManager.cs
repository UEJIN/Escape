using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    //プレイヤーのステータス
    public int Life;
    public int Attack;
    public int Defense;
    public bool[] isPossession;
    public bool[] isEquip;


    //アイテム関連

}


public class SaveLoadManager : MonoBehaviour
{
    // Start is called before the first frame update

    string filePath;
    [SerializeField]
    SaveData saveData;

    void Awake()
    {

#if UNITY_EDITOR
        filePath = Application.dataPath + "/savedata.json";
#else
        filePath = Application.persistentDataPath + "/" + ".savedata.json";
#endif
        Debug.Log(filePath);

        saveData = new SaveData();
        Load();
    }

    void Start()
    {
        //ロードの反映


        for (int i = 0; i < PlayersItem.ItemList.Length; i++)
        {
            PlayersItem.ItemList[i].GetComponent<ItemData>().isPossession = saveData.isPossession[i];
            PlayersItem.ItemList[i].GetComponent<ItemData>().isEquip = saveData.isEquip[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
       　//セーブデータのピックアップ
        
        saveData.Life = 100;
        saveData.Attack = 20;
        saveData.Defense = 7;

        saveData.isPossession = new bool[PlayersItem.ItemList.Length];
        saveData.isEquip = new bool[PlayersItem.ItemList.Length];

        for (int i = 0; i < PlayersItem.ItemList.Length; i++)
        {
            saveData.isPossession[i] = PlayersItem.ItemList[i].GetComponent<ItemData>().isPossession;
            saveData.isEquip[i] = PlayersItem.ItemList[i].GetComponent<ItemData>().isEquip;
        }
        Save();
    }


    public void Save()
    {
        string jsonstr = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath, false);
        streamWriter.Write(jsonstr);
        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Save");
    }

    public void Load()
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
