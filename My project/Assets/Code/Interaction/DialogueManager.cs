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

    private Queue<string> Sentences;


    private void Start()
    {
        Sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        // TODO: open DIALOGUE BOX
        PlayerDialogueCanvas.gameObject.SetActive(true);
        Debug.Log("Starting dialogue");
        nameText.text = dialogue.name;

        Sentences.Clear();

        // Spoken lines during quest.
        if(hasSpoken == true)
        {
            foreach (string sentence in dialogue.sentencesDuringQuests)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        // After player returns quest items.
        if (hasGottenQuestItems == true)
        {
            foreach (string sentence in dialogue.AfterQuestSentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        // First time meeting player.
        if (hasSpoken == false && hasGottenQuestItems == false)
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
            EndDialogue();
            return;
        }
        string sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        // TODO: CLOSE DIALOGUE BOX
        PlayerDialogueCanvas.gameObject.SetActive(false);
        hasSpoken = false;
        hasGottenQuestItems = false;
    }

    public void AcceptQuest()
	{
        EndDialogue();
	}
}
