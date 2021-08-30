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

    public float Volume = 1f;

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
            filePath = Application.persistentDataPath + "/savedata.json";
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
        SaveDataApply();
        
    }

    // Update is called once per frame
    void Update()
    {
        //���ʂ���
        saveData.Volume = AudioListener.volume; //�Ȃ����I��������1�ɂȂ��Ă��܂��̂ł����Ŏ擾
    }

    
    private void OnApplicationQuit()  //�A�v���P�[�V�����I����(android�ŁA�^�X�N�r���[��ʂ���I������ƌĂ΂�Ȃ�)
    {
        //�Z�[�u�������f�[�^�̃s�b�N�A�b�v/////////////////////////////////////////////////

        SaveDataSet();

        //json�`���ɂ��ăf�[�^��ۑ�///////////////////////////////////////////////////////

        Save();
    }


    private void OnApplicationPause(bool pauseStatus)    //�A�v���P�[�V�����|�[�Y��(�^�X�N�r���[����I�������Ƃ��΍�)
    {
        if (pauseStatus)//�|�[�Ytrue��
        {
            //DebugLog("<color=red>�o�b�N�O���E���h�s����</color>");

            //�Z�[�u�������f�[�^�̃s�b�N�A�b�v/////////////////////////////////////////////////

            SaveDataSet();

            //json�`���ɂ��ăf�[�^��ۑ�///////////////////////////////////////////////////////

            Save();

        }
        else//�|�[�Y�łȂ��Ƃ�
        {
            //Debug.Log("<color=red>���A����</color>");
        }
    }

    public void SaveDataSet() //�Z�[�u�������f�[�^�̃s�b�N�A�b�v/////////////////////////////////////////////////
    {
        

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

        //���ʂ���(���̂������ł͂��܂��@�\���Ȃ�)
        //saveData.Volume = AudioListener.volume;

    }

    public void SaveDataApply() //���[�h�����f�[�^�̔��f////////////////////////////////////////////////////
    {
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

    
    public void Save()  //SaveData�C���X�^���X��json�ɂ��ĕۑ�
    {
        string jsonstr = JsonUtility.ToJson(saveData);

        StreamWriter streamWriter = new StreamWriter(filePath, false);
        streamWriter.Write(jsonstr);
        streamWriter.Flush();
        streamWriter.Close();
        Debug.Log("Save");
    }

    
    public void Load()  //json��SaveData�C���X�^���X�Ƀ��[�h
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
