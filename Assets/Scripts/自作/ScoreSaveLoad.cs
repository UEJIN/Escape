 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class ScoreSaveLoad : MonoBehaviour
{
    //ハイスコアの保存
    GameObject score_object; // Text表示オブジェクト
    public string SaveName = "EasyScore";
    public int CheckDifficulty; // 対応する難易度

    // 初期化時の処理
    void Start()
    {
        score_object = this.gameObject;
    
        // ハイスコアならスコアを保存
        if (StageCounter.value > PlayerPrefs.GetInt(SaveName, 0) && DifficultyManager.Difficulty == CheckDifficulty) 
        {
            PlayerPrefs.SetInt(SaveName, StageCounter.value);
            PlayerPrefs.Save();
        }
        //Debug.Log(SaveName + PlayerPrefs.GetInt(SaveName, 0).ToString());
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
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "HighScore:" + PlayerPrefs.GetInt(SaveName, 0).ToString();

    }
}

