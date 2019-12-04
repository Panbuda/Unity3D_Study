using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
	public Item item;

	public override void Interact()
	{
		PickUp();
	}

	void PickUp()
	{
		bool isPickedUp =  Inventory.instance.Add(item);
		if(isPickedUp)
			Destroy(gameObject);
	}
}
