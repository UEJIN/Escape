//�v���C���[�̏����A�C�e���͂����ŊǗ�
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

    //�A�C�e�����X�g��Ԃ�

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


    //�A�C�e�����X�g���쐬�i�ŏ��Ɉ�񂾂��j
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
        if (isPossession == null)   // ������
        {//�z��̗v�f�������߂Ă����������ꃊ�X�g�ɕς�����
            isPossession = new bool[ItemList.Length];
            isEquip = new bool[ItemList.Length];
        }
        else
        {
            //�A�C�e���̏����B�����t���O���ēǂݍ��݁B�V�[�����܂����Ŗ߂��Ă����Ƃ��p�̏���
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
        {//�z��̗v�f�������߂Ă����������ꃊ�X�g�ɕς�����
            isPossession = new bool[ItemList.Length];
            isEquip = new bool[ItemList.Length];
        }
        else
        {
            //�A�C�e���̏����B�����t���O���ꎞ�ۑ��B�V�[�����܂����Ƃ��p�Ɉꎞ�I��static�ɕێ����Ă���
            for (int i = 0; i < ItemList.Length; i++)
            {
                isPossession[i] = ItemList[i].GetComponent<ItemData>().isPossession;
                isEquip[i] = ItemList[i].GetComponent<ItemData>().isEquip;
            }
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
    
    //�����i���X�g���X�V
    public void CreateEquipmentList()
    {
        //�������X�g�����X�V
        TempEquipmentList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (ItemList[i].GetComponent<ItemData>().GetIsEquip())
            {
                TempEquipmentList.Add(ItemList[i]);
            }

        }

        //�ύX������Δ��f
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