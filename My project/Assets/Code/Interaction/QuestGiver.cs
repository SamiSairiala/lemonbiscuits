using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
	public Quest quest;

	public PlayerMovement player;

	private DialogueTrigger dialogue;
	//public Dialogue Dialogue;
	public Item requiredItem;

	public Button AcceptQuest;

	//public bool AssignedQuest { get; set; }
	//public bool Helped { get; set; }
	//[SerializeField]
	//private GameObject quests;
	//[SerializeField]
	//private string questType;
	//public NewQuest Quest { get; set; }
	private void Awake()
	{
		//dialogue = GetComponent<DialogueTrigger>();
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {

			AcceptQuest.onClick.AddListener(GotQuest);
			//if (!AssignedQuest && !Helped)
			//{
			//    AssignQuest();
			//    FindObjectOfType<DialogueManager>().hasSpoken = false;
			//    FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
			//}
			//else if (AssignedQuest && !Helped)
			//{

			//    FindObjectOfType<DialogueManager>().hasSpoken = true;
			//    FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
			//    FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
			//    CheckQuest();
			//}
			//else
			//{
			//    FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
			//    FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
			//}
		}
		

	}

	//void AssignQuest()
	//{
	//	AssignedQuest = true;
	//	Quest = quests.GetComponent < MissingFlowers > ();

	//}

	//void CheckQuest()
	//{
		
	//	if (Quest.Completed)
	//	{
	//		Quest.GiveReward();
	//		Helped = true;
	//		AssignedQuest = false;
 //           FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
 //           FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
 //       }
	//	else
	//	{
 //           FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
 //           FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
 //       }
	//}


	public void GotQuest()
	{

		player.quest = quest;
		player.quest.isActive = true;
		dialogue.hasSpoken = true;

	}


}
