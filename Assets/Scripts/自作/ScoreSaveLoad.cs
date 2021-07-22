 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class ScoreSaveLoad : MonoBehaviour
{
    //ハイスコアの保存
    public GameObject score_object = null; // Text表示オブジェクト
    //public int score_num = 0; // スコア変数

    // 初期化時の処理
    void Start()
    {
        // スコアを保存
        if (StageCounter.value > PlayerPrefs.GetInt("SCORE", 0)) 
        {
            PlayerPrefs.SetInt("SCORE", StageCounter.value);
            PlayerPrefs.Save();
        }
        Debug.Log("sukoa2_" + PlayerPrefs.GetInt("SCORE", 0));
    }

    // 削除時の処理
    void OnDestroy()
    {
        //// スコアを保存
        //if(StageCounter.value > PlayerPrefs.GetInt("SCORE", 0));
        //{
        //    PlayerPrefs.SetInt("SCORE", StageCounter.value);
        //PlayerPrefs.Save();
        //}
    }

    // 更新
    void Update()
    {
       // スコアのロード
       //Text score_text = score_object.GetComponent<Text>();
       // score_text.text = "HighScore:" + PlayerPrefs.GetInt("SCORE", 0).ToString();

        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "HighScore:" + PlayerPrefs.GetInt("SCORE", 0).ToString();

        //score_num += 1; // とりあえず1加算し続けてみる
    }
}

