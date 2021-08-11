//プレイヤーの所持アイテムはここで管理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersItem : MonoBehaviour
{
    public static GameObject[] ItemList; 
    //public static GameObject[] EquipmentList;
    public static List<GameObject> PossessionList;
    public List<GameObject> TempPossessionList;
    public static List<GameObject> EquipmentList;
    public List<GameObject> TempEquipmentList;
    public static bool[] isPossession;
    public static bool[] isEquip;

    //public List<GameObject> equipmentList;

    //アイテムリストを返す

    void Awake()
    {
        CreateItemList();
        LoadPossesionEquipFlag();
        UpdatePossessionList();
        CreateEquipmentList();
    }

    void Update()
    {
        UpdatePossessionList();
        CreateEquipmentList();
        SavePossesionEquipFlag();

    }


    //アイテムリストを作成（最初に一回だけ）
    private void CreateItemList()
    {
        ItemList = new GameObject[transform.childCount];
     
        for (int i = 0; i < transform.childCount; i++)
        {
            ItemList[i] = transform.GetChild(i).gameObject;
        }

    }

    private void LoadPossesionEquipFlag()
    {
        if (isPossession == null)   // 初期化
        {//配列の要素数を決めておく→いずれリストに変えたい
            isPossession = new bool[ItemList.Length];
            isEquip = new bool[ItemList.Length];
        }
        else
        {
            //アイテムの所持。装備フラグを再読み込み。シーンをまたいで戻ってきたとき用の処理
            for (int i = 0; i < ItemList.Length; i++)
            {
                ItemList[i].GetComponent<ItemData>().isPossession = isPossession[i];
                ItemList[i].GetComponent<ItemData>().isEquip = isEquip[i];
            }
        }
    }

    private void SavePossesionEquipFlag()
    {
        if (isPossession == null)
        {//配列の要素数を決めておく→いずれリストに変えたい
            isPossession = new bool[ItemList.Length];
            isEquip = new bool[ItemList.Length];
        }
        else
        {
            //アイテムの所持。装備フラグを一時保存。シーンをまたぐとき用に一時的にstaticに保持しておく
            for (int i = 0; i < ItemList.Length; i++)
            {
                isPossession[i] = ItemList[i].GetComponent<ItemData>().isPossession;
                isEquip[i] = ItemList[i].GetComponent<ItemData>().isEquip;
            }
        }
    }


    //所持品リストを更新
    public void UpdatePossessionList()
    {
        //所持品リストを仮更新
        TempPossessionList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (ItemList[i].GetComponent<ItemData>().GetIsPossession())
            {
                TempPossessionList.Add(ItemList[i]);
            }

        }

        //変更があれば反映
        if (PossessionList != TempPossessionList)
        {
            PossessionList = TempPossessionList;
        }


    }
    
    //所持品リストを更新
    public void CreateEquipmentList()
    {
        //装備リストを仮更新
        TempEquipmentList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (ItemList[i].GetComponent<ItemData>().GetIsEquip())
            {
                TempEquipmentList.Add(ItemList[i]);
            }

        }

        //変更があれば反映
        if (EquipmentList != TempEquipmentList)
        {
            EquipmentList = TempEquipmentList;
        }


    }
    //public void CreateEquipmentList()
    //{
    //    int a = 0;
    //    EquipmentList = new GameObject[transform.childCount];

    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        if (ItemList[i].GetComponent<ItemData>().GetIsEquip())
    //        {
    //            EquipmentList[a] = ItemList[i];
    //            a++;
    //        }

    //    }

    //}

    public GameObject[] GetItemList()
    {
        return ItemList;
    }

    public GameObject[] GetPossessionList()
    {
        return PossessionList.ToArray();
    }

    public GameObject[] GetEquipmentList()
    {
        return EquipmentList.ToArray();
    }

}