using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{

    //�@�A�C�e������\������e�L�X�gUI
    private Text informationText;
    //�@���g�̃A�C�e���f�[�^�����Ă���
    public ItemData myItemData;
    //�@�A�C�e���X���b�g�̃{�^��
    ButtonState ItemSlotButton;
    ButtonState EquipButton;
    ButtonState RemoveButton;
    EquipManager equipManager;

    //�@�X���b�g����A�N�e�B�u�ɂȂ�����폜
    void OnDisable()
    {
        Destroy(gameObject);
    }

    void OnEnable()
    {
        //���̃A�C�e���X���b�g���擾
        ItemSlotButton = this.gameObject.GetComponent<ButtonState>();
    }

    void Start()
    {
        //�@�A�C�e���X���b�g�̐e�̐e����Information�Q�[���I�u�W�F�N�g��T��Text�R���|�[�l���g���擾����
        informationText = transform.parent.parent.Find("Panel_Infomation").GetChild(0).GetComponent<Text>();
        EquipButton = transform.parent.parent.Find("Buttons").GetChild(0).GetComponent<ButtonState>();
        RemoveButton = transform.parent.parent.Find("Buttons").GetChild(1).GetComponent<ButtonState>();
        equipManager = transform.parent.parent.Find("Panel_Equip").GetChild(0).GetComponent<EquipManager>();

        //�����̑�����Ԃ𔽉f
        if (myItemData.isEquip == true)
        {
            transform.GetComponent<Image>().color = new Color(255f, 0f, 0f, 100f);
        }
    }

    void Update()
    {

        ShowInfomation();
        EquipOnOff();

    }

    //�@�A�C�e���̃f�[�^���Z�b�g
    public void SetItemData(ItemData itemData)
    {
        myItemData = itemData;
        //�@�A�C�e���̃X�v���C�g��ݒ�
        transform.GetChild(0).GetComponent<Image>().sprite = myItemData.GetIcon();
    }

    //�@�A�C�e������\��
    private void ShowInfomation()
    {
        //�A�C�e���X���b�g��I����
        if (ItemSlotButton.IsDown() == true)
        {
            //�@���\���e�L�X�g�Ɏ��g�̃A�C�e���̏���\��
            informationText.text = myItemData.GetItemName() + ":" + myItemData.GetInformation()+"\n�y���ʁz"+myItemData.GetItemEffect();
        }

    }

    // �����I���I�t����
    private void EquipOnOff()
    {
        //�^�C����I�����Ă����Ԃő����{�^������������
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && EquipButton.IsDown() == true)
        {
            //�R�X�g���I�[�o�[���Ȃ����
            if (equipManager.GetTotalCost() + myItemData.GetItemCost() <= equipManager.EquipMax)
            {//��������
                if (myItemData.isEquip == false)
                {
                    myItemData.isEquip = true;
                    //�������Ă���Ƃ��̐F
                    transform.GetComponent<Image>().color = new Color(255f, 0f, 0f, 100f);
  
                }

            }
        }

        //�^�C����I�����Ă����Ԃŉ����{�^������������
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && RemoveButton.IsDown() == true)
        {
            //������������
            if (myItemData.isEquip == true)
            {
                myItemData.isEquip = false;
                //�������ĂȂ��Ƃ��̐F
                transform.GetComponent<Image>().color = new Color(255f, 255f, 255f, 100f);

            }
        }
    }

}