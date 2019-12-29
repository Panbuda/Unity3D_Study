using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipSlot
{
	Head, Chest, Arms, Legs, Feet, Weapon
}

[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
	public EquipSlot equipSlot;

	public int armorModifier;
	public int damageModifier;

	public override void Use()
	{
		EquipmentManager.instance.Equip(this);
	}
}
