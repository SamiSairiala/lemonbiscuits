using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class MissingFlowers : NewQuest
{
    
    public Item requiredItem;
    public Item rewardItem;
    public QuestItems questItems;
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Flower;
        rewardItem = questItems.Coin;
        Debug.Log(requiredItem.name);
        QuestName = "Missing Flowers";
        QuestDescription = "Gather 2 flowers for Mike";
        ItemReward = rewardItem;


        Goals.Add(new CollectionGoal(this, requiredItem.name, "Gather 2 flowers", false, 0, 1, requiredItem));

        Goals.ForEach(g => g.Init());
    }
}
