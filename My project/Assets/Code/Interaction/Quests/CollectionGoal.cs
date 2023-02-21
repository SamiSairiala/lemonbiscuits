using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Progress;

namespace Quests
{


	public class CollectionGoal : Goal
	{
		public int CurrentItemsAmount;
		public string ItemName { get; set; }
		public Item Item { get; set; }
		public CollectionGoal(NewQuest quest, string itemName, string description, bool completed, int currentAmount, int requiredAmount, Item item)
		{
			this.Quest = quest;
			this.ItemName = itemName;
			this.Description = description;
			this.Completed = completed;
			this.CurrentAmount = currentAmount;
			CurrentItemsAmount = currentAmount;
			this.RequiredAmount = requiredAmount;
			this.Item = item;
		}
		// required items is for example if you need 2 then just - 1 and put 1 into required items when you in reality need 2.
		// In specific quests when you add Goals.
		public override void Init()
		{
			Debug.Log("Init COLLECTION GOAL");
			base.Init();
			ItemPickup.OnItemAddedToInventory += ItemPickedup;
			for(int i = 0; i < RequiredAmount + 1; i++)
			{
                CheckForItemsOnStart(Item);
            }
			

        }
		
		public void CheckForItemsOnStart(Item item)
		{
			Debug.Log("Checking items in for loop");
            if (InventoryManager.Instance.Items.Contains(item))
            {

                this.CurrentAmount++;
                Debug.Log(CurrentAmount + " From inventory");
                InventoryManager.Instance.Items.Remove(item);
				//return true;
				Evaluate(item);
            }
            

        }



		void ItemPickedup(Item item)
		{
			if (item.name.Equals(this.ItemName))
			{
				this.CurrentAmount++;
				Evaluate(item);
			}
		}
	}

}
