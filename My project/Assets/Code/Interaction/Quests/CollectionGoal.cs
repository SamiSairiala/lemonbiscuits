using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using UnityEngine;
=======
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Progress;
>>>>>>> main

namespace Quests
{


	public class CollectionGoal : Goal
	{
		public int CurrentItemsAmount;
		public string ItemName { get; set; }
<<<<<<< HEAD
		public CollectionGoal(NewQuest quest, string itemName, string description, bool completed, int currentAmount, int requiredAmount, Item requiredItem)
=======
		public Item Item { get; set; }
		public CollectionGoal(NewQuest quest, string itemName, string description, bool completed, int currentAmount, int requiredAmount, Item item)
>>>>>>> main
		{
			this.Quest = quest;
			this.ItemName = itemName;
			this.Description = description;
			this.Completed = completed;
			this.CurrentAmount = currentAmount;
			CurrentItemsAmount = currentAmount;
			this.RequiredAmount = requiredAmount;
<<<<<<< HEAD
			this.RequiredItem = requiredItem;
=======
			this.Item = item;
>>>>>>> main
		}
		// required items is for example if you need 2 then just - 1 and put 1 into required items when you in reality need 2.
		// In specific quests when you add Goals.
		public override void Init()
		{
			Debug.Log("Init COLLECTION GOAL");
			base.Init();
<<<<<<< HEAD
			ItemPickup.OnItemAddedToInventory += ItemPickedup;
			CheckInv(RequiredItem);
		}
=======
			ItemPickup.OnItemAddedToInventory += ItemPickedup; // Add an event on when player picksup calls ItemPickedup method.
			for(int i = 0; i < RequiredAmount + 1; i++)
			{
                CheckForItemsOnStart(Item);
            }
			

        }
		
		// Checks if players has gotten the items before accepting quest
		public void CheckForItemsOnStart(Item item)
		{
			//for (int i = 0; i < RequiredAmount + 1; i++)
			//{
				if (InventoryManager.Instance.Items.Contains(item))
				{

					this.CurrentAmount++;
					Debug.Log(CurrentAmount + " From inventory");
                    InventoryManager.Instance.Items.Remove(item);
                    //return true;
                    Evaluate(item);
				}
			
			Debug.Log("Checking items in for loop");
            
            

        }
>>>>>>> main

		void CheckInv(Item item)
		{
			for(int i = 0; i < RequiredAmount; i++)
			{
				if (InventoryManager.Instance.Items.Contains(item))
				{

					this.CurrentAmount++;
					Debug.Log(CurrentAmount + " From inventory");
					Evaluate(item);

					//return true;
				}
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
