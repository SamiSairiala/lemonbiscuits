using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasSpoken = false;
    public bool hasGottenQuestItems = false;
    private QuestGiver questGiver;
    public QuestGoal questGoal;
    public Item wantedItem;
    // CHANGE THIS TO DIFFRENT METHOD OF STARTING DIALOGUE.
    private void OnTriggerEnter(Collider other)
    {
        questGiver = GetComponent<QuestGiver>();
        
        if(questGoal.goalType == GoalType.Gathering)
		{
            questGoal.CheckForItem(wantedItem);
            
		}
        if(questGoal.goalType == GoalType.Gathering && questGoal.CurrentAmount >= questGoal.requiredAmount)
		{
            hasGottenQuestItems = true;
		}
        if(other.gameObject.tag == "Player")
        {
            TriggerDialogue();
            Debug.Log("Starting Dialogue");
        }
    }
    
    

    public void TriggerDialogue()
    {
        if(hasSpoken  == false && hasGottenQuestItems == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
        }
        if(hasSpoken == true)
        {
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
        }
        if (hasGottenQuestItems == true)
        {
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }
}
