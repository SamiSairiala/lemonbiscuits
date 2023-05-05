using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class TalkToRockie : NewQuest
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
        npc = questItems.NPC1;
        onquest.SecondTalkQuest = true;
        rewardItem = questItems.Coin;
        //Debug.Log(requiredItem.name);
        QuestName = "Talk To Rockie";
        QuestDescription = "Talk to Rockie.";
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;
        onquest.Rockie.GetComponent<CapsuleCollider>().isTrigger = true;
        Goals.Add(new TalkGoal(this, "Talk to Rockie.", false, 0, 1, npc));


        Goals.ForEach(g => g.Init());
    }
}
