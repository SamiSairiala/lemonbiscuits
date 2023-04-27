using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;
public class CatherFish : NewQuest
{
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Fish;
        rewardItem = questItems.Coin;
        Debug.Log(requiredItem.name);
        QuestName = "Cather Fish";
        QuestDescription = "Fish 2 fish."; //Required amount + 1.
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;


        Goals.Add(new CollectionGoal(this, requiredItem.name, "Fish 2 Fish", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }
}
