using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateItemSlot : MonoBehaviour
{

    //　アイテム情報のスロットプレハブ
    [SerializeField]
    private GameObject slot;
    //　主人公のステータス
    //[SerializeField]
    //private MyStatus myStatus;
    //　アイテムデータベース
    //[SerializeField]
    //private ItemDataBase itemDataBase;

    //　アイテムデータベース
    [SerializeField]
    private PlayersItem playersItem;



    //　アクティブになった時
    void OnEnable()
    {
        //　アイテムデータベースに登録されているアイテム用のスロットを全作成
        CreateSlot(playersItem.GetPossessionList());
    }

    //　アイテムスロットの作成
    public void CreateSlot(GameObject[] PossessionList)
    {
        //作成するスロットの名前の枝番用
        int i = 0;

        for (int a = 0; a < PossessionList.Length; a++)
        {
            if(PossessionList[a]==null)
            {
                break;
            }

            //所持アイテムのデータを取得
            var item = PossessionList[a].GetComponent<ItemData>();
            //　スロットのインスタンス化
            var instanceSlot = Instantiate<GameObject>(slot, transform);
            //　スロットゲームオブジェクトの名前を設定
            instanceSlot.name = "ItemSlot" + i++;
            //　Scaleを設定しないと0になるので設定
            instanceSlot.transform.localScale = new Vector3(1f, 1f, 1f);
            //　アイテム情報をスロットのProcessingSlotに設定する
            instanceSlot.GetComponent<ItemSlotManager>().SetItemData(item);

        }
    }
}