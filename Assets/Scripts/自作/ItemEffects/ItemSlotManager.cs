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
    }

    void Update()
    {
        //Debug.Log(informationText.text);
        if (ItemSlotButton.IsDown() == true)
        {
            //�@���\���e�L�X�g�Ɏ��g�̃A�C�e���̏���\��
            informationText.text = myItemData.GetItemName() + ":" + myItemData.GetInformation();

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