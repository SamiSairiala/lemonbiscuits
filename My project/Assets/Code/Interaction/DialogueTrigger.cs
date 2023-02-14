using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasSpoken = false;
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
        //questGiver = GetComponent<QuestGiver>();
        
        
        if (/*questGoal.goalType == GoalType.Gathering && questGoal.CurrentAmount >= questGoal.requiredAmount*/this.Gathering == true && this.currentAmount >= this.RequiredAmount && this.Completed == false)
		{
            hasGottenQuestItems = true;
            Completed = true;
            onquest.onQuest = false;
            isActive = false;
		}
        if(this.Gathering == true && this.hasSpoken == true && this.isActive == true)
        {
            if (InventoryManager.Instance.Items.Contains(this.wantedItem))
            {
                currentAmount++;
                InventoryManager.Instance.Items.Remove(this.wantedItem);
                CurrentQuestProgresstext.text = this.wantedItem + " returned " + /*questGoal.*/this.currentAmount + " / " + /*questGoal.*/this.RequiredAmount;
                //return true;
            }
        }
        if(other.gameObject.tag == "Player")
        {
            
            //Accept.onClick.AddListener(this.GotQuest);
            TriggerDialogue();
            Debug.Log("Starting Dialogue");
            if (/*UpdateQuest == true && questGoal.goalType == GoalType.Gathering */Gathering == true && this.isActive == true)
            {
                CurrentQuestProgresstext.text = this.wantedItem + " returned 0 / " + this.RequiredAmount;
            }
        }
    }
    private void Update()
    {
        if (this.hasSpoken == false && this.hasGottenQuestItems == false && onquest.onQuest == false && this.Completed == false)
        {

            if (interaction.action.WasPressedThisFrame())
            {
                Debug.Log("Pressed E");
                this.GotQuest();
            }
        }
        if (this.hasSpoken == true && this.Completed == false)
        {
            if (interaction.action.WasPressedThisFrame())
            {
                this.TurnInItems();
            }
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
        if(this.hasSpoken  == false && this.hasGottenQuestItems == false && onquest.onQuest == false && this.Completed == false)
        {
            
            Accept.gameObject.SetActive(true);
            Next.gameObject.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            TurnIn.gameObject.SetActive(false);
        }
        if(this.hasSpoken == true && this.Completed == false)
        {
            isActive = true;
            onquest.onQuest = true;
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            CurrentQuesttext.text = "Gather " + /*questGoal.*/this.RequiredAmount + this.wantedItem;
            
            TurnIn.gameObject.SetActive(true);
            
            //TurnIn.onClick.AddListener(this.TurnInItems);
            UpdateQuest = false;
        }
        if (this.hasGottenQuestItems == true && this.Completed == false && this.hasSpoken == true)
        {
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Accept.gameObject.SetActive(false);
            TurnIn.gameObject.SetActive(false);
            CurrentQuesttext.text = "";
            CurrentQuestProgresstext.text = "";
            Completed = true;
            onquest.onQuest = false;
        }
        if(this.onquest.onQuest == true && this.isActive == false)
        {
            FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            TurnIn.gameObject.SetActive(false);
        }
        if(this.Completed == true && this.hasGottenQuestItems == true)
        {
            FindObjectOfType<DialogueManager>().CompletedQuest = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }


    }
    public void GotQuest()
    {

        player.quest = quest;
        player.quest.isActive = true;
        this.hasSpoken = true;
        this.isActive = true;

    }
}
