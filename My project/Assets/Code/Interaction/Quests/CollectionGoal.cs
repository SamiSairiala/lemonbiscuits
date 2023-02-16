using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests{


public class CollectionGoal : Goal
{
        public int CurrentItemsAmount;
    public string ItemName { get; set; }
    public CollectionGoal(NewQuest quest, string itemName , string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemName = itemName;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
            CurrentItemsAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }
        // required items is for example if you need 2 then just - 1 and put 1 into required items when you in reality need 2.
        // In specific quests when you add Goals.
        public override void Init()
    {
        Debug.Log("Init COLLECTION GOAL");
        base.Init();
            ItemPickup.OnItemAddedToInventory += ItemPickedup;
        
    }

    

    void ItemPickedup(Item item)
    {
        if(item.name.Equals(this.ItemName))
        {
            this.CurrentAmount++;
            Evaluate(item);
        } 
    }
}
   
}
