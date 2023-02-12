using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerMovement player;

    private DialogueTrigger dialogue;

	public Button AcceptQuest;


	private void Awake()
	{
		dialogue = GetComponent<DialogueTrigger>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			AcceptQuest.onClick.AddListener(GotQuest);
		}
	}


	public void GotQuest()
	{
		
		player.quest = quest;
		player.quest.isActive = true;
		dialogue.hasSpoken = true;
		
	}


}
