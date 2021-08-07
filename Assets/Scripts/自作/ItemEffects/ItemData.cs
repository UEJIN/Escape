
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;

//[Serializable]
//[CreateAssetMenu(fileName = "Item", menuName = "MyScriptable/CreateItem")]
public class ItemData : MonoBehaviour
{
	//情報を持つだけのクラス
	//効果スクリプト側は、このスクリプトの状態を見てオンオフ（and破壊するしない）を制御する。

	public enum KindOfItem
	{
		EquipableItem,
		UseItem
	}

	//　アイテムの種類
	[SerializeField]
	private KindOfItem kindOfItem;
	//　アイテムのアイコン
	[SerializeField]
    [ShowAssetPreview]
    private Sprite icon;
	//　アイテムの名前
	[SerializeField]
	private string itemName;
	//　アイテムの情報
	[SerializeField, TextArea]
	private string information;
	//　アイテムの効果
	[SerializeField]
	private string itemEffect;
	//　アイテムのコスト
	[SerializeField]
	private int itemCost = 1;
	//　アイテムの所持
	[SerializeField]
	public bool isPossession;
	//　アイテムの装備
	[SerializeField]
	public bool isEquip;
	//　アイテムの効果
	//[SerializeField]
	//public GameObject Effects;

	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}

	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemName;
	}
	public string GetItemEffect()
	{
		return itemEffect;
	}
	public string GetInformation()
	{
		return information;
	}

	public int GetItemCost()
    {
		return itemCost;
    }

	public bool GetIsPossession()
    {
		return isPossession;

    }

	public bool GetIsEquip()
    {
		return isEquip;
    }


}
