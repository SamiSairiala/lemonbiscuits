using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MissingFlowers : NewQuest
{
    public Item rewardItem;
    public Item requiredItem;
    
    private void Start()
    {
        QuestName = "Missing Flowers";
        QuestDescription = "Gather 4 flowers for Mike";
        ItemReward = rewardItem;
        

        Goals.Add(new CollectionGoal(requiredItem, "Gather 4 flowers", false, 0, 4));

        Goals.ForEach(g => g.Init());
    }
}
