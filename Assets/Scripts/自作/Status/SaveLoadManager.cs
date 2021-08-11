using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//json�������̂ɕK�v

[System.Serializable]//json�ň������߂ɕK�v
public class SaveData
{
    //�Z�[�u����f�[�^�̈ꗗ
    //���̖{�̂͑��ŕێ��B�����ł̓f�[�^�����玝���Ă����f�[�^��ۑ��ł���`�ɂ��ĕۑ�����B�@�T�U

    //�v���C���[�̃X�e�[�^�X
    public int Life;
    public int Attack;
    public int Defense;
    public int GachaPoint;

    public float Volume;

    //�A�C�e���֘A
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
        //�_�u������폜
        int n = FindObjectsOfType<SaveLoadManager>().Length;
        if (n > 1)
        {
            Destroy(gameObject);
        }
        else
        {

            //��j��I�u�W�F�N�g�ɂ��Ă���
            DontDestroyOnLoad(gameObject);


            //json�f�[�^�̃��[�h/////////////////////////////////////////////////////////////

            //�ۑ��ꏊ�̐ݒ�@�G�f�B�^�[�ŋN�������Ƃ��̓A�Z�b�g�t�H���_�����ɕۑ��ꏊ��ς���
#if UNITY_EDITOR
            filePath = Application.dataPath + "/savedata.json";
#else
            filePath = Application.persistentDataPath + "/" + ".savedata.json";
#endif

            Debug.Log("JsonFilePass : " + filePath);

            //�Z�[�u�f�[�^���󂯎��C���X�^���X
            saveData = new SaveData();

            //�Z�[�u�f�[�^json�̃��[�h
            Load();
        }
    }

    void Start()
    {
        //���[�h�����f�[�^�̔��f////////////////////////////////////////////////////

        //�K�`���|�C���g�𔽉f
        GachaManager.GachaPoint = saveData.GachaPoint;

        //�O��̉��ʂ𔽉f
        AudioListener.volume = saveData.Volume;

        //�A�C�e���̏����E�����t���O�𔽉f
        for (int i = 0; i < PlayersItem.ItemList.Length; i++)
        {
            PlayersItem.ItemList[i].GetComponent<ItemData>().isPossession = saveData.isPossession[i];
            PlayersItem.ItemList[i].GetComponent<ItemData>().isEquip = saveData.isEquip[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        //���ʂ���
        saveData.Volume = AudioListener.volume; //�Ȃ����I������1�ɂȂ��Ă��܂��̂ł����Ŏ擾
    }



    //�A�v���P�[�V�����I����
    private void OnApplicationQuit()
    {
     //�Z�[�u�������f�[�^�̃s�b�N�A�b�v/////////////////////////////////////////////////
        
        //�e�X�g�p
        saveData.Life = 100;
        saveData.Attack = 20;
        saveData.Defense = 7;

        //�K�`���|�C���g�𔽉f
        saveData.GachaPoint = GachaManager.GachaPoint;

        //�z��̗v�f�������߂Ă����������ꃊ�X�g�ɕς�����
        saveData.isPossession = new bool[PlayersItem.ItemList.Length];
        saveData.isEquip = new bool[PlayersItem.ItemList.Length];

        saveData.isPossession = PlayersItem.isPossession;
        saveData.isEquip = PlayersItem.isEquip;



        //���ʂ���
        //saveData.Volume = AudioListener.volume;

        //json�`���ɂ��ăf�[�^��ۑ�///////////////////////////////////////////////////////

        Save();
    }

    //SaveData�C���X�^���X��json�ɂ��ĕۑ�
    public void Save()
    {
        string jsonstr = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath, false);
        streamWriter.Write(jsonstr);
        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Save");
    }

    //json��SaveData�C���X�^���X�Ƀ��[�h
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
