using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    //各レアリティの排出率を手動で設定
    public float SSRratio = 2f;
    public float SRratio = 18f;
    public float Rratio= 30f;
    public float Nratio = 50f;

    //各レアリティのアイテムを手動で追加
    public GameObject[] SSRitems;
    public GameObject[] SRitems;
    public GameObject[] Ritems;
    public GameObject[] Nitems;

    //ガチャボタンを指定
    public ButtonState GachaButtonState;

    //ガチャ結果表示テキスト
    public Text ItemText;

    public Image GachaResultIcon;

    //最終結果アイテム
    private GameObject ResultItem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ガチャボタンが押されたら
        if(GachaButtonState.IsDown())
        {
            //ポイントを消費

            //アイテム決定
            ResultItem = ChoseGachaResult();
            //アイテムを取得状態にする
            if (ResultItem.GetComponent<ItemData>().isPossession == false)
            {
                ResultItem.GetComponent<ItemData>().isPossession = true;
            }
            //ガチャ演出

            //ガチャ結果表示
            ItemText.text = ResultItem.GetComponent<ItemData>().GetItemName();
            GachaResultIcon.sprite = ResultItem.GetComponent<ItemData>().GetIcon();
        }
    }
    
    //ガチャの内容物を初期化
    //private void InitGachaData()
    //{
    //    _gachaDataList = new[]
    //    {
    //        new GachaData("ョ", "Normal", Color.blue),
    //        new GachaData("ねこ", "Normal", Color.blue),
    //        ... (略) ...
    //    };
    //}

    private GameObject ChoseGachaResult()
    {
        //レアリティ抽選して該当のリストを取得
        GameObject[] GachaList = ChoseRarity();

        //リストからランダムでアイテムを抽選して返す
        return GachaList[Random.Range(0, GachaList.Length)];
    }

    private GameObject[] ChoseRarity()
    {
        var randValue = Random.Range(0, 100);
        if (randValue <= SSRratio)
        {
            return SSRitems;
        }
        if (randValue <= SSRratio + SRratio)
        {
            return SRitems;
        }
        if (randValue <= SSRratio + SRratio + Rratio)
        {
            return Ritems;
        }
        return Nitems;
    }


}
