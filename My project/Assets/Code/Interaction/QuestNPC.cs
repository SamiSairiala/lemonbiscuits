using Quests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.AI;
using LemonForest.AI;
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

    public Animator animator;

    public NPCBase npcBase;
    public NavMeshAgent agent;

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
            animator.SetBool("React", true);
            npcBase.PauseRoutine();

            //if(this.gameObject.name.Contains("Laughy") && onQuest.LaughyQuest == true)
            //if(this.gameObject.name.Contains("Twig") && onQuest.TwigQuest == true)
            //if(this.gameObject.name.Contains("Rockie") && onQuest.RockieQuest == true)
            FindObjectOfType<DialogueManager>().npcName = dialogue.name;


            if (!AssignedQuest && !Helped && !onQuest.onQuest && secondQuestActive == false)
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
				if (InventoryManager.Instance.Items.Contains(questItems.ApplePie))
				{
                    InventoryManager.Instance.Remove(questItems.ApplePie);
				}
                if (onQuest.SecondTalkQuest == true)
                {
                    onQuest.SecondTalkQuest = false;
                }


            }
           
            else
            {
                if (hasSecondQuest && secondQuestActive == false && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == false)
                {
                    Debug.Log("Assigning 2 quest");
                    AssignSecondQuest();
                    onQuest.onQuest = true;
                }
                if (hasThirdQuest && secondQuestActive == true && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == false)
                {
                    Debug.Log("Assigning 3 quest");
                    AssingThirdQuest();
                    onQuest.onQuest = true;
                }
                if (hasFourthQuest && secondQuestActive == true && thirdQuestActive == true && FourthQuestActive == false && AssignedQuest == false)
                {
                    Debug.Log("Assigning 4 quest");
                    AssingFourthQuest();
                    onQuest.onQuest = true;
                }
    //            if (hasSecondQuest && secondQuestActive == false && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == true)
				//{
    //                FindObjectOfType<DialogueManager>().SecondQuest = true;
    //                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    //            }
    //            if (hasThirdQuest && secondQuestActive == true && thirdQuestActive == false && FourthQuestActive == false && AssignedQuest == true)
    //            {
    //                FindObjectOfType<DialogueManager>().ThirdQuest = true;
    //                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    //            }
    //            if (hasFourthQuest && secondQuestActive == true && thirdQuestActive == true && FourthQuestActive == false && AssignedQuest == true)
    //            {
    //                FindObjectOfType<DialogueManager>().fourthQuest = true;
    //                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    //            }
            }




        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    FindObjectOfType<DialogueManager>().EndDialogue(); // Closes dialogue box if player walks away.
        //}
        animator.SetBool("React", false);
        npcBase.ContinueRoutine();
        

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
		if (fourthquestName.Contains("FishPie"))
		{
            InventoryManager.Instance.Add(questItems.Recipe);
        }
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
        if (thirdquestName.Contains("CatherFish"))
        {
            onQuest.LaughyQuestIndicator.SetActive(false);
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
        else
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
            for (int i = 0; i < 2; i++)
            {
                InventoryManager.Instance.Add(questItems.Coin);
            }
            AssignedQuest = true;
            Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
            Debug.Log("Assigned quest");
            StartCoroutine(UpdateQuestText());
        }
        if (questName.Contains("CatherFish"))
        {
            onQuest.TwigQuestIndicator.SetActive(false);
            AssignedQuest = true;
            Quest = (NewQuest)quests.AddComponent(System.Type.GetType(questName));
            Debug.Log("Assigned quest");
            StartCoroutine(UpdateQuestText());
            InventoryManager.Instance.Add(questItems.FishingRod);
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
        animator.SetBool("React", false);
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
            if (InventoryManager.Instance.Items.Contains(questItems.Recipe))
			{
                InventoryManager.Instance.Remove(questItems.Recipe);
			}

        }
        if (questName.Contains("CatherFish") && secondQuestActive == false && thirdQuestActive == false)
        {
            Debug.Log("Quest has fish");
            item = quests.GetComponent<QuestItems>().Fish;
        }
        if (secondquestName.Contains("Flower") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has flowers");
            item = quests.GetComponent<QuestItems>().Flower;
        }
        if (secondquestName.Contains("GatherFishFish") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has fish");
            item = quests.GetComponent<QuestItems>().Fish;
        }
        if (secondquestName.Contains("Apple") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has apples");
            item = quests.GetComponent<QuestItems>().Apple;
        }
        if (secondquestName.Contains("Salmon") && secondQuestActive == true && thirdQuestActive == false)
        {
            Debug.Log("Quest has apples");
            item = quests.GetComponent<QuestItems>().salmon;
        }
        if (fourthquestName.Contains("Healing") && FourthQuestActive == true)
		{
            item = quests.GetComponent<QuestItems>().RareFlower;
            questItems.Arbor.SetActive(true);
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
        //if (onQuest.RiddleQuestCompleted)
        //{
        //    onQuest.onQuest = false;
        //    Helped = true;
        //    AssignedQuest = false;
        //    QuestionQuest = false;
        //    FindObjectOfType<DialogueManager>().hasGottenQuestItems = true;
        //    FindObjectOfType<DialogueManager>().CompletedQuest = false;
        //    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //}
        //else if (QuestionQuest && !onQuest.RiddleQuestCompleted)
        //{
        //    FindObjectOfType<DialogueManager>().hasSpoken = true;
        //    FindObjectOfType<DialogueManager>().hasGottenQuestItems = false;
        //    FindObjectOfType<DialogueManager>().CompletedQuest = false;
        //    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //}
        if (QuestionQuest == false)
        {


            if (Quest.Completed)
            {
                animator.SetBool("React", true);
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
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FirstQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Laughy.GetComponent<CapsuleCollider>().isTrigger = true;
                    onQuest.LaughyQuestIndicator.SetActive(true);

                }
				if (questName.Contains("CatherFish") && secondQuestActive == false)
				{
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    onQuest.TalkQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FirstQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = true;
                    onQuest.RockieQuestIndicator.SetActive(true);
                }
                if (thirdquestName.Contains("CatherFish") && thirdQuestActive == true && FourthQuestActive == false)
                {
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    onQuest.TalkQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().ThirdQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Laughy.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = true;
                    onQuest.RockieQuestIndicator.SetActive(true);
                }
                if (secondquestName.Contains("Apple") && secondQuestActive == true && thirdQuestActive == false)
                {
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    InventoryManager.Instance.Add(questItems.Recipe);
                    Debug.Log("Quest 2 completed");
                    Helped = true;
                    AssignedQuest = false;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().SecondQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.RockieQuestIndicator.SetActive(true);
                }
                if(thirdquestName.Contains("JuicyApple") && thirdQuestActive == true && FourthQuestActive == false)
				{
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    InventoryManager.Instance.Add(questItems.Recipe);
                    Debug.Log("Quest 2 completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().ThirdQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.TwigQuestIndicator.SetActive(true);
                }
                if(secondquestName.Contains("Salmon") && secondQuestActive == true && thirdQuestActive == false)
				{
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest 2 completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().SecondQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.LaughyQuestIndicator.SetActive(true);
                }
                if(thirdquestName.Contains("Laughy") && thirdQuestActive == true && FourthQuestActive == false)
                {
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    onQuest.TalkQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest  3 completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().ThirdQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Laughy.GetComponent<CapsuleCollider>().isTrigger = false;
                }
                if(secondquestName.Contains("BringPie") && secondQuestActive == true && thirdQuestActive == false)
				{
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest 2 completed");
                    onQuest.TalkQuest = false;
                    Helped = true;
                    AssignedQuest = false;
                    InventoryManager.Instance.Remove(questItems.Fishpie);
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().SecondQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Laughy.GetComponent<CapsuleCollider>().isTrigger = true;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.LaughyQuestIndicator.SetActive(true);
                }
                if(fourthquestName.Contains("FishPie") && FourthQuestActive == true)
				{
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest 4 completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FourthQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = true;
                }
                //THESE TWO ARE PLACEHOLDERS
				if (questName.Contains("MissingFlowers") && secondQuestActive == false)
				{
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FirstQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.LaughyQuestIndicator.SetActive(true);
                }
                
				if (fourthquestName.Contains("LostAmulet") && FourthQuestActive == true)
				{
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest 4 completed");
                    Helped = true;
                    InventoryManager.Instance.Remove(questItems.Amulet);
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FourthQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.Rockie.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.Twig.GetComponent<CapsuleCollider>().isTrigger = true;
                    onQuest.Laughy.GetComponent<CapsuleCollider>().isTrigger = false;
                    onQuest.TwigQuestIndicator.SetActive(true);
                }
                if(thirdquestName.Contains("Infestation") && thirdQuestActive == true && FourthQuestActive == false)
				{
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest 3 completed");
                    Helped = true;
                    InventoryManager.Instance.Remove(questItems.RareFlower);
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().ThirdQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    onQuest.TwigQuestIndicator.SetActive(true);
                }
                if(fourthquestName.Contains("Healing") && FourthQuestActive == true)
				{
                    DeleteItems();
                    CurrentQuesttext.text = "";
                    onQuest.onQuest = false;
                    Quest.GiveReward();
                    Debug.Log("Quest4 completed");
                    Helped = true;
                    AssignedQuest = false;
                    currentAmount = 0;
                    FindObjectOfType<QuestItems>().Arbor.SetActive(true);
                    FindObjectOfType<QuestItems>().Collider.enabled = true;
                    FindObjectOfType<ArborDialogue>().lastQuestDone = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().FourthQuestCompleted = true;
                    FindObjectOfType<DialogueManager>().CompletedQuest = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    // ADD ARBOR QUESTMARKER HERE ASWELL
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
        float velocity = agent.velocity.magnitude / agent.speed;
        
        animator.SetFloat("Walk", velocity);
        
    }
}
