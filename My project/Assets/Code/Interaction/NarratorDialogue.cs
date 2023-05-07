using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorDialogue : MonoBehaviour
{
    public GameObject popUpCanvas;
    public GameObject firstOne;
    public GameObject secondOne;
    void Start()
    {
        
    }




    public void FirstText()
	{
        popUpCanvas.SetActive(true);
        firstOne.SetActive(true);
        StartCoroutine(CloseCanvas());
	}

    public void SecondText()
    {
        popUpCanvas.SetActive(true);
        firstOne.SetActive(false);
        secondOne.SetActive(true);
        StartCoroutine(CloseCanvas());
    }


    IEnumerator CloseCanvas()
	{
        yield return new WaitForSecondsRealtime(10);
        popUpCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
