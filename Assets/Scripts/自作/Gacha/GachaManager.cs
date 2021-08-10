using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    //�e���A���e�B�̔r�o�����蓮�Őݒ�
    public float SSRratio = 2f;
    public float SRratio = 18f;
    public float Rratio= 30f;
    public float Nratio = 50f;

    //�e���A���e�B�̃A�C�e�����蓮�Œǉ�
    public GameObject[] SSRitems;
    public GameObject[] SRitems;
    public GameObject[] Ritems;
    public GameObject[] Nitems;

    //�K�`���{�^�����w��
    public ButtonState GachaButtonState;

    //�K�`�����ʃA�C�e�����e�L�X�g
    public Text ItemText;

    //�K�`�����ʃA�C�e���A�C�R��
    public Image GachaResultIcon;

    //�ŏI���ʃA�C�e��
    private GameObject ResultItem;

    //���A���e�B
    private string Rarity;

    //���I��K�`�����X�g
    GameObject[] GachaList;

    //NEW�t���O
    private bool isNewItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�K�`���{�^���������ꂽ��
        if(GachaButtonState.IsDown())
        {
            //�|�C���g������

            //�A�C�e������
            ResultItem = ChoseGachaResult();

            //�A�C�e�����擾��Ԃɂ���
            if (ResultItem.GetComponent<ItemData>().isPossession == false)
            {
                ResultItem.GetComponent<ItemData>().isPossession = true;
                isNewItem = true;//�����ĂȂ����new
            }
            else
            {
                isNewItem = false;//�����Ă���΂Ȃ�
            }

            //�K�`�����o

            //�K�`�����ʕ\��
            //���ʃe�L�X�g
            if (isNewItem)
            {
                ItemText.color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 255f/255f);
                ItemText.text = "NEW �y" + Rarity + "�z" + ResultItem.GetComponent<ItemData>().GetItemName();
            }
            else
            {
                ItemText.color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255f / 255f);
                ItemText.text = "�y" + Rarity + "�z" + ResultItem.GetComponent<ItemData>().GetItemName();
            }
            //���ʃA�C�R��
            GachaResultIcon.sprite = ResultItem.GetComponent<ItemData>().GetIcon();
        }
    }
    
    //�K�`���̓��e����������
    //private void InitGachaData()
    //{
    //    _gachaDataList = new[]
    //    {
    //        new GachaData("��", "Normal", Color.blue),
    //        new GachaData("�˂�", "Normal", Color.blue),
    //        ... (��) ...
    //    };
    //}

    private GameObject ChoseGachaResult()
    {
        //���A���e�B�𒊑I
        Rarity = ChoseRarity();

        //���A���e�B�̊Y���A�C�e�����X�g���擾
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

        //���X�g���烉���_���ŃA�C�e���𒊑I���ĕԂ�
        return GachaList[Random.Range(0, GachaList.Length)];
    }


    //���A���e�B�̒��I
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
