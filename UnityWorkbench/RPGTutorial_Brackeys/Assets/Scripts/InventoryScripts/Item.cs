using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	//use new to override the ScriptableObject.name
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefautItem = false;
}
