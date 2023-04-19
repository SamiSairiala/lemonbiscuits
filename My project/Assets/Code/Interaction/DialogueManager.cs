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
    public bool TalkQuest = false;

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
        if(SecondQuest == true)
        {
            foreach (string sentence in dialogue.secondQuestSentences)
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
        
    }

    public void AcceptQuest()
	{
        EndDialogue();
	}
}
