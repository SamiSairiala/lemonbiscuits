using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MissingGrass : NewQuest
{
    
    public Item requiredItem;
    public Item rewardItem;
    public QuestItems questItems;
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only require 2 write 1 here.
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Flower;
        rewardItem = questItems.Coin;
        Debug.Log(requiredItem.name);
        QuestName = "Missing Grass";
        QuestDescription = "Gather 2 Grass for Jeff";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;

        Goals.Add(new CollectionGoal(this, requiredItem.name, "Gather 2 grass", false, 0, requiredAmount, requiredItem));
        

        Goals.ForEach(g => g.Init());
    }
}
