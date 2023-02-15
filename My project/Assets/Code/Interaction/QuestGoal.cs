using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
	public GoalType goalType;
	public int requiredAmount;
	public int CurrentAmount;
	public Item wantedItem;

	public bool isReached()
	{
		
		return (CurrentAmount >= requiredAmount);
	}

	

	public bool CheckForItem(Item wantedItem)
	{
		if (InventoryManager.Instance.Items.Contains(wantedItem))
		{
			CurrentAmount++;
			InventoryManager.Instance.Items.Remove(wantedItem);
			return true;
		}
		else
		{
			return false;
		}
	}



}


public enum GoalType
{
	Gathering
}