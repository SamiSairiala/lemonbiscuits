using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuest : MonoBehaviour
{
    public bool onQuest = false;

	public bool TalkQuest = false;
	public bool SecondTalkQuest = false;

	public bool TwigQuest = false; // THESE ARE USED TO TELL SCRIPT WHO GIVES NEXT QUEST.
	public bool RockieQuest = false;
	public bool LaughyQuest = false; 

	public bool RiddleQuest = false;

	public bool RiddleQuestCompleted = false;

	public GameObject Laughy;
	public GameObject Rockie;
	public GameObject Twig;

	public GameObject BeetlesTrigger;

	public Riddle riddle;
 //   public int RequiredAmount = 0;
 //   public Item requiredItem;
	//private int currentAmount = 0;


	private void Update()
	{
		//if(onQuest == false)
		//{
		//	requiredItem = null;
		//	//RequiredAmount = 0;
		//	//currentAmount = 0;
		//}
		//if(onQuest == true)
		//{
		//	if (InventoryManager.Instance.Items.Contains(requiredItem))
		//	{
		//		currentAmount++;
		//	}
		//}

	}
}
