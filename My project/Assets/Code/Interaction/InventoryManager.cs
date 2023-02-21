using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
	public List<Item> Items = new List<Item>();

	public Transform ItemContent;
	public GameObject InventoryItem;
	public GameObject inventoryUI;

	private void Awake()
	{
		Instance = this;
	}

	public void Add(Item item)
	{
		Items.Add(item);
		
	}

	

	public void Remove(Item item)
	{
		Items.Remove(item);
	}

	// TODO: Make it show with pressing some button.
	// Shows inventory UI.
	public void ListItems()
	{
		foreach(Transform item in ItemContent)
		{
			Destroy(item.gameObject);
		}
		foreach(var item in Items)
		{
			//Activates inventory ui.
			inventoryUI.gameObject.SetActive(true);
			GameObject obj = Instantiate(InventoryItem, ItemContent);
			//TODO: Change these to TMP
			var itemName = obj.transform.Find("Item/ItemName").GetComponent<Text>();
			var itemIcon = obj.transform.Find("Item/ItemIcon").GetComponent<Image>();
			
			itemName.text = item.itemName;
			itemIcon.sprite = item.Icon;
		}
	}
}
