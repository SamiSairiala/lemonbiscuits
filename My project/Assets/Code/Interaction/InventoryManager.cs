using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
	public List<Item> Items = new List<Item>();

	public Transform ItemContent;
	public GameObject InventoryItem;

	private int quantity = 0;

	private void Awake()
	{
		Instance = this;
	}

	public void Add(Item item)
	{
        item.Amount++;
        Items.Add(item);
		
	}

	

	public void Remove(Item item)
	{
		item.Amount -= 1;
        Items.Remove(item);
		
	}

	
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
            
			GameObject obj = Instantiate(InventoryItem, ItemContent);
			var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
			var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
			var itemCount = obj.transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
			
			itemName.text = item.itemName;
			itemIcon.sprite = item.Icon;
			itemCount.text = item.Amount.ToString();
            //if (item.Amount > 1)
            //{
				
            //    break;
            //}




        }
	}
}
