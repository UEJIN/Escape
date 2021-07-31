using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテム取得のためのクラス。
public class ItemController : MonoBehaviour
{
    [SerializeField] 
    //Item iteminfo; //さっきのアイテム情報をアタッチ
    Collider other;

    private void Start()
    {
        ////接触したらアイテム取得？
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