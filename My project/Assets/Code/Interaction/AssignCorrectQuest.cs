using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class AssignCorrectQuest : MonoBehaviour
{
    private DialogueTrigger trigger;
    
    public OnQuest onquest;

    public TextMeshProUGUI CurrentQuesttext;
    public TextMeshProUGUI CurrentQuestProgresstext;
    [SerializeField] private InputActionReference interaction;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }
	private void Awake()
	{
        trigger = GetComponent<DialogueTrigger>();
    }
	private void OnEnable()
    {
        interaction.action.Enable();

    }
    private void OnDisable()
    {
        interaction.action.Disable();

    }
    private void OnTriggerEnter(Collider other)
    {
        //questGiver = GetComponent<QuestGiver>();


        if (/*questGoal.goalType == GoalType.Gathering && questGoal.CurrentAmount >= questGoal.requiredAmount*/trigger.Gathering == true && trigger.currentAmount >= trigger.RequiredAmount && trigger.Completed == false)
        {
            trigger.hasGottenQuestItems = true;
            trigger.Completed = true;
            onquest.onQuest = false;
            trigger.isActive = false;
        }
        if (trigger.Gathering == true && trigger.hasSpoken == true && trigger.isActive == true)
        {
            if (InventoryManager.Instance.Items.Contains(trigger.wantedItem))
            {
                trigger.currentAmount++;
                InventoryManager.Instance.Items.Remove(trigger.wantedItem);
                CurrentQuestProgresstext.text = trigger.wantedItem + " returned " + /*questGoal.*/trigger.currentAmount + " / " + /*questGoal.*/trigger.RequiredAmount;
                //return true;
            }
        }
        if (other.gameObject.tag == "Player")
        {

            //Accept.onClick.AddListener(this.GotQuest);
            trigger.TriggerDialogue();
            Debug.Log("Starting Dialogue" + this.gameObject.name);
            if (/*UpdateQuest == true && questGoal.goalType == GoalType.Gathering */trigger.Gathering == true && trigger.isActive == true)
            {
                CurrentQuestProgresstext.text = trigger.wantedItem + " returned 0 / " + trigger.RequiredAmount;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (trigger.hasSpoken == false && trigger.hasGottenQuestItems == false && onquest.onQuest == false && trigger.Completed == false)
        {

            if (interaction.action.WasPressedThisFrame())
            {
                Debug.Log("Pressed E");
                trigger.GotQuest();
            }
        }
        if (trigger.hasSpoken == true && trigger.Completed == false)
        {
            if (interaction.action.WasPressedThisFrame())
            {
                trigger.TurnInItems();
            }
        }
    }
}
