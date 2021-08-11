using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerStatusText : MonoBehaviour
{
    public Text textLife;
    public Text textAttack;
    public Text textDefence;
    public Text textSpeed;
    public Text textEyeSight;
    public Text testGachaPoint;
    public Text testPossesionItemNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
    textLife.text = "Life : "+LifeManager.IniLife.ToString();
    //textAttack.text;
    //textDefence.text;
    //textSpeed.text;
    //textEyeSight.text;
    testGachaPoint.text = "GachaPoint : "+GachaManager.GachaPoint.ToString();
    testPossesionItemNum.text ="Items : "+ PlayersItem.PossessionList.ToArray().Length.ToString() + "/"+PlayersItem.ItemList.Length.ToString();

}
}
