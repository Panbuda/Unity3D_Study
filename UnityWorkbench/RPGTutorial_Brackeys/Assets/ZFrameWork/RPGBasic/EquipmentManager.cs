using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	#region Singleton
	public static EquipmentManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance was found!");
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void EquipmentChanged(Equipment oldEquipment, Equipment newEquipment);
	public event EquipmentChanged OnEquipmentChanged;

	Equipment[] currentEquipment;
	Inventory inventory;

	// Start is called before the first frame update
	void Start()
    {
		currentEquipment = new Equipment[System.Enum.GetNames(typeof(EquipSlot)).Length];
		inventory = Inventory.instance;
    }

    public void Equip(Equipment newEquipment)
	{
		int slotIndex = (int)newEquipment.equipSlot;
		Equipment oldEquipment = null;
		if (currentEquipment[slotIndex] != null)
		{
			oldEquipment = currentEquipment[slotIndex];
			inventory.Add(oldEquipment);
		}
		currentEquipment[slotIndex] = newEquipment;
		newEquipment.RemoveFromInventory();

		if(OnEquipmentChanged != null)
			OnEquipmentChanged.Invoke(oldEquipment, newEquipment);
	}

	public void UnEquip(EquipSlot slot)
	{
		int slotIndex = (int)slot;
		Equipment oldEquipment = currentEquipment[slotIndex];
		if (oldEquipment == null)
			return;
		inventory.Add(oldEquipment);
		currentEquipment[slotIndex] = null;

		if (OnEquipmentChanged != null)
			OnEquipmentChanged.Invoke(oldEquipment, null);
	}

	public void UnEquipAll()
	{
		for(int i = 0; i < currentEquipment.Length; i++)
		{
			UnEquip((EquipSlot)i);
		}
	}

	private void Update()
	{
		//UnEquip Test
		if (Input.GetKeyDown(KeyCode.U))
		{
			UnEquipAll();
		}
	}
}
