using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{

    //　アイテム情報を表示するテキストUI
    private Text informationText;
    ////　アイテムの名前を表示するテキストUIプレハブ
    //[SerializeField]
    //private GameObject itemSlotTitleUI;
    ////　アイテム名を表示するテキストUIをインスタンス化した物を入れておく
    //private GameObject itemSlotTitleUIInstance;
    //　自身のアイテムデータを入れておく
    public ItemData myItemData;
    //　アイテムスロットのボタン
    ButtonState ItemSlotButton;

    //　スロットが非アクティブになったら削除
    void OnDisable()
    {
        //if (itemSlotTitleUIInstance != null)
        //{
        //    Destroy(itemSlotTitleUIInstance);
        //}
        Destroy(gameObject);
    }

    //　アイテムのデータをセット
    public void SetItemData(ItemData itemData)
    {
        myItemData = itemData;
        //　アイテムのスプライトを設定
        transform.GetChild(0).GetComponent<Image>().sprite = myItemData.GetIcon();
    }

    void OnEnable()
    {
        ItemSlotButton = this.gameObject.GetComponent<ButtonState>();
    }

    void Start()
    {
        //　アイテムスロットの親の親からInformationゲームオブジェクトを探しTextコンポーネントを取得する
        informationText = transform.parent.parent.Find("Panel_Infomation").GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        //Debug.Log(informationText.text);
        if (ItemSlotButton.IsDown() == true)
        {
            //　情報表示テキストに自身のアイテムの情報を表示
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
    //    //　アイテムの名前を表示するUIを位置を調整してインスタンス化
    //    itemSlotTitleUIInstance = Instantiate<GameObject>(itemSlotTitleUI, new Vector2(transform.position.x - 25f, transform.position.y + 25f), Quaternion.identity, transform.parent.parent);
    //    //　アイテム表示Textを取得
    //    var itemSlotTitleText = itemSlotTitleUIInstance.GetComponentInChildren<Text>();
    //    //　アイテム表示テキストに自身のアイテムの名前を表示
    //    itemSlotTitleText.text = myItemData.GetItemName();
    //    //　情報表示テキストに自身のアイテムの情報を表示
    //    informationText.text = myItemData.GetInformation();
    //}

    //public void MouseExit()
    //{
    //    //　マウスポインタがアイテムスロットを出たらアイテム表示UIを削除
    //    if (itemSlotTitleUIInstance != null)
    //    {
    //        informationText.text = "";
    //        Destroy(itemSlotTitleUIInstance);
    //    }
    //}
}