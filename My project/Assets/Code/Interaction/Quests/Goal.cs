using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public NewQuest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        //Default init

    }

    public void Evaluate(Item item)
    {
        if (InventoryManager.Instance.Items.Contains(item))
        {

            CurrentAmount++;
            Debug.Log(CurrentAmount + " From inventory");
            InventoryManager.Instance.Items.Remove(item);
            //return true;
        }
        Debug.Log(CurrentAmount + " Current amount");
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        this.Quest.CheckGoals();
        Completed = true;
        Debug.Log("Goal marked as completed.");
    }
}