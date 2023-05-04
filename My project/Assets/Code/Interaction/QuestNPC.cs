using Quests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class QuestNPC : MonoBehaviour
{
    public Dialogue dialogue;
    public int currentAmount;
    public bool AssignedQuest { get; set; }
    public bool DiffrentQuest = false;
    public bool Helped { get; set; }

    public bool hasQuestionQuest = false;
    public bool QuestionQuest = false;

    [SerializeField] private InputActionReference interaction;
    public OnQuest onQuest;
    public GameObject Quests;
    public QuestItems questItems;

    [SerializeField] private GameObject quests;
    [SerializeField] private string questName; // Type quest name in editor that then gets taken from quests gameobject and activated.
    [SerializeField] private string secondquestName;
    [SerializeField] private string thirdquestName;
    [SerializeField] private string fourthquestName;
    public NewQuest Quest { get; set; }

    public TextMeshProUGUI CurrentQuesttext;
    public TextMeshProUGUI CurrentQuestProgresstext;




    public bool hasSecondQuest = false;
    public bool secondQuestActive = false;
    public bool hasThirdQuest = false;
    public bool thirdQuestActive = false;
    public bool hasFourthQuest = false;
    public bool FourthQuestActive = false;
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
       


            if (other.gameObject.tag == "Player")
        {


            //if(this.gameObject.name.Contains("Laughy") && onQuest.LaughyQuest == true)
            //if(this.gameObject.name.Contains("Twig") && onQuest.TwigQuest == true)
            //if(this.gameObject.name.Contains("Rockie") && onQuest.RockieQuest == true)
            FindObjectOfType<DialogueManager>().npcName = dialogue.name;


            if (!AssignedQuest && !Helped && !onQuest.onQuest)
            {
                if (questName.Equals("Riddle"))
                {
                    QuestionQuest = true;
                }
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
            else if (!AssignedQuest && !Helped && onQuest.onQuest && !onQuest.TalkQuest)
            {
                Debug.Log("Diffrent quest");
                FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else if (onQuest.onQuest && onQuest.TalkQuest)
            {
                Debug.Log("Talk quest");
                FindObjectOfType<DialogueManager>().hasSpoken = false;
                FindObjectOfType<DialogueManager>().SecondQuest = false;
                FindObjectOfType<DialogueManager>().TalkQuest = true;
                FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

                if (onQuest.TalkQuest == true)
                {
                    onQuest.TalkQuest = false;
                }


            }
            else if (onQuest.onQuest && onQuest.SecondTalkQuest)
            {
                
                Debug.Log("second Talk quest");
                FindObjectOfType<DialogueManager>().hasSpoken = false;
                FindObjectOfType<DialogueManager>().SecondQuest = false;
                FindObjectOfType<DialogueManager>().SecondTalkQuest = true;
                FindObjectOfType<DialogueManager>().hasDiffrentQuest = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

                if (onQuest.SecondTalkQuest == true)
                {
                    onQuest.SecondTalkQuest = false;
                }


            }
           
            else
            {
                if (hasSecondQuest && secondQuestActive == false && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == false)
                {
                    AssignSecondQuest();
                    onQuest.onQuest = true;
                }
                if (hasThirdQuest && secondQuestActive == true && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == false)
                {
                    AssingThirdQuest();
                    onQuest.onQuest = true;
                }
                if (hasFourthQuest && secondQuestActive == true && thirdQuestActive == true && FourthQuestActive == false && AssignedQuest == false)
                {
                    AssingFourthQuest();
                    onQuest.onQuest = true;
                }
                Debug.Log("Meeting after completing");
                FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
                FindObjectOfType<DialogueManager>().CompletedQuest = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }




        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue(); // Closes dialogue box if player walks away.
        }

    }
    void AssignSecondQuest()
    {
        if (hasQuestionQuest && QuestionQuest)
        {
            Quest = null;
            onQuest.riddle.enabled = true;
            AssignedQuest = true;
        }
        else
        {
            Quest = null;
            AssignedQuest = true;
            secondQuestActive = true;
            Quest = (NewQuest)quests.AddComponent(System.Type.GetType(secondquestName));
            Debug.Log("Assigned quest");
            FindObjectOfType<DialogueManager>().SecondQuest = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            StartCoroutine(UpdateQuestText());
            Helped = false;
        }

    }

    void AssingFourthQuest()
    {
        Quest = null;
        FourthQuestActive = true;
        AssignedQuest = true;
        Quest = (NewQuest)quests.AddComponent(System.Type.GetType(fourthquestName));
        Debug.Log("Assigned quest");
        FindObjectOfType<DialogueManager>().fourthQuest = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StartCoroutine(UpdateQuestText());
        Helped = false;
    }

    void AssingThirdQuest()
    {
        Quest = null;
        thirdQuestActive = true;
        AssignedQuest = true;
        Quest = (NewQuest)quests.AddComponent(System.Type.GetType(thirdquestName));
        Debug.Log("Assigned quest");
        FindObjectOfType<DialogueManager>().ThirdQuest = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StartCoroutine(UpdateQuestText());
        Helped = false;
    }

    void AssignQuest()
    {
        if (hasQuestionQuest && QuestionQuest)
        {
            onQuest.riddle.enabled = true;
            AssignedQuest = true;
        }
        if (questName.Contains("Croissant"))
        {
            InventoryManager.Instance.Add(questItems.Recipe);
            for (int i = 0; i < 5; i++)
            {
                InventoryManager.Instance.Add(questItems.Coin);
            }
            AssignedQuest = true;
            Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
            Debug.Log("Assigned quest");
            StartCoroutine(UpdateQuestText());
        }
        else
        {
            AssignedQuest = true;
            Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
            Debug.Log("Assigned quest");
            StartCoroutine(UpdateQuestText());
        }



    }

    IEnumerator UpdateQuestText()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log(this.Quest.QuestDescription);
        CurrentQuesttext.text = (Quest.QuestDescription.ToString());
    }

    void DeleteItems()
    {
        Item item = null;
        #region Deletes items when quest is completed to not confuse player!
        // This works it just can get quite bloated if many diffrent items needed in diffrent quests.
        // If using this comment out other methods of deleting items from CollectionGoal and Goal.
        if (questName.Contains("Flower") && secondQuestActive == false && thirdQuestActive == false) // If quest item that is required is not in quest name think of another way of doing it.
        {
            Debug.Log("Quest has flowers");
            item = quests.GetComponent<QuestItems>().Flower;

        }
        if (questName.Contains("Croissant") && secondQuestActive == false && thirdQuestActive == false) // If quest item that is required is not in quest name think of another way of doing it.
        {
            Debug.Log("Quest has flowers");
            item = quests.GetComponent<QuestItems>().Croissant;

        }
        if (questName.Contains("Fish") && secondQuestActive == false && thirdQuestActive == false)
        {
            Debug.Log("Quest has fish");
            item = quests.GetComponent<QuestItems>().Fish;
        }
        if (secondquestName.Contains("Flower") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has flowers");
            item = quests.GetComponent<QuestItems>().Flower;
        }
        if (secondquestName.Contains("Fish") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has fish");
            item = quests.GetComponent<QuestItems>().Fish;
        }
        if (secondquestName.Contains("Apple") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has apples");
            item = quests.GetComponent<QuestItems>().Apple;
        }
        if (InventoryManager.Instance.Items.Contains(item))
        {

            for (currentAmount = 0; currentAmount < this.Quest.RequiredAmount; currentAmount++)
            {
                Debug.Log("Deleting items");
                InventoryManager.Instance.Remove(item);
            }


        }

        #endregion
    }

    void CheckQuest()
    {
        if (onQuest.RiddleQuestCompleted)
        {
            onQuest.onQuest = false;
            Helped = true;
            AssignedQuest = false;
            QuestionQuest = false;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        else if (QuestionQuest && !onQuest.RiddleQuestCompleted)
        {
            FindObjectOfType<DialogueManager>().hasSpoken = true;
            FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
            FindObjectOfType<DialogueManager>().CompletedQuest = false;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        if (QuestionQuest == false)
        {


            if (Quest.Completed)
            {
                if (questName.Contains("Croissant") && secondQuestActive == false)
                {
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().FirstQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    
                }
                if(secondquestName.Contains("Apple") && secondQuestActive == true)
                {
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    InventoryManager.Instance.Add(questItems.Recipe);
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().SecondQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
                if(thirdquestName.Contains("Laughy") && thirdQuestActive == true)
                {
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().ThirdQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
                else
                {


                    DeleteItems();
                    CurrentQuesttext.text = "";
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
            }
            else
            {
                // during quest sentences. Generic ones
                Debug.Log(Quest.Completed);
                FindObjectOfType<DialogueManager>().hasSpoken = true;
                FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
                FindObjectOfType<DialogueManager>().CompletedQuest = false;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
