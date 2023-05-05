using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quests;

public class Infestation : NewQuest
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
        requiredItem = questItems.RareFlower;
        rewardItem = questItems.Coin;
        QuestName = "Infestation";
        QuestDescription = "Get rid of beetles on the Lemon Tree. The tree should drop a sign of healing."; 
        ItemReward = rewardItem;
        RequiredAmount = requiredAmount;
        onquest.Twig.GetComponent<CapsuleCollider>().isTrigger = true;
        onquest.Laughy.GetComponent<CapsuleCollider>().isTrigger = false;
        onquest.BeetlesTrigger.SetActive(true);
        Goals.Add(new CollectionGoal(this, requiredItem.name, "Get rid of beetles on the Lemon Tree. The tree should drop a sign of healing.", false, 0, requiredAmount, requiredItem));

        Goals.ForEach(g => g.Init());
    }

    
}
