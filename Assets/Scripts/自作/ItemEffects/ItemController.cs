using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���擾�̂��߂̃N���X�B
public class ItemController : MonoBehaviour
{
    [SerializeField] 
    //Item iteminfo; //�������̃A�C�e�������A�^�b�`
    Collider other;

    private void Start()
    {
        ////�ڐG������A�C�e���擾�H
        //this.OnTriggerStayAsObservable()
        //    .Where(other => other.gameObject.tag == "Player")
        //    .Where(_ => PlayersItem.itemLists.Count < 6)
        //    .Where(_ => Input.GetKeyUp(KeyCode.LeftControl))
        //    .Subscribe(_ => AddItem())
        //    .AddTo(this.gameObject);
    }

    void AddItem()
    {
        //PlayersItem.itemLists.Add(iteminfo);
        Destroy(this.gameObject);
    }
}