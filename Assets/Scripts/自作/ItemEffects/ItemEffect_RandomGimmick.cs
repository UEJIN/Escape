using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEffect_RandomGimmick : MonoBehaviour
{
    private ItemData itemData;
    public string DefaultSceneName = "StartScene";
    private GameObject Parent;
    private bool isFinish = false;

    private int RandomLevel;
  

    private void Awake()
    {
        //�A�C�e�������擾
        itemData = GetComponent<ItemData>();
        //�e�I�u�W�F�N�g���L��
        Parent = transform.root.gameObject;

        //�V�����N�������Ƃ��d��������j�󂷂�i�V�[���܂����ŕێ����邽�߂̏����j
        int n = FindObjectsOfType<ItemEffect_RandomGimmick>().Length;
        if (n > 1)
        {
            Destroy(gameObject);
        }

    }


    // Start is called before the first frame update
    void OnEnable()
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

                //����
                    //�����_���ȃ��x���̎擾
                    RandomLevel = Random.Range(3, LevelManager.LevelObjects.Length - 1);
                    //�����_���ȃ��x����L����
                    LevelManager.LevelObjects[RandomLevel].SetActive(true);
            }

            //�������Ă����C���V�[���Ȃ�i�������Ă��Ȃ��ƃ��C���V�[���Ɏ����Ă����Ȃ��j
            if (SceneManager.GetActiveScene().name != "MainScene" && isFinish == true)
            {
                //���̃X�e�[�W�ōċN��������
                isFinish = false;
            }

            if (LifeManager.LifeNum == 0)
            {
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
