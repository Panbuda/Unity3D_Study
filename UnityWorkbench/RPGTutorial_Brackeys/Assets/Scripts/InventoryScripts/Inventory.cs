using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singleton
	public static Inventory instance;

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

	public delegate void OnItemChanged();
	public event OnItemChanged onItemChangedCallBack;

	public int space = 20;
	public List<Item> items = new List<Item>();

	public bool Add(Item item)
	{
		if (!item.isDefautItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("Space Full!");
				return false;
			}
			items.Add(item);

			if (onItemChangedCallBack != null)
				onItemChangedCallBack.Invoke();
		}
		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);

		if (onItemChangedCallBack != null)
			onItemChangedCallBack.Invoke();
	}
}
