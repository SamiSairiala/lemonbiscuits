using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class Healing : NewQuest
{
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 4; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    // Start is called before the first frame update
    void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.RareFlower;
        rewardItem = questItems.Coin;
        QuestName = "Healing";
        QuestDescription = "Gather 4 Reddish colored flowers to heal the lemon tree";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;
        FindObjectOfType<QuestItems>().RareFlowersHolder.SetActive(true);
        
        Goals.Add(new CollectionGoal(this, requiredItem.name, "Gather 4 Reddish colored flowers to heal the lemon tree", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }

	private void Update()
	{
		
	}

}