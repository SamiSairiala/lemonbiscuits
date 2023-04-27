using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightButton : MonoBehaviour
{
    public bool Right = false;
    public bool WrongAnswer = false;
    public bool bFinalRight = false;

    public void RightButtonPress()
    {
        Right = true;
    }

    public void WrongButton()
    {
        Right = false;
        Debug.Log("Wrong answer");
        WrongAnswer = true;
    }

    public void FinalRight()
    {
        bFinalRight = true;
    }
    
}
