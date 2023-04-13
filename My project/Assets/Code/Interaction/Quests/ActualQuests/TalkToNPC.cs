using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TalkToNPC : NewQuest
{

    public GameObject npc;
    public Item rewardItem;
    public QuestItems questItems;
    public OnQuest onquest;
    public int requiredAmount = 2; // Invisible + 1 from somewhere so if you want to only require 2 write 1 here.
    private void Start()
    {
        questItems = FindObjectOfType<QuestItems>();
        onquest = FindObjectOfType<OnQuest>();
        npc = questItems.NPC1;
        onquest.TalkQuest = true;
        rewardItem = questItems.Coin;
        //Debug.Log(requiredItem.name);
        QuestName = "Talk To NPC";
        QuestDescription = "Talk to Jeff about the next step";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;

        Goals.Add(new TalkGoal(this, "Talk to Jeff", false, 0, 1, npc));


        Goals.ForEach(g => g.Init());
    }
}
