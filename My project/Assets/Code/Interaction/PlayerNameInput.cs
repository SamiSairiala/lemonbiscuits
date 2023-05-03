using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private string playerName;
    public Text playerInput;
    public Canvas playerInputCanvas;
    

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    public void Confirm()
    {
        dialogueManager.PlayerName = playerInput.text;
    }

    public void EndEdit()
    {
        dialogueManager.PlayerName = playerInput.text;
        playerInputCanvas.enabled = false;
    }

}
