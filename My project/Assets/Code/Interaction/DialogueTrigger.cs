using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasGottenQuest = false;
    public bool hasGottenQuestItems = false;
    public bool UpdateQuest = true;
    public bool isActive = false;
    [SerializeField] private InputActionReference interaction;

    public int RequiredAmount;
    public int currentAmount;
    [Header("Quest Types")]
    public bool Gathering = false;
    
    //private QuestGiver questGiver;
    //public QuestGoal questGoal;
    public Item wantedItem;
    public Quest quest;
    public bool Completed = false;
    public OnQuest onquest;
    [Header("UI Buttons")]
    public Button Next;
    public Button Accept;
    public Button TurnIn;
    public PlayerMovement player;

    private AssignCorrectQuest Correct;

    public TextMeshProUGUI CurrentQuesttext;
    public TextMeshProUGUI CurrentQuestProgresstext;
    private void OnEnable()
    {
        interaction.action.Enable();
        
    }
    private void OnDisable()
    {
        interaction.action.Disable();
        
    }
    // CHANGE THIS TO DIFFRENT METHOD OF STARTING DIALOGUE.
    private void OnTriggerEnter(Collider other)
    {
        Correct = GetComponent<AssignCorrectQuest>();
        Correct.enabled = true;
  //      //questGiver = GetComponent<QuestGiver>();
        
        
  ////      if (/*questGoal.goalType == GoalType.Gathering && questGoal.CurrentAmount >= questGoal.requiredAmount*/this.Gathering == true && this.currentAmount >= this.RequiredAmount && this.Completed == false)
		////{
  ////          hasGottenQuestItems = true;
  ////          Completed = true;
  ////          onquest.onQuest = false;
  ////          isActive = false;
		////}
  ////      if(this.Gathering == true && this.hasSpoken == true && this.isActive == true)
  ////      {
  ////          if (InventoryManager.Instance.Items.Contains(this.wantedItem))
  ////          {
  ////              currentAmount++;
  ////              InventoryManager.Instance.Items.Remove(this.wantedItem);
  ////              CurrentQuestProgresstext.text = this.wantedItem + " returned " + /*questGoal.*/this.currentAmount + " / " + /*questGoal.*/this.RequiredAmount;
  ////              //return true;
  ////          }
  ////      }
  ////      if(other.gameObject.tag == "Player")
  ////      {
            
  ////          //Accept.onClick.AddListener(this.GotQuest);
  ////          TriggerDialogue();
  ////          Debug.Log("Starting Dialogue" + this.gameObject.name);
  ////          if (/*UpdateQuest == true && questGoal.goalType == GoalType.Gathering */Gathering == true && this.isActive == true)
  ////          {
  ////              CurrentQuestProgresstext.text = this.wantedItem + " returned 0 / " + this.RequiredAmount;
  ////          }
  //      }
    }
    private void Update()
    {
        //if (this.hasSpoken == false && this.hasGottenQuestItems == false && onquest.onQuest == false && this.Completed == false)
        //{

        //    if (interaction.action.WasPressedThisFrame())
        //    {
        //        Debug.Log("Pressed E");
        //        this.GotQuest();
        //    }
        //}
        //if (this.hasSpoken == true && this.Completed == false)
        //{
        //    if (interaction.action.WasPressedThisFrame())
        //    {
        //        this.TurnInItems();
        //    }
        //}
        if(hasGottenQuestItems == true)
		{
            Invoke("InvokeCompleted", 5f);
		}


    }
    public void TurnInItems()
    {
        if (Gathering == true/*questGoal.goalType == GoalType.Gathering*/)
        {
            ///*public*/ bool CheckForItem(Item wantedItem)
            //{
                if (InventoryManager.Instance.Items.Contains(this.wantedItem))
                {
                    currentAmount++;
                    InventoryManager.Instance.Items.Remove(this.wantedItem);
                    //return true;
                }
                //else
                //{
                //    return false;
                //}
            //}
            //questGoal.CheckForItem(wantedItem);
            CurrentQuestProgresstext.text = this.wantedItem + " returned " + /*questGoal.*/this.currentAmount + " / " + /*questGoal.*/this.RequiredAmount;
        }
    }

    public void TriggerDialogue()
    {
        if(this.hasGottenQuest  == false && this.hasGottenQuestItems == false && onquest.onQuest == false && this.Completed == false)
        {
            Correct.enabled = true;
            Debug.Log("First time speaking");
            Accept.gameObject.SetActive(true);
            Next.gameObject.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            TurnIn.gameObject.SetActive(false);
        }
        if(this.hasGottenQuest == true && this.Completed == false)
        {
            Debug.Log("Activating quest");
            isActive = true;
            Correct.enabled = true;
            onquest.onQuest = true;
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            if(Gathering == true)
            {
                CurrentQuesttext.text = "Gather " + /*questGoal.*/this.RequiredAmount + this.wantedItem;
            }
            
            
            TurnIn.gameObject.SetActive(true);
            
            //TurnIn.onClick.AddListener(this.TurnInItems);
            UpdateQuest = false;
        }
        if (this.hasGottenQuestItems == true && this.Completed == false && this.hasGottenQuest == true)
        {
            Debug.Log("Quest items returned.");
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            TurnIn.gameObject.SetActive(false);
            CurrentQuesttext.text = "";
            CurrentQuestProgresstext.text = "";
            //Completed = true;
            isActive = false;
            Correct.enabled = false;
            onquest.onQuest = false;
        }
        if(this.onquest.onQuest == true && this.isActive == false)
        {
            Debug.Log("on Diffrent quest");
            FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            TurnIn.gameObject.SetActive(false);
        }
        if(this.Completed == true && this.hasGottenQuestItems == true && this.hasGottenQuest == true && this.isActive == false)
        {
            Debug.Log("Completed quest");
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().CompletedQuest = true;
            Correct.enabled = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }


    }

   void InvokeCompleted()
	{
        isActive = false;
        Completed = true;
	}

    public void GotQuest()
    {

        player.quest = quest;
        player.quest.isActive = true;
        this.hasGottenQuest = true;
        this.isActive = true;

    }
}
