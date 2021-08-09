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
    private GameObject[] CopyEquipItem;
    private bool[] isFinish;

    //public PlayersItem playersItem;

    // Start is called before the first frame update
    void Start()
    {
        isFinish = new bool[EquipMax];
        CopyEquipItem = new GameObject[EquipMax];
    }

    // Update is called once per frame
    void Update()
    {
        SetEquip();
    }

    void OnDisable()
    {

    }

    public void SetEquip()
    {
         //装備リストが変更されたら
        if (EquipmentList != PlayersItem.EquipmentList)
        {
            //装備リストを更新する
            EquipmentList = PlayersItem.EquipmentList;

            //非破壊に移動した装備をリセットする
            for (int i = 0; i < EquipMax; i++)
            {
                Destroy(CopyEquipItem[i]);
                isFinish[i] = false;
            }

            //装備アイコンを表示する。コストを計算する。   
            CalcCost = 0;
            for (int i = 0; i < EquipMax; i++)
            {

                if (EquipmentList[i] != null)
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

                    //オブジェクトを複製し、親離れして、非破壊オブジェクトに設定する
                    if (isFinish[i] == false)
                    {
                        CopyEquipItem[i] = Instantiate(EquipmentList[i]) as GameObject;
                        CopyEquipItem[i].transform.parent = null;
                        DontDestroyOnLoad(CopyEquipItem[i]);
                        isFinish[i] = true;
                    }

                }
                else
                {
                    //装備されていないスロットは画像なしにしておく
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                    
                    if(CopyEquipItem[i] != null)
                    {
                        Destroy(CopyEquipItem[i]);
                        isFinish[i] = false;
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
