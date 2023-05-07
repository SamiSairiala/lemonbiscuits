using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
public class CatherSalmon : NewQuest
{
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.salmon;
        rewardItem = questItems.Coin;
        Debug.Log(requiredItem.name);
        QuestName = "Cather Salmon";
        QuestDescription = "Fish 2 Salmon. You can fish salmon from the seaweed pools"; //Required amount + 1.
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;


        Goals.Add(new CollectionGoal(this, requiredItem.name, "Fish 2 Salmon. You can fish salmon from the seaweed pools", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }
}
