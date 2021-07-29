
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "MyScriptable/CreateItem")]
public class ItemData : ScriptableObject
{

	public enum KindOfItem
	{
		EquipableItem,
		UseItem
	}

	//�@�A�C�e���̎��
	[SerializeField]
	private KindOfItem kindOfItem;
	//�@�A�C�e���̃A�C�R��
	[SerializeField]
    [ShowAssetPreview]
    private Sprite icon;
	//�@�A�C�e���̖��O
	[SerializeField]
	private string itemName;
	//�@�A�C�e���̏��
	[SerializeField]
	private string information;
	//�@�A�C�e���̏���
	[SerializeField]
	private bool isPossetion;
	//�@�A�C�e���̑���
	[SerializeField]
	private bool isEquip;
	//�@�A�C�e���̌���
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

	public string GetInformation()
	{
		return information;
	}
}
