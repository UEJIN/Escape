//プレイヤーの所持アイテムはここで管理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersItem : MonoBehaviour
{
    public static GameObject[] ItemList; 
    public static GameObject[] PossessionList;
    public static GameObject[] EquipmentList;
    //public static List<GameObject> ItemList;
    //public static List<GameObject> PossessionList;
    //public static List<GameObject> EquipmentList;

    //アイテムリストを返す

    void Awake()
    {
        CreateItemList();
        CreatePossessionList();
        CreateEquipmentList();
    }

    void Update()
    {
        CreatePossessionList();
        //CreateEquipmentList();
        //Debug.Log("ItemList" + ItemList.Length);
        //Debug.Log("PossessionList" + PossessionList.Length);
        //Debug.Log("EquipmentList" + EquipmentList.Length);
    }

    //public GameObject[] GetItemList()
    //{
    //    return ItemList;
    //}

    private void CreateItemList()
    {
        ItemList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            ItemList[i] = transform.GetChild(i).gameObject;
        }
    }

    public void CreatePossessionList()
    {
        int a = 0;
        PossessionList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            if(ItemList[i].GetComponent<ItemData>().GetIsPossession())
            {
                PossessionList[a] = ItemList[i];
                a++;
            }
        }
        
    }

    public void CreateEquipmentList()
    {
        int a = 0;
        EquipmentList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            if (ItemList[i].GetComponent<ItemData>().GetIsEquip())
            {
                EquipmentList[a] = ItemList[i];
                a++;
            }
            
        }
        
    }

    public GameObject[] GetPossessionList()
    {
        //CreateItemList();
        //int a = 0;
        //PossessionList = new GameObject[transform.childCount];

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    if (ItemList[i].GetComponent<ItemData>().GetIsPossession())
        //    {
        //        PossessionList[a] = ItemList[i];
        //        a++;
        //    }
        //}

        return PossessionList;
    }

    public GameObject[] GetEquipmentList()
    {
        return EquipmentList;

    }

}