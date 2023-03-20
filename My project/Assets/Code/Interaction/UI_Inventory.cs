using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{

	[SerializeField]private InventoryManager Inventory;

	private Transform Content;
	private Transform Item;

	private void Awake()
	{
		Debug.Log(Inventory.Items.Count);
		Content = transform.Find("Content");
		Item = Content.Find("Item");
		
		RefreshInventory();
	}


	

	public void RefreshInventory()
	{
		foreach(Transform child in Content)
		{
			if(child == Item)
			{
				continue;
			}
			Destroy(child.gameObject);
		}
		int x = 0;
		int y = 0;
		float itemSlotCellSize = 75f;
		foreach (Item item in Inventory.InventoryItems)
		{
			Debug.Log(item);
			RectTransform itemSlotTransform = Instantiate(Item, Content).GetComponent<RectTransform>();
			itemSlotTransform.gameObject.SetActive(true);
			itemSlotTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
			Image image = itemSlotTransform.Find("ItemIcon").GetComponent<Image>();
			image.sprite = item.Icon;
			TextMeshProUGUI Amount = itemSlotTransform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
			Amount.SetText(item.Amount.ToString());
			x++;
			if(x < 5)
			{
				x = 0;
				y++;
			}
		}
	}
}
