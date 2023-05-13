using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StartDialogue : MonoBehaviour
{

    
    public TextMeshProUGUI dialogueText;
    public Canvas PlayerDialogueCanvas;

    
    

    

    private Queue<string> Sentences;



    public Dialogue dialogue;
    
    private void Start()
    {
        Sentences = new Queue<string>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        StartDialogueBox(dialogue);
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
        


        // First time meeting player.
        
            foreach (string sentence in dialogue.sentences)
            {
                Sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        
        
        
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
        yield return new WaitForSecondsRealtime(4);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        // TODO: CLOSE DIALOGUE BOX
        
        FindObjectOfType<ArborDialogue>().ShowDialogue();
        PlayerDialogueCanvas.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;


    }

    
}
