using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MissingFlowers : NewQuest
{
    
    
    public Item rewardItem;
    public QuestItems questItems;
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Flower;
        rewardItem = questItems.FishingRod;
        Debug.Log(requiredItem.name);
        QuestName = "Missing Flowers";
        QuestDescription = "Gather 2 flowers."; 
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;


        Goals.Add(new CollectionGoal(this, requiredItem.name, "Gather 2 flowers", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }
}
