using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ArborDialogue : MonoBehaviour
{

    
    public TextMeshProUGUI dialogueText;
    public Canvas PlayerDialogueCanvas;
    public TextMeshProUGUI nameText;

    public bool FirstTimeMeeting = true;
    public bool LastTimeTalking = false;
    

    private Queue<string> Sentences;

    public bool lastQuestDone = false;

    public Dialogue dialogue;

    public OnQuest onquest;
    
    private void Start()
    {
        Sentences = new Queue<string>();
        
    }

    public void ShowDialogue()
	{
        StartDialogueBox(dialogue);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Player"))
		{
            StartDialogueBox(dialogue);
		}
	}

	//TODO: Change to switch dialogues after pressing next or turning all of the quest items
	public void StartDialogueBox(Dialogue dialogue)
    {
        // TODO: open DIALOGUE BOX
        PlayerDialogueCanvas.gameObject.SetActive(true);
        Debug.Log("Starting dialogue");
        //nameText.text = dialogue.name;

        Sentences.Clear();
        
        // Spoken lines during quest.
        nameText.text = dialogue.name;


        // First time meeting player.
        if (FirstTimeMeeting && lastQuestDone == false)
		{
            foreach (string sentence in dialogue.sentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
            FirstTimeMeeting = false;
        }
		if(lastQuestDone == true && FirstTimeMeeting == false)
		{
            foreach (string sentence in dialogue.FirstQuestDone)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
            LastTimeTalking = true;
        }    
        
        
        
    }

    public void DisplayNextSentence()
    {
        Debug.Log(Sentences.Count);
        if(Sentences.Count == 0)
        {
            // No more sentences.
            EndDialogue();
            return;
        }
        string sentence = Sentences.Dequeue();
        
        
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence) // "Animates" Dialogue.
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
            
        }
        StartCoroutine(SwitchSentence());
    }

    IEnumerator SwitchSentence()
	{
        yield return new WaitForSecondsRealtime(1.5f);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        // TODO: CLOSE DIALOGUE BOX
        this.gameObject.SetActive(false);
        PlayerDialogueCanvas.gameObject.SetActive(false);
        
        if(LastTimeTalking == true)
		{
            Debug.Log("End");
            // GIVE 2 CHOICES
            SceneManager.LoadScene("Credits");
		}
        else
        {
            onquest.Twig.GetComponent<CapsuleCollider>().isTrigger = true;
            onquest.TwigQuestIndicator.SetActive(true);
        }
        
    }

    
}
