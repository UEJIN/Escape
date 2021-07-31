using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateItemSlot : MonoBehaviour
{

    //�@�A�C�e�����̃X���b�g�v���n�u
    [SerializeField]
    private GameObject slot;
    //�@��l���̃X�e�[�^�X
    //[SerializeField]
    //private MyStatus myStatus;
    //�@�A�C�e���f�[�^�x�[�X
    //[SerializeField]
    //private ItemDataBase itemDataBase;

    //�@�A�C�e���f�[�^�x�[�X
    [SerializeField]
    private PlayersItem playersItem;

    //�@�A�N�e�B�u�ɂȂ�����
    void OnEnable()
    {
        //�@�A�C�e���f�[�^�x�[�X�ɓo�^����Ă���A�C�e���p�̃X���b�g��S�쐬
        CreateSlot(playersItem.GetPossessionList());
        Debug.Log("PossessionList" + playersItem.GetPossessionList().Length);
    }

    //�@�A�C�e���X���b�g�̍쐬
    public void CreateSlot(GameObject[] PossessionList)
    {

        int i = 0;


        for (int a = 0; a < PossessionList.Length; a++)
        {

            var item = PossessionList[a].GetComponent<ItemData>();

            //foreach (var item in PossessionList)
            //{
            //if (myStatus.GetItemFlag(item.GetItemName()))
            //{
            //�@�X���b�g�̃C���X�^���X��
            var instanceSlot = Instantiate<GameObject>(slot, transform);
            //�@�X���b�g�Q�[���I�u�W�F�N�g�̖��O��ݒ�
            instanceSlot.name = "ItemSlot" + i++;
            //�@Scale��ݒ肵�Ȃ���0�ɂȂ�̂Őݒ�
            instanceSlot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //�@�A�C�e�������X���b�g��ProcessingSlot�ɐݒ肷��
            instanceSlot.GetComponent<ItemSlotManager>().SetItemData(item);
            //}
            //}
        }
    }
}