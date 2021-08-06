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

    //�K�`�����ʕ\���e�L�X�g
    public Text ItemText;

    public Image GachaResultIcon;

    //�ŏI���ʃA�C�e��
    private GameObject ResultItem;


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
            }
            //�K�`�����o

            //�K�`�����ʕ\��
            ItemText.text = ResultItem.GetComponent<ItemData>().GetItemName();
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
        //���A���e�B���I���ĊY���̃��X�g���擾
        GameObject[] GachaList = ChoseRarity();

        //���X�g���烉���_���ŃA�C�e���𒊑I���ĕԂ�
        return GachaList[Random.Range(0, GachaList.Length)];
    }

    private GameObject[] ChoseRarity()
    {
        var randValue = Random.Range(0, 100);
        if (randValue <= SSRratio)
        {
            return SSRitems;
        }
        if (randValue <= SSRratio + SRratio)
        {
            return SRitems;
        }
        if (randValue <= SSRratio + SRratio + Rratio)
        {
            return Ritems;
        }
        return Nitems;
    }


}
