//�v���C���[�̏����A�C�e���͂����ŊǗ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersItem : MonoBehaviour
{
    public static GameObject[] ItemList; 
    public static GameObject[] EquipmentList;
    public List<GameObject> PossessionList;
    public List<GameObject> TempPossessionList;

    //public List<GameObject> equipmentList;

    //�A�C�e�����X�g��Ԃ�

    void Awake()
    {
        CreateItemList();

        UpdatePossessionList();
        CreateEquipmentList();
    }

    void Update()
    {
        UpdatePossessionList();
        CreateEquipmentList();

        //Debug.Log("ItemList" + ItemList.Length);
        //Debug.Log("PossessionList" + PossessionList.ToArray().Length);
        //Debug.Log("EquipmentList" + EquipmentList.Length);
    }


    //�A�C�e�����X�g���쐬�i�ŏ��Ɉ�񂾂��j
    private void CreateItemList()
    {
        ItemList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            ItemList[i] = transform.GetChild(i).gameObject;
        }
    }

    //�����i���X�g���X�V
    public void UpdatePossessionList()
    {
        //�����i���X�g�����X�V
        TempPossessionList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (ItemList[i].GetComponent<ItemData>().GetIsPossession())
            {
                TempPossessionList.Add(ItemList[i]);
            }

        }

        //�ύX������Δ��f
        if (PossessionList != TempPossessionList)
        {
            PossessionList = TempPossessionList;
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
        return EquipmentList;
    }

}