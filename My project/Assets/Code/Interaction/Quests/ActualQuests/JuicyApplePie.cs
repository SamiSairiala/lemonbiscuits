using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class JuicyApplePie : NewQuest
{
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public int requiredAmount = 1; // Invisible + 1 from somewhere so if you want to only to require 2 write 1 here. // TODO: Found the issue need to think of a fix 
    public OnQuest onquest;
    // Start is called before the first frame update
    void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        onquest = FindObjectOfType<OnQuest>();
        requiredItem = questItems.ApplePie;
        rewardItem = questItems.Coin;
        QuestName = "Juicy Apple Pie";
        QuestDescription = "Talk to Rockie Again.";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;
        onquest.RockieQuestIndicator.SetActive(false);
        Goals.Add(new CollectionGoal(this, requiredItem.name, "Talk to Rockie Again.", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }

    }