using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Riddle : MonoBehaviour
{
    public OnQuest onquest;

    public Button FirstButton;
    public Button SecondButton;
    public Button ThirdButton;



    public RightButton rightButtonScript;
    private void Start()
    {
        onquest = FindObjectOfType<OnQuest>();
        onquest.RiddleQuest = true;

    }

    public void First()
    {
        FirstButton.onClick.RemoveAllListeners();
        SecondButton.onClick.RemoveAllListeners();
        ThirdButton.onClick.RemoveAllListeners();
        SecondButton.onClick.AddListener(ClickedRight);
        FirstButton.onClick.AddListener(ClickedWrong);
        ThirdButton.onClick.AddListener(ClickedWrong);
    }

    public void Second()
    {
        FirstButton.onClick.RemoveAllListeners();
        SecondButton.onClick.RemoveAllListeners();
        ThirdButton.onClick.RemoveAllListeners();
        SecondButton.onClick.AddListener(ClickedRight);
        FirstButton.onClick.AddListener(ClickedWrong);
        ThirdButton.onClick.AddListener(ClickedWrong);
    }

    public void Third()
    {
        FirstButton.onClick.RemoveAllListeners();
        SecondButton.onClick.RemoveAllListeners();
        ThirdButton.onClick.RemoveAllListeners();
        SecondButton.onClick.AddListener(ClickedWrong);
        FirstButton.onClick.AddListener(ClickedWrong);
        ThirdButton.onClick.AddListener(FinalRight);
    }

    public void ClickedWrong()
    {
        rightButtonScript.WrongButton();
    }

    public void ClickedRight()
    {
        rightButtonScript.RightButtonPress();
		FindObjectOfType<DialogueManager>().DisplayNextSentence();
	}

    void FinalRight()
    {
        rightButtonScript.FinalRight();
    }


    private void Update()
    {
        if (rightButtonScript.bFinalRight)
        {
            onquest.RiddleQuestCompleted = true;
        }
        if(rightButtonScript.Right)
        {
            rightButtonScript.Right = false;
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
        if (rightButtonScript.WrongAnswer)
        {
			FindObjectOfType<DialogueManager>().WrongAnswer = true;
			FindObjectOfType<DialogueManager>().EndDialogue();
			FindObjectOfType<DialogueManager>().WrongAnswer = false;
			rightButtonScript.WrongAnswer = false;
		}



    }




}

