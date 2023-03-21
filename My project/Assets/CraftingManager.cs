using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	private Item currentItem;
	public Image customCursor;

	public Slot[] craftingSlots;

	public List<Item> itemList;

	[Header("Add by writing the item x4 without spaces " +
		" name must be the same as in Items folder the corresponding items name")]
	[Header("if want smaller recipe for example: FlowerFlowernullnull ")]
	public string[] recipe; // Just duplicate his and rename recipe to recipe1 etc
	

	public Item[] recipeResults;
	public Slot resultSlot;

	public int Correct = 0;
	
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
				InventoryManager.Instance.Add(recipeResults[i]);
				break;
			}
		}
	}
}
