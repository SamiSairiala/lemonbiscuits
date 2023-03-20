using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
	public List<Item> Items = new List<Item>();
	public List<Item> InventoryItems = new List<Item>();

	public Transform ItemContent;
	public GameObject InventoryItem;

	private int quantity = 0;
	[SerializeField]private UI_Inventory uiInventory;
	private void Awake()
	{
		Instance = this;
		
	}

	public void Add(Item item)
	{
		if (item.IsStackable)
		{
			bool itemAlreadyIn = false;
			foreach(Item inventoryItem in InventoryItems)
			{
				if(inventoryItem.itemName == item.itemName)
				{
					inventoryItem.Amount = item.Amount;
					itemAlreadyIn = true;
					item.Amount++;
					Items.Add(item);
				}
			}
			if (!itemAlreadyIn)
			{
				item.Amount++;
				Items.Add(item);
				InventoryItems.Add(item);
			}
		}
		else
		{
			item.Amount++;
			Items.Add(item);
			InventoryItems.Add(item);
		}
        
        
		
	}

	

	public void Remove(Item item)
	{
		item.Amount -= 1;
        Items.Remove(item);
		if(item.Amount == 0)
		{
			InventoryItems.Remove(item);
		}
		
		
	}


	// Shows inventory UI.
	public void ListItems()
	{
		
		uiInventory.RefreshInventory();
		//int doneIn = 0;
		//foreach (Transform item in ItemContent)
		//{
		//	Destroy(item.gameObject);
		//}
		//foreach (var item in Items)
		//{

		//	//Activates inventory ui.
		//	if (item.Amount > 1 && item.IsStackable)
		//	{
		//		doneIn++;
		//		if (doneIn > 1)
		//		{
		//			continue;
		//		}

		//	}
		//	GameObject obj = Instantiate(InventoryItem, ItemContent);
		//	var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
		//	var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
		//	var itemCount = obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();

		//	itemName.text = item.itemName;
		//	itemIcon.sprite = item.Icon;
		//	itemCount.text = item.Amount.ToString();





		//}
	}
}
