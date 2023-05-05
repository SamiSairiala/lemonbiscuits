using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class LostAmulet : NewQuest
{
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 1; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    // Start is called before the first frame update
    void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        requiredItem = questItems.Fishpie;
        rewardItem = questItems.Coin;
        QuestName = "Lost Amulet";
        QuestDescription = "Follow the footsteps at night to find the amulet";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;
        FindObjectOfType<NightQuest>().QuestActive = true;
        Goals.Add(new CollectionGoal(this, requiredItem.name, "Follow the footsteps at night to find the amulet", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }

	private void Update()
	{
		
	}

}