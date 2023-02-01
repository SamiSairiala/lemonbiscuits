using System.Collections;
using System.Collections.Generic;

public class Inventory
{
	public List<IItem> Items
	{
		get;
	}

	public float Weight
	{
		get
		{
			float weight = 0;
			foreach (IItem item in Items)
			{
				weight += item.TotalWeight;
			}

			return weight;
		}

	}


	public float WeightLimit
	{
		get;
	}

	public Inventory(float weightLimit)
	{
		WeightLimit = weightLimit;

		Items = new List<IItem>();
	}

	// Adds a new item to the inventory. item is the item to be added and returns true if succesful.
	public bool AddItem(IItem item)
	{
		if (Weight + item.TotalWeight > WeightLimit)
		{
			return false;
		}

		IItem existing = null;
		foreach (IItem currentItem in Items)
		{
			if (currentItem.ID == item.ID)
			{
				existing = currentItem;
				break;
			}
		}



		if (existing != null && !existing.isUnique)
		{
			existing.Count += item.Count;
		}
		else
		{
			Items.Add(item);
		}
		return true;

	}

	public IItem GetItem(IItem item)
	{
		return GetItem(item.ID);
	}

	public IItem GetItem(int ID, int count = 1)
	{
		IItem result = null;
		IItem remove = null;

		foreach (IItem inspectedItem in Items)
		{
			if (inspectedItem.ID == ID)
			{
				// This is one way of initializing a new object.
				result = new Item()
				{
					ID = inspectedItem.ID,
					Weight = inspectedItem.Weight,
					Name = inspectedItem.Name,
					Description = inspectedItem.Description,
					isUnique = inspectedItem.isUnique
				};

				if (inspectedItem.Count > count)
				{
					// No need to remove the item completely from the inventory.
					// Just subtract the count from inspectedItem.
					inspectedItem.Count -= count;
					result.Count = count;
				}
				else if (inspectedItem.Count == count)
				{
					// Remove the item completely
					result.Count = count;
					remove = inspectedItem;
				}
				else
				{
					// Can't get enough of these items from the inventory. Return all there
					// is and remove the item.
					result.Count = inspectedItem.Count;
					remove = inspectedItem;
				}

				break; // Early exit
			}
		}

		if (remove != null)
		{
			// Let's remove the item
			Items.Remove(remove);
		}

		return result;


	}
	public List<IItem> GetItems()
	{
		// Creates a copy of the existing item list.
		List<IItem> result = new List<IItem>(Items);
		// Clear the original list.
		Items.Clear();
		// Return the copy.
		return result;
	}

}
