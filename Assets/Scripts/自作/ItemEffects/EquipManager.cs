using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{

    private GameObject[] EquipmentList;
    private Sprite icon;
    private string itemEffect;
    public GameObject[] equipSlots;
    public Text CostText;
    public int EquipMax = 5;
    private int TotalCost = 0;
    private int CalcCost = 0;
    private static GameObject[] CopyEquipItem;     // 複製したオブジェクト。非破壊
    private static bool[] isDuplicate;             //複製完了フラグ

    //public PlayersItem playersItem;

    // Start is called before the first frame update
    void Start()
    {
        //配列の初期化
        if (isDuplicate == null)
        {
            isDuplicate = new bool[EquipMax];
            CopyEquipItem = new GameObject[EquipMax];
        }

    }

    // Update is called once per frame
    void Update()
    {
        SetEquip();
    }

    //装備アイコンを表示する
    public void SetEquip()
    {
       
        //装備リストを初期化していない、または装備リストが変更されたら
        if (EquipmentList == null || EquipmentList.Length != PlayersItem.EquipmentList.ToArray().Length)
        {
            //装備リストを更新する
            EquipmentList = PlayersItem.EquipmentList.ToArray();

            //非破壊に移動した装備をリセットする
            for (int i = 0; i < EquipMax; i++)
            {
                Destroy(CopyEquipItem[i]);
                isDuplicate[i] = false;
            }

            //装備アイコンを表示する。コストを計算する。   
            CalcCost = 0;
            for (int i = 0; i < EquipMax; i++)
            {
                 //存在する配列の数を超えたら終了
                if (EquipmentList.Length > i && EquipmentList[i] != null)
                {
                    //アイコン取得
                    icon = EquipmentList[i].GetComponent<ItemData>().GetIcon();
                    //装備スロットにアイコンを反映
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;

                    //コストを積算
                    CalcCost += EquipmentList[i].GetComponent<ItemData>().GetItemCost();

                    //アイテム効果取得
                    itemEffect = EquipmentList[i].GetComponent<ItemData>().GetItemEffect();
                    //装備スロットの横に効果を表示する
                    equipSlots[i].transform.GetChild(1).GetComponent<Text>().text = itemEffect;

                    //一度だけオブジェクトを複製し、親離れして、非破壊オブジェクトに設定する
                    if (isDuplicate[i] == false)
                    {
                        CopyEquipItem[i] = Instantiate(EquipmentList[i]) as GameObject;
                        CopyEquipItem[i].transform.parent = null;
                        DontDestroyOnLoad(CopyEquipItem[i]);
                        isDuplicate[i] = true;
                    }

                }
                else
                {
                    //装備されていないスロットは画像なしにしておく
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                    //装備スロットの効果を非表示する
                    equipSlots[i].transform.GetChild(1).GetComponent<Text>().text = "装備なし";

                    if (CopyEquipItem[i] != null)
                    {
                        Destroy(CopyEquipItem[i]);
                        isDuplicate[i] = false;
                    }

                }
            }

            //トータルコストを表示する
            TotalCost = CalcCost;
            CostText.text = "COST : " + TotalCost.ToString() + "/ 5";
        }
    }

    //トータルコストを取得する
    public int GetTotalCost()
    {
        return TotalCost;
    }


}
