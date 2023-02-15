using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewQuest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string QuestDescription { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }
    public Item requiredItem { get; set; }


    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed)
        {
            GiveReward();
        }
    }

    



    public void GiveReward()
    {
        if(ItemReward != null)
        {
            InventoryManager.Instance.Add(ItemReward);
        }
    }

    


}
