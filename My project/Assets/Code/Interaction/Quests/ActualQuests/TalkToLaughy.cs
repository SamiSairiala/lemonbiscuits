using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TalkToLaughy : NewQuest
{

    public GameObject npc;
    public Item rewardItem;
    public QuestItems questItems; // Quest items is here to get easy reference to needed items/npcs and other stuff that is needed in quest.
    public OnQuest onquest;
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only require 2 write 1 here.
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        onquest = FindObjectOfType<OnQuest>();
        npc = questItems.NPC3;
        onquest.TalkQuest = true;
        rewardItem = questItems.Coin;
        //Debug.Log(requiredItem.name);
        QuestName = "Talk To Laughy";
        QuestDescription = "Talk to Laughy.";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;

        Goals.Add(new TalkGoal(this, "Talk to Laughy.", false, 0, 1, npc));


        Goals.ForEach(g => g.Init());
    }
}
