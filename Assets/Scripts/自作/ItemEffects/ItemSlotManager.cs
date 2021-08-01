using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{

    //�@�A�C�e������\������e�L�X�gUI
    private Text informationText;
    ////�@�A�C�e���̖��O��\������e�L�X�gUI�v���n�u
    //[SerializeField]
    //private GameObject itemSlotTitleUI;
    ////�@�A�C�e������\������e�L�X�gUI���C���X�^���X�������������Ă���
    //private GameObject itemSlotTitleUIInstance;
    //�@���g�̃A�C�e���f�[�^�����Ă���
    public ItemData myItemData;
    //�@�A�C�e���X���b�g�̃{�^��
    ButtonState ItemSlotButton;
    ButtonState EquipButton;
    ButtonState RemoveButton;

    //�@�X���b�g����A�N�e�B�u�ɂȂ�����폜
    void OnDisable()
    {
        //if (itemSlotTitleUIInstance != null)
        //{
        //    Destroy(itemSlotTitleUIInstance);
        //}
        Destroy(gameObject);
    }

    //�@�A�C�e���̃f�[�^���Z�b�g
    public void SetItemData(ItemData itemData)
    {
        myItemData = itemData;
        //�@�A�C�e���̃X�v���C�g��ݒ�
        transform.GetChild(0).GetComponent<Image>().sprite = myItemData.GetIcon();
    }

    void OnEnable()
    {
        ItemSlotButton = this.gameObject.GetComponent<ButtonState>();
    }

    void Start()
    {
        //�@�A�C�e���X���b�g�̐e�̐e����Information�Q�[���I�u�W�F�N�g��T��Text�R���|�[�l���g���擾����
        informationText = transform.parent.parent.Find("Panel_Infomation").GetChild(0).GetComponent<Text>();

        EquipButton = transform.parent.parent.Find("Buttons").GetChild(0).GetComponent<ButtonState>();
        RemoveButton = transform.parent.parent.Find("Buttons").GetChild(1).GetComponent<ButtonState>();

        //�����̑�����Ԃ𔽉f
        if (myItemData.isEquip == true)
        {
            transform.GetComponent<Image>().color = new Color(255f, 0f, 0f, 100f);
        }
    }

    void Update()
    {
        //Debug.Log(informationText.text);
        if (ItemSlotButton.IsDown() == true)
        {
            //�@���\���e�L�X�g�Ɏ��g�̃A�C�e���̏���\��
            informationText.text = myItemData.GetItemName() + ":" + myItemData.GetInformation();

        }

        //�^�C����I�����Ă����Ԃő����{�^������������
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && EquipButton.IsDown() == true)
        {
            //����
            if (myItemData.isEquip == false)
            {
                myItemData.isEquip = true;
                transform.GetComponent<Image>().color = new Color(255f,0f,0f,100f);
            }
            //else
            //{
            //    myItemData.isEquip = false;
            //    transform.GetComponent<Image>().color = new Color(255f, 255f, 255f, 100f);
            //}
        }

        //�^�C����I�����Ă����Ԃŉ����{�^������������
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && RemoveButton.IsDown() == true)
        {
            //��������
            if (myItemData.isEquip == true)
            {
                myItemData.isEquip = false;
                transform.GetComponent<Image>().color = new Color(255f, 255f, 255f, 100f);
            }
        }
        //else
        //{
        //    informationText.text = "";
        //}

    }

    //public void MouseOver()
    //{
    //    if (itemSlotTitleUIInstance != null)
    //    {
    //        Destroy(itemSlotTitleUIInstance);
    //    }
    //    //�@�A�C�e���̖��O��\������UI���ʒu�𒲐����ăC���X�^���X��
    //    itemSlotTitleUIInstance = Instantiate<GameObject>(itemSlotTitleUI, new Vector2(transform.position.x - 25f, transform.position.y + 25f), Quaternion.identity, transform.parent.parent);
    //    //�@�A�C�e���\��Text���擾
    //    var itemSlotTitleText = itemSlotTitleUIInstance.GetComponentInChildren<Text>();
    //    //�@�A�C�e���\���e�L�X�g�Ɏ��g�̃A�C�e���̖��O��\��
    //    itemSlotTitleText.text = myItemData.GetItemName();
    //    //�@���\���e�L�X�g�Ɏ��g�̃A�C�e���̏���\��
    //    informationText.text = myItemData.GetInformation();
    //}

    //public void MouseExit()
    //{
    //    //�@�}�E�X�|�C���^���A�C�e���X���b�g���o����A�C�e���\��UI���폜
    //    if (itemSlotTitleUIInstance != null)
    //    {
    //        informationText.text = "";
    //        Destroy(itemSlotTitleUIInstance);
    //    }
    //}
}