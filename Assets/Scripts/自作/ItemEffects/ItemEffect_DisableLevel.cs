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
        ////アイテム情報を取得
        //itemData = GetComponent<ItemData>();

        ////親オブジェクトを記憶
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
            //装備してかつメインシーンなら（装備していないとメインシーンに持っていけない）
            if (SceneManager.GetActiveScene().name == "MainScene" && isFinish == false)
            {
                isFinish = true;

                //指定のレベルが有効なら無効化
                if (LevelManager.LevelObjects[DisableLevel].activeSelf)
                {
                    LevelManager.LevelObjects[DisableLevel].SetActive(false);
                }
            }

            //装備してかつなら（装備していないとメインシーンに持っていけない）
            if (SceneManager.GetActiveScene().name != "MainScene" && isFinish == true)
            {
                //次のステージで再起動させる
                isFinish = false;
            }

            //ライフゼロなら
            if (LifeManager.LifeNum == 0)
            {
                //もとに戻す

                ////シーンまたいだら破壊されるように戻しておく
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("MainScene"));
            }
    }

    void OnDisable()
    {

    }
}
