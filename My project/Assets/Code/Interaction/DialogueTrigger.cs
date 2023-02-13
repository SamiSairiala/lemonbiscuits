using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasSpoken = false;
    public bool hasGottenQuestItems = false;
    private QuestGiver questGiver;
    public QuestGoal questGoal;
    public Item wantedItem;
    [Header("UI Buttons")]
    public Button Next;
    public Button Accept;
    public Button TurnIn;
    
    // CHANGE THIS TO DIFFRENT METHOD OF STARTING DIALOGUE.
    private void OnTriggerEnter(Collider other)
    {
        questGiver = GetComponent<QuestGiver>();
        TurnIn.onClick.AddListener(TurnInItems);

        if (questGoal.goalType == GoalType.Gathering && questGoal.CurrentAmount >= questGoal.requiredAmount)
		{
            hasGottenQuestItems = true;
		}
        if(other.gameObject.tag == "Player")
        {
            TriggerDialogue();
            Debug.Log("Starting Dialogue");
        }
    }
    
    public void TurnInItems()
    {
        if (questGoal.goalType == GoalType.Gathering)
        {
            
            questGoal.CheckForItem(wantedItem);

        }
    }

    public void TriggerDialogue()
    {
        if(hasSpoken  == false && hasGottenQuestItems == false)
        {
            Next.gameObject.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            TurnIn.gameObject.SetActive(false);
        }
        if(hasSpoken == true)
        {
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            TurnIn.gameObject.SetActive(true);
        }
        if (hasGottenQuestItems == true)
        {
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            TurnIn.gameObject.SetActive(false);
        }

    }
}
