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
    }

    //�@�A�C�e���X���b�g�̍쐬
    public void CreateSlot(GameObject[] PossessionList)
    {
        //�쐬����X���b�g�̖��O�̎}�ԗp
        int i = 0;

        for (int a = 0; a < PossessionList.Length; a++)
        {
            if(PossessionList[a]==null)
            {
                break;
            }

            //�����A�C�e���̃f�[�^���擾
            var item = PossessionList[a].GetComponent<ItemData>();
            //�@�X���b�g�̃C���X�^���X��
            var instanceSlot = Instantiate<GameObject>(slot, transform);
            //�@�X���b�g�Q�[���I�u�W�F�N�g�̖��O��ݒ�
            instanceSlot.name = "ItemSlot" + i++;
            //�@Scale��ݒ肵�Ȃ���0�ɂȂ�̂Őݒ�
            instanceSlot.transform.localScale = new Vector3(1f, 1f, 1f);
            //�@�A�C�e�������X���b�g��ProcessingSlot�ɐݒ肷��
            instanceSlot.GetComponent<ItemSlotManager>().SetItemData(item);

        }
    }
}