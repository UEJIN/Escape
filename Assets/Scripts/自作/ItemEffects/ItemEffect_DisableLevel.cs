using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemEffect_DisableLevel : MonoBehaviour
{
    //private ItemData itemData;
    //public string DefaultSceneName = "StartScene";
    //private GameObject Parent;
    private bool isFinish = false;

    [SerializeField]
    private int DisableLevel;


    void Awake()
    {
        ////�A�C�e�������擾
        //itemData = GetComponent<ItemData>();

        ////�e�I�u�W�F�N�g���L��
        //Parent = transform.root.gameObject;

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
            //�������Ă����C���V�[���Ȃ�i�������Ă��Ȃ��ƃ��C���V�[���Ɏ����Ă����Ȃ��j
            if (SceneManager.GetActiveScene().name == "MainScene" && isFinish == false)
            {
                isFinish = true;

                //�w��̃��x�����L���Ȃ疳����
                if (LevelManager.LevelObjects[DisableLevel].activeSelf)
                {
                    LevelManager.LevelObjects[DisableLevel].SetActive(false);
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

    void OnDisable()
    {

    }
}
