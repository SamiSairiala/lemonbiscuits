using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Canvas PlayerDialogueCanvas;

    
    public bool hasSpoken = false;
    public bool hasGottenQuestItems = false;
    public bool hasDiffrentQuest = false;
    public bool CompletedQuest = false;
    public bool SecondQuest = false;
    public bool ThirdQuest = false;
    public bool fourthQuest = false;
    public bool TalkQuest = false;
    public bool SecondTalkQuest = false;
    public bool QuestionsQuest = false;
    public bool failedQuestionQuest = false;
    public bool FirstQuestCompleted = false;
    public bool SecondQuestCompleted = false;
    public bool ThirdQuestCompleted = false;
    public bool FourthQuestCompleted = false;

    public bool WrongAnswer = false;

    private Queue<string> Sentences;

    public string PlayerName;

    // gets npc name from QuestNPC script.
    public string npcName;
    public bool playerTalking = false;
    private void Start()
    {
        Sentences = new Queue<string>();
    }



    //TODO: Change to switch dialogues after pressing next or turning all of the quest items
    public void StartDialogue(Dialogue dialogue)
    {
        // TODO: open DIALOGUE BOX
        PlayerDialogueCanvas.gameObject.SetActive(true);
        Debug.Log("Starting dialogue");
        //nameText.text = dialogue.name;

        Sentences.Clear();

        // Spoken lines during quest.
        if(hasSpoken == true && hasGottenQuestItems == false && CompletedQuest == false)
        {
            foreach (string sentence in dialogue.sentencesDuringQuests)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        // Has diffrent quest.
        if(hasDiffrentQuest == true && TalkQuest == false)
        {
            foreach (string sentence in dialogue.hasDiffrentQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();

        }
        if (FirstQuestCompleted == true)
        {
            foreach (string sentence in dialogue.FirstQuestDone)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(SecondQuestCompleted == true)
        {
            foreach (string sentence in dialogue.SecondQuestDone)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(ThirdQuestCompleted == true)
        {
            foreach (string sentence in dialogue.ThirdQuestDone)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(SecondQuest == true)
        {
            foreach (string sentence in dialogue.secondQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();

        }
        if(ThirdQuest == true)
        {
            foreach (string sentence in dialogue.thirdQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(fourthQuest == true)
        {
            foreach (string sentence in dialogue.FourthQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(TalkQuest == true && hasDiffrentQuest == true)
        {
            foreach (string sentence in dialogue.TalkQuest)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        if(SecondTalkQuest == true && hasDiffrentQuest == true)
        {
            foreach (string sentence in dialogue.SecondTalkQuest)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        // After player returns quest items.
        if (hasGottenQuestItems == true && CompletedQuest == false)
        {
            foreach (string sentence in dialogue.AfterQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        //if (CompletedQuest == true)
        //{
        //    foreach (string sentence in dialogue.AfterQuestSentences)
        //    {
        //        Sentences.Enqueue(sentence);
        //    }
        //    DisplayNextSentence();
        //}
        // Completed quest.
        if (CompletedQuest == true && hasGottenQuestItems == true)
        {
            foreach (string sentence in dialogue.CompletedQuest)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        if (WrongAnswer)
        {
            foreach (string sentence in dialogue.FailedQuestions)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }


        // First time meeting player.
        if (hasSpoken == false && hasGottenQuestItems == false && CompletedQuest == false && hasDiffrentQuest == false && TalkQuest == false)
        {
            foreach (string sentence in dialogue.sentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }
        
        
    }

    public void DisplayNextSentence()
    {
        
        if(Sentences.Count == 0)
        {
            // No more sentences.
            EndDialogue();
            return;
        }
        string sentence = Sentences.Dequeue();
        if (sentence.Contains("-"))
        {
            // PLAYER NAME
            nameText.text = PlayerName;
            Debug.Log("Player talking");
        }   
        else
        {
            // NPC NAME
            Debug.Log("Player not talking");
            nameText.text = npcName;
        }
        // Used only for one quest. Hacky way of doing this but time is running out.
        if (sentence.Contains("1:"))
        {
            FindObjectOfType<OnQuest>().riddle.First();
            FindObjectOfType<OnQuest>().riddle.FirstButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            FindObjectOfType<OnQuest>().riddle.SecondButton.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
            FindObjectOfType<OnQuest>().riddle.ThirdButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            Debug.Log("First riddle");
        }
        if (sentence.Contains("2:"))
        {
            FindObjectOfType<OnQuest>().riddle.Second();
            FindObjectOfType<OnQuest>().riddle.FirstButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            FindObjectOfType<OnQuest>().riddle.SecondButton.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
            FindObjectOfType<OnQuest>().riddle.ThirdButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            Debug.Log("Second riddle");
        }
        if (sentence.Contains("3:"))
        {
            FindObjectOfType<OnQuest>().riddle.Third();
            FindObjectOfType<OnQuest>().riddle.FirstButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            FindObjectOfType<OnQuest>().riddle.SecondButton.GetComponentInChildren<TextMeshProUGUI>().text = "No";
            FindObjectOfType<OnQuest>().riddle.ThirdButton.GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
            Debug.Log("Third riddle");
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence) // "Animates" Dialogue.
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        // TODO: CLOSE DIALOGUE BOX
        PlayerDialogueCanvas.gameObject.SetActive(false);
        hasSpoken = false;
        hasGottenQuestItems = false;
        hasDiffrentQuest = false;
        CompletedQuest = false;
        SecondQuest = false;
        TalkQuest = false;
        SecondTalkQuest = false;
        FirstQuestCompleted = false;
        SecondQuestCompleted = false;
        ThirdQuestCompleted = false;
        
    }

    public void AcceptQuest()
	{
        EndDialogue();
	}
}
