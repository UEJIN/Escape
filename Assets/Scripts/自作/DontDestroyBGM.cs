using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManager���g���̂ɕK�v
using UnityEngine.SceneManagement;

public class DontDestroyBGM : MonoBehaviour
{
    public string DefaultSceneName = "MainScene";

    //SampleScene1�Ƃ������O�̃V�[�����擾
    //Scene DefaultScene;

    private void Awake()
    {
        //DefaultScene = SceneManager.GetSceneByName(DefaultSceneName);
        int n = FindObjectsOfType<DontDestroyBGM>().Length;
        if (n > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(LifeManager.LifeNum == 0)
        {
            //����GameObject��SampleScene1�Ɉړ�
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(DefaultSceneName));

        }
        
    }
}
