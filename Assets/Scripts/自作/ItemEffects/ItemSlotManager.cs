using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{

    //　アイテム情報を表示するテキストUI
    private Text informationText;
    //　自身のアイテムデータを入れておく
    public ItemData myItemData;
    //　アイテムスロットのボタン
    ButtonState ItemSlotButton;
    ButtonState EquipButton;
    ButtonState RemoveButton;
    EquipManager equipManager;

    //　スロットが非アクティブになったら削除
    void OnDisable()
    {
        Destroy(gameObject);
    }

    void OnEnable()
    {
        //このアイテムスロットを取得
        ItemSlotButton = this.gameObject.GetComponent<ButtonState>();
    }

    void Start()
    {
        //　アイテムスロットの親の親からInformationゲームオブジェクトを探しTextコンポーネントを取得する
        informationText = transform.parent.parent.Find("Panel_Infomation").GetChild(0).GetComponent<Text>();
        EquipButton = transform.parent.parent.Find("Buttons").GetChild(0).GetComponent<ButtonState>();
        RemoveButton = transform.parent.parent.Find("Buttons").GetChild(1).GetComponent<ButtonState>();
        equipManager = transform.parent.parent.Find("Panel_Equip").GetChild(0).GetComponent<EquipManager>();

        //初期の装備状態を反映
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

    //　アイテムのデータをセット
    public void SetItemData(ItemData itemData)
    {
        myItemData = itemData;
        //　アイテムのスプライトを設定
        transform.GetChild(0).GetComponent<Image>().sprite = myItemData.GetIcon();
    }

    //　アイテム情報を表示
    private void ShowInfomation()
    {
        //アイテムスロットを選択時
        if (ItemSlotButton.IsDown() == true)
        {
            //　情報表示テキストに自身のアイテムの情報を表示
            informationText.text = myItemData.GetItemName() + ":" + myItemData.GetInformation()+"\n【効果】"+myItemData.GetItemEffect();
        }

    }

    // 装備オンオフ制御
    private void EquipOnOff()
    {
        //タイルを選択している状態で装備ボタンを押したら
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && EquipButton.IsDown() == true)
        {
            //コストがオーバーしなければ
            if (equipManager.GetTotalCost() + myItemData.GetItemCost() <= equipManager.EquipMax)
            {//装備する
                if (myItemData.isEquip == false)
                {
                    myItemData.isEquip = true;
                    //装備しているときの色
                    transform.GetComponent<Image>().color = new Color(255f, 0f, 0f, 100f);
  
                }

            }
        }

        //タイルを選択している状態で解除ボタンを押したら
        if (informationText.text == myItemData.GetItemName() + ":" + myItemData.GetInformation() && RemoveButton.IsDown() == true)
        {
            //装備解除する
            if (myItemData.isEquip == true)
            {
                myItemData.isEquip = false;
                //装備してないときの色
                transform.GetComponent<Image>().color = new Color(255f, 255f, 255f, 100f);

            }
        }
    }

}