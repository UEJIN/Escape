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

    //ガチャ結果アイテム名テキスト
    public Text ItemText;

    //ガチャ結果アイテムアイコン
    public Image GachaResultIcon;

    //最終結果アイテム
    private GameObject ResultItem;

    //レアリティ
    private string Rarity;

    //抽選後ガチャリスト
    GameObject[] GachaList;

    //NEWフラグ
    private bool isNewItem;

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
                isNewItem = true;//持ってなければnew
            }
            else
            {
                isNewItem = false;//持っていればなし
            }

            //ガチャ演出

            //ガチャ結果表示
            //結果テキスト
            if (isNewItem)
            {
                ItemText.color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 255f/255f);
                ItemText.text = "NEW 【" + Rarity + "】" + ResultItem.GetComponent<ItemData>().GetItemName();
            }
            else
            {
                ItemText.color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255f / 255f);
                ItemText.text = "【" + Rarity + "】" + ResultItem.GetComponent<ItemData>().GetItemName();
            }
            //結果アイコン
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
        //レアリティを抽選
        Rarity = ChoseRarity();

        //レアリティの該当アイテムリストを取得
        if (Rarity == "SSR")
        {
            GachaList = SSRitems;
        }
        else if (Rarity == "SR")
        {
            GachaList = SRitems;
        }
        else if (Rarity == "R")
        {
            GachaList = Ritems;
        }
        else if (Rarity == "N")
        {
            GachaList = Nitems;
        }

        //リストからランダムでアイテムを抽選して返す
        return GachaList[Random.Range(0, GachaList.Length)];
    }


    //レアリティの抽選
    private string ChoseRarity()
    {
        var randValue = Random.Range(0, 100);
        if (randValue <= SSRratio)
        {
            return "SSR";
        }
        if (randValue <= SSRratio + SRratio)
        {
            return "SR";
        }
        if (randValue <= SSRratio + SRratio + Rratio)
        {
            return "R";
        }
        return "N";
    }



}
