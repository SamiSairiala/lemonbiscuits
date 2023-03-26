using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace Quests
{


	public class CollectionGoal : Goal
	{
		public int CurrentItemsAmount;
		public string ItemName { get; set; }
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
            this.CurrentAmount = 0;
            Debug.Log("Init COLLECTION GOAL");
			base.Init();
			ItemPickup.OnItemAddedToInventory += ItemPickedup; // Add an event on when player picksup calls ItemPickedup method.
			FishingProjectile.OnItemAddedToInventory += ItemPickedup;
			for(int i = 0; i < RequiredAmount + 1; i++)
			{
                CheckForItemsOnStart(Item);
            }

			
        }
		
		// Checks if players has gotten the items before accepting quest
		public void CheckForItemsOnStart(Item item) // TODO: FIX THIS!
		{
			//for (int i = 0; i < RequiredAmount + 1; i++)
			//{
				if (InventoryManager.Instance.Items.Contains(item))
				{
					
					this.CurrentAmount++;
					Debug.Log(CurrentAmount + " From inventory");
				//InventoryManager.Instance.Remove(item); 
				//return true;
					Evaluate(item);
				}
			
			Debug.Log("Checking items in for loop");
            
            

        }

		// IMPORTANT: CURRENTLY DELETING ITEMS IN QuestNPC class.

		void ItemPickedup(Item item)
		{
			if (item.name.Equals(this.ItemName))
			{
				
                
                this.CurrentAmount++;
                Debug.Log(this.CurrentAmount + " Current amount");
				#region TEST!
				//if (CurrentAmount <= RequiredAmount + 1)
				//{
				//	Debug.Log("Ascessing deleting");
				//	Debug.Log(item);
    //                if (InventoryManager.Instance.Items.Contains(item))
    //                {
    //                    Debug.Log("Deleting item");
    //                    InventoryManager.Instance.Remove(item);
    //                }
    //            }
				#endregion
				Evaluate(item);
			}
		}
	}

}
