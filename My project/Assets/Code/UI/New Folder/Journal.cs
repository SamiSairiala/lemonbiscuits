using LemonForest;
using LemonForest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField]
    private List<UIMenuPage> pages;

    private RectTransform rTransfrorm;

    [SerializeField]
    GameObject nextButton, previousButton;

    private int currentPage = 0;
    private int targetPage = 0;
    public int TargetPage
    {
        set { targetPage = value; }
        get { return (Mathf.Clamp(targetPage, 0, pages.Count-1)); }
    }

    public void Awake()
    {
        rTransfrorm = GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (currentPage < TargetPage)
        {
            pages[currentPage].Next();
            currentPage++;
        }
        if(currentPage > TargetPage)
        {
            currentPage--;
            pages[currentPage].Previous();
        }
        if(targetPage > TargetPage)
        {
            pages[TargetPage].Next();
        }
        if(targetPage < 1)
        {
            previousButton.SetActive(false);
        } else
        {
            previousButton.SetActive(true);
        }
        if(targetPage >= pages.Count)
        {
            nextButton.SetActive(false);
        } else
        {
            nextButton.SetActive(true);
        }
    }

    public void Open()
    {
        UIAnimationHelper.SlideIn(rTransfrorm, Direction.UP, 1);
    }

    public void Close()
    {
        UIAnimationHelper.SlideOut(rTransfrorm, Direction.DOWN, 1);
    }

    public void NextPage()
    {
        targetPage++;
        Debug.Log(TargetPage);
    }

    public void PreviousPage()
    {
        targetPage--;
        Debug.Log(TargetPage);
    }

    public void GoTo(int i)
    {
        targetPage = i;
        Debug.Log(TargetPage);
    }
}
