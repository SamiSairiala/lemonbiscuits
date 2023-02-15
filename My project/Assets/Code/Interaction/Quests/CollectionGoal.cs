using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests{


public class CollectionGoal : Goal
{
    public Item requiredItem;
    public CollectionGoal(/*NewQuest quest,*/Item requiredItem , string description, bool completed, int currentAmount, int requiredAmount)
    {
        
        this.requiredItem = requiredItem;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        Debug.Log("Init COLLECTION GOAL");
        base.Init();
            ItemPickup.OnItemAddedToInventory += ItemPickedup;
        
    }

    
    public bool CheckForItem(Item requiredItem)
    {
        if (InventoryManager.Instance.Items.Contains(requiredItem))
        {
            CurrentAmount++;
            Evaluate();
            InventoryManager.Instance.Items.Remove(requiredItem);
            return true;
        }
        else
        {
            return false;
        }
    }

    void ItemPickedup(Item item)
    {
        if(item.ID == this.requiredItem.ID)
        {
            this.CurrentAmount++;
            Evaluate();
        } 
    }
}
   
}
