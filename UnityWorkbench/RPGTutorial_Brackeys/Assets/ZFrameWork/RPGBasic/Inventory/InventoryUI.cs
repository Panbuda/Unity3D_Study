using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	Inventory inventory;
	//using this instead of transform.gameobject
	public GameObject inventoryUI;

	public Transform itemParent;
	InventorySlot[] inventorySlots;
    // Start is called before the first frame update
    void Start()
    {
		inventory = Inventory.instance;
		inventory.onItemChangedCallBack += UpdateUI;

		inventorySlots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
    }

	void UpdateUI()
	{
		for(int i = 0; i < inventorySlots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				inventorySlots[i].AddItem(inventory.items[i]);
			}	
			else
			{
				inventorySlots[i].ClearItem();
			}
		}
	}
}
