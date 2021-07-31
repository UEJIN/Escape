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
        //アイテム情報を取得
        itemData = GetComponent<ItemData>();
        //親オブジェクトを記憶
        Parent = transform.root.gameObject;

        //新しく起動したとき重複したら破壊する（シーンまたいで保持するための処理）
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
        
        //装備状態の確認
        if (itemData.GetIsEquip() == true)
        {   //装備してたら

            //親離れ
            transform.parent = null;
            //シーンまたいでも保持されるようにしておく（rootにあるオブジェクトにしかつかえないので親離れ必要）
            DontDestroyOnLoad(gameObject);

            //装備してかつメインシーンなら（装備していないとメインシーンに持っていけない）
            if (SceneManager.GetActiveScene().name == "MainScene" && isFinish == false)
            {
                    isFinish = true;

                //効果
                    //ランダムなレベルの取得
                    RandomLevel = Random.Range(3, LevelManager.LevelObjects.Length - 1);
                    //ランダムなレベルを有効化
                    LevelManager.LevelObjects[RandomLevel].SetActive(true);
            }

            //装備してかつメインシーンなら（装備していないとメインシーンに持っていけない）
            if (SceneManager.GetActiveScene().name != "MainScene" && isFinish == true)
            {
                //次のステージで再起動させる
                isFinish = false;
            }

            if (LifeManager.LifeNum == 0)
            {
                ////シーンまたいだら破壊されるように戻しておく
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName("MainScene"));
            }
        }
        else
        {   //装備してなかったら

            //元の親にもどる
            transform.parent = Parent.transform;

        }



    }

    void OnDisable()
    {

    }
}
