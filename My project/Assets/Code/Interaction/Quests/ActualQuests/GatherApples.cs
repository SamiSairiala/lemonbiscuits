using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class GatherApples : NewQuest
{

    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 5; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    // Start is called before the first frame update
    void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Apple;
        rewardItem = questItems.ApplePie;
        QuestName = "Cather Apples";
        QuestDescription = "Gather 5 apples."; 
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;

        Goals.Add(new CollectionGoal(this, requiredItem.name, "Gather 5 apples.", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }

    
}
