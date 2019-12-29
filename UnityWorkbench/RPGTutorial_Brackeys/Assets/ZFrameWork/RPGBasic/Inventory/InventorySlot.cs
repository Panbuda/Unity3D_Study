using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
	Item item;
	public Image icon;
	public Button close;

    public void AddItem(Item item)
	{
		this.item = item;
		icon.sprite = item.icon;
		icon.enabled = true;
		close.interactable = true;
	}

	public void ClearItem()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		close.interactable = false;
	}

	public void RemoveItem()
	{
		Inventory.instance.Remove(item);
	}

	public void UseItem()
	{
		if(item != null)
			item.Use();
	}
}
