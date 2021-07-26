using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagerを使うのに必要
using UnityEngine.SceneManagement;

public class DontDestroyBGM : MonoBehaviour
{
    public string DefaultSceneName = "MainScene";

    //SampleScene1という名前のシーンを取得
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
            //このGameObjectをSampleScene1に移動
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(DefaultSceneName));

        }
        
    }
}
