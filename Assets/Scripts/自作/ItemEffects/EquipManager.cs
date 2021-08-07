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

    // Start is called before the first frame update
    void Start()
    {
        SetEquip();
    }

    // Update is called once per frame
    void Update()
    {
        SetEquip();
        ////�������X�g���X�V����
        //EquipmentList = PlayersItem.EquipmentList;

        ////�����A�C�R����\������B�R�X�g���v�Z����B   
        //CalcCost = 0;
        //for (int i = 0; i < EquipMax; i++)
        //{

        //    if (EquipmentList[i] != null)
        //    {
        //        icon = EquipmentList[i].GetComponent<ItemData>().GetIcon();
        //        equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;

        //        CalcCost += EquipmentList[i].GetComponent<ItemData>().GetItemCost();

        //        itemEffect = EquipmentList[i].GetComponent<ItemData>().GetItemEffect();
        //        equipSlots[i].transform.GetChild(1).GetComponent<Text>().text = itemEffect;
        //    }
        //    else
        //    {
        //        equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
        //    }
        //}

        ////�g�[�^���R�X�g��\������
        //TotalCost = CalcCost;
        //CostText.text = "COST : " + TotalCost.ToString() + "/ 5";

    }

    public int GetTotalCost()
    {
        return TotalCost;
    }

    public void SetEquip()
    {
  
        if (EquipmentList != PlayersItem.EquipmentList)
        {
            //�������X�g���X�V����
            EquipmentList = PlayersItem.EquipmentList;

            //�����A�C�R����\������B�R�X�g���v�Z����B   
            CalcCost = 0;
            for (int i = 0; i < EquipMax; i++)
            {

                if (EquipmentList[i] != null)
                {
                    icon = EquipmentList[i].GetComponent<ItemData>().GetIcon();
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;

                    CalcCost += EquipmentList[i].GetComponent<ItemData>().GetItemCost();

                    itemEffect = EquipmentList[i].GetComponent<ItemData>().GetItemEffect();
                    equipSlots[i].transform.GetChild(1).GetComponent<Text>().text = itemEffect;
                }
                else
                {
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                }
            }

            //�g�[�^���R�X�g��\������
            TotalCost = CalcCost;
            CostText.text = "COST : " + TotalCost.ToString() + "/ 5";
        }
    }

}
