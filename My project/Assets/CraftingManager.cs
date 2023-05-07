using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingManager : MonoBehaviour
{
	private Item currentItem;
	public Image customCursor;

	public Slot[] craftingSlots;

	public List<Item> itemList;

	public delegate void ItemEventHandler(Item item);
	public static event ItemEventHandler OnItemAddedToInventory;

	[Header("Add by writing the item x4 without spaces " +
		" name must be the same as in Items folder the corresponding items name")]
	[Header("if want smaller recipe for example: FlowerFlowernullnull ")]
	public string[] recipe; // Just duplicate his and rename recipe to recipe1 etc
	

	public Item[] recipeResults;
	public Slot resultSlot;

	public int Correct = 0;
	private Item itemToReceive;

	[SerializeField] private GameObject AcceptButton;
	[SerializeField] private GameObject CraftingCanvas;

	[Header("Items that can be used to craft here. Can Add more from script")]
	public GameObject GameObject1;
	public Item Item1;
	public GameObject GameObject2; 
	public Item Item2;
	public GameObject GameObject3;
	public Item Item3;
	public GameObject GameObject4;
	public Item Item4;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
			CraftingCanvas.SetActive(true);
		}
	}

	private void Update()
    {
		GameObject1.GetComponentInChildren<TextMeshProUGUI>().text = Item1.Amount.ToString();
		GameObject2.GetComponentInChildren<TextMeshProUGUI>().text = Item2.Amount.ToString();
		GameObject3.GetComponentInChildren<TextMeshProUGUI>().text = Item3.Amount.ToString();
		GameObject4.GetComponentInChildren<TextMeshProUGUI>().text = Item4.Amount.ToString();
		if (Item1.Amount == 0) // Add items here too.
		{
			GameObject1.gameObject.SetActive(false);
		}
		if (Item2.Amount == 0)
		{
			GameObject2.gameObject.SetActive(false);
		}
		if(Item3.Amount == 0)
        {
			GameObject3.gameObject.SetActive(false);
        }
		if (Item4.Amount == 0)
		{
			GameObject4.gameObject.SetActive(false);
		}
		if (InventoryManager.Instance.Items.Contains(Item1))
        {
			GameObject1.gameObject.SetActive(true);
			
			
        }
        if (InventoryManager.Instance.Items.Contains(Item2))
        {
			GameObject2.gameObject.SetActive(true);
			
		}
        if (InventoryManager.Instance.Items.Contains(Item3))
        {
			GameObject3.gameObject.SetActive(true);
        }
		if (InventoryManager.Instance.Items.Contains(Item4))
		{
			GameObject4.gameObject.SetActive(true);
		}
	}


    public void OnMouseDownItem(Item item)
	{
		if(currentItem == null)
		{
			
			currentItem = item;

			for(int i = 0; i < craftingSlots.Length; i++)
			{
				if(craftingSlots[i].item == null)
				{
					craftingSlots[i].gameObject.SetActive(true);
					craftingSlots[i].GetComponent<Image>().sprite = currentItem.Icon;
					craftingSlots[i].item = currentItem;
					itemList[i] = currentItem;
					currentItem = null;
					InventoryManager.Instance.Remove(itemList[i]);
					CheckForRecipes();
					break;
				}
			}

			
		}
	}


	void CheckForRecipes()
	{
		resultSlot.gameObject.SetActive(false);
		resultSlot.item = null;
		string currentRecipeString = "";
		foreach(Item item in itemList)
		{
			if(item != null)
			{
				currentRecipeString += item.itemName;
			}
			else
			{
				currentRecipeString += "null";
			}
		}

		for(int i = 0; i < recipe.Length; i++)
		{
			if(recipe[i] == currentRecipeString)
			{
				resultSlot.gameObject.SetActive(true);
				resultSlot.GetComponent<Image>().sprite = recipeResults[i].Icon;
				resultSlot.item = recipeResults[i];
				itemToReceive = recipeResults[i];
				AcceptButton.SetActive(true);
				break;
			}
		}
	}


	public void RedoClose()
    {
		for(int i = 0; i < craftingSlots.Length; i++)
        {
			if(craftingSlots[i].item != null)
            {
				InventoryManager.Instance.Add(craftingSlots[i].item);
				craftingSlots[i].gameObject.SetActive(false);
				craftingSlots[i].GetComponent<Image>().sprite = default;
				craftingSlots[i].item = default;
			}
			
        }
		
		resultSlot.item = null;
		resultSlot.gameObject.SetActive(false);
		AcceptButton.SetActive(false);
		ClearList();
		List<Item> itemList = new List<Item>(4);

	}

	
	public void Close() // Does the same as in RedoClose but also closes CraftingCanvas.
    {
		for (int i = 0; i < craftingSlots.Length; i++)
		{
			if (craftingSlots[i].item != null)
			{
				InventoryManager.Instance.Add(craftingSlots[i].item);
				craftingSlots[i].gameObject.SetActive(false);
				craftingSlots[i].GetComponent<Image>().sprite = default;
				craftingSlots[i].item = default;
			}

		}

		resultSlot.item = null;
		resultSlot.gameObject.SetActive(false);
		AcceptButton.SetActive(false);
		ClearList();
		List<Item> itemList = new List<Item>(4);
		CraftingCanvas.SetActive(false);
	}

	void ClearList()
    {
		for(int i = 0; i < itemList.Capacity; i++)
        {
			itemList[i] = null;
        }
    }



	public void AcceptCraft()
    {
		InventoryManager.Instance.Add(itemToReceive);
		ItemAddedToInventory(itemToReceive);
		resultSlot.item = null;
		resultSlot.gameObject.SetActive(false);
		AcceptButton.SetActive(false);
		CraftingCanvas.SetActive(false);
		ClearList();
		List<Item> itemList = new List<Item>(4);
		if (itemToReceive.itemName.Equals("Fish Pie"))
		{
			FindObjectOfType<NarratorDialogue>().SecondText();
		}
		if (itemToReceive.itemName.Equals("Croissant"))
		{
			FindObjectOfType<NarratorDialogue>().FirstText();
		}
	}

	public static void ItemAddedToInventory(Item item)
	{
		if (OnItemAddedToInventory != null)
		{
			OnItemAddedToInventory(item);
			Debug.Log(item);
		}

	}
}
