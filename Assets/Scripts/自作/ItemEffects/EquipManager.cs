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
         //�������X�g���ύX���ꂽ��
        if (EquipmentList != PlayersItem.EquipmentList)
        {
            //�������X�g���X�V����
            EquipmentList = PlayersItem.EquipmentList;

            //��j��Ɉړ��������������Z�b�g����
            for (int i = 0; i < EquipMax; i++)
            {
                Destroy(CopyEquipItem[i]);
                isFinish[i] = false;
            }

            //�����A�C�R����\������B�R�X�g���v�Z����B   
            CalcCost = 0;
            for (int i = 0; i < EquipMax; i++)
            {

                if (EquipmentList[i] != null)
                {
                    //�A�C�R���擾
                    icon = EquipmentList[i].GetComponent<ItemData>().GetIcon();
                    //�����X���b�g�ɃA�C�R���𔽉f
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;

                    //�R�X�g��ώZ
                    CalcCost += EquipmentList[i].GetComponent<ItemData>().GetItemCost();

                    //�A�C�e�����ʎ擾
                    itemEffect = EquipmentList[i].GetComponent<ItemData>().GetItemEffect();
                    //�����X���b�g�̉��Ɍ��ʂ�\������
                    equipSlots[i].transform.GetChild(1).GetComponent<Text>().text = itemEffect;

                    //�I�u�W�F�N�g�𕡐����A�e���ꂵ�āA��j��I�u�W�F�N�g�ɐݒ肷��
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
                    //��������Ă��Ȃ��X���b�g�͉摜�Ȃ��ɂ��Ă���
                    equipSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                    
                    if(CopyEquipItem[i] != null)
                    {
                        Destroy(CopyEquipItem[i]);
                        isFinish[i] = false;
                    }

                }
            }

            //�g�[�^���R�X�g��\������
            TotalCost = CalcCost;
            CostText.text = "COST : " + TotalCost.ToString() + "/ 5";
        }
    }

    //�g�[�^���R�X�g���擾����
    public int GetTotalCost()
    {
        return TotalCost;
    }


}
