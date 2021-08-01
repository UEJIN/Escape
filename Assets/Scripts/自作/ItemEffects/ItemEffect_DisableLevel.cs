using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEffect_DisableLevel : MonoBehaviour
{
    private ItemData itemData;
    public string DefaultSceneName = "StartScene";
    private GameObject Parent;
    private bool isFinish = false;

    [SerializeField]
    private int SlipLevel = 7;
    //LevelManager LevelManager;


    void Awake()
    {
        //�A�C�e�������擾
        itemData = GetComponent<ItemData>();

        //�e�I�u�W�F�N�g���L��
        Parent = transform.root.gameObject;

        ////�V�����N�������Ƃ��d��������j�󂷂�i�V�[���܂����ŕێ����邽�߂̏����j
        //int n = FindObjectsOfType<ItemEffect_DisableLevel>().Length;
        //if (n > 1)
        //{
        //    Destroy(gameObject);
        //}

    }

    // Start is called before the first frame update
    void OnEnable()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //������Ԃ̊m�F
        if (itemData.GetIsEquip() == true)
        {   //�������Ă���

            //�e����
            transform.parent = null;
            //�V�[���܂����ł��ێ������悤�ɂ��Ă����iroot�ɂ���I�u�W�F�N�g�ɂ��������Ȃ��̂Őe����K�v�j
            DontDestroyOnLoad(gameObject);

            //�������Ă����C���V�[���Ȃ�i�������Ă��Ȃ��ƃ��C���V�[���Ɏ����Ă����Ȃ��j
            if (SceneManager.GetActiveScene().name == "MainScene" && isFinish == false)
            {
                isFinish = true;

                //�w��̃��x�����L���Ȃ疳����
                if (LevelManager.LevelObjects[SlipLevel].activeSelf)
                {
                    LevelManager.LevelObjects[SlipLevel].SetActive(false);
                }
            }

            //�������Ă��Ȃ�i�������Ă��Ȃ��ƃ��C���V�[���Ɏ����Ă����Ȃ��j
            if (SceneManager.GetActiveScene().name != "MainScene" && isFinish == true)
            {
                //���̃X�e�[�W�ōċN��������
                isFinish = false;
            }

            //���C�t�[���Ȃ�
            if (LifeManager.LifeNum == 0)
            {
                //���Ƃɖ߂�

                ////�V�[���܂�������j�󂳂��悤�ɖ߂��Ă���
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("MainScene"));
            }

        }
        else
        {   //�������ĂȂ�������

            //���̐e�ɂ��ǂ�
            transform.parent = Parent.transform;
        }
    }

    void OnDisable()
    {

    }
}
