using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
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
            // Remove items from inventory if not gotten quest complete straight from inventory.

            // This didint work since it deletes objects as soon as you pick them up.
            //for(int i = 0; i < RequiredAmount; i++)
            //{
            //    if (InventoryManager.Instance.Items.Contains(item))
            //    {
            //        Debug.Log("Removed item");
            //        InventoryManager.Instance.Items.Remove(item);
            //    }
            //}
            
            Debug.Log(CurrentAmount + " Current amount");
            if (CurrentAmount >= RequiredAmount)
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
}
