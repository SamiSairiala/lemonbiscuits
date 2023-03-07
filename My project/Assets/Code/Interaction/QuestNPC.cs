<<<<<<< HEAD
using Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour
{
    public Dialogue dialogue;
    public int currentAmount;
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField] private GameObject quests;
    [SerializeField] private string questName; // Type quest name in editor that then gets taken from quests gameobject and activated.
    public NewQuest Quest { get; set; }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            if (!AssignedQuest && !Helped)
            {
                // Assign quest to player.
                AssignQuest();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else if(AssignedQuest && !Helped)
            {
                // Has given quest but not completed yet.
                // Also checks if quest is completed.
                CheckQuest();
                Debug.Log("Checking quest");
            }
            else
            {
                FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
                FindObjectOfType<DialogueManager>().CompletedQuest = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }


    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
        Debug.Log("Assigned quest");
    }

    void CheckQuest()
    {
        
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Debug.Log("Quest completed");
            Helped = true;
            AssignedQuest = false;
            currentAmount = 0;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
using Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestNPC : MonoBehaviour
{
    public Dialogue dialogue;
    public int currentAmount;
    public bool AssignedQuest { get; set; }
    public bool DiffrentQuest = false;
    public bool Helped { get; set; }

    [SerializeField] private InputActionReference interaction;
    public OnQuest onQuest;

    [SerializeField] private GameObject quests;
    [SerializeField] private string questName; // Type quest name in editor that then gets taken from quests gameobject and activated.
    public NewQuest Quest { get; set; }
    // Start is called before the first frame update



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
        if(other.gameObject.tag == "Player")
        {
            

                if (!AssignedQuest && !Helped && !onQuest.onQuest)
                {
                
                    // Assign quest to player.
                    AssignQuest();
                    onQuest.onQuest = true;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
                else if (AssignedQuest && !Helped)
                {
                    // Has given quest but not completed yet.
                    // Also checks if quest is completed.
                    CheckQuest();
                    Debug.Log("Checking quest");
                }
                else if (!AssignedQuest && !Helped && onQuest.onQuest)
                {
                Debug.Log("Diffrent quest");
                    FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
                else
                {
                Debug.Log("Meeting after completing");
                    FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = true;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
            

            
            
        }
    }

    
    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
        Debug.Log("Assigned quest");
    }

    void CheckQuest()
    {
        
        if (Quest.Completed)
        {
            onQuest.onQuest = false;
            Quest.GiveReward();
            Debug.Log("Quest completed");
            Helped = true;
            AssignedQuest = false;
            currentAmount = 0;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else
        {
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
>>>>>>> main
