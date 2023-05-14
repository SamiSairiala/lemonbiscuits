using LemonForest;
using LemonForest.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Journal : MonoBehaviour
{
    [SerializeField]
    private List<UIMenuPage> pages;
    [SerializeField]
    private UIMenuPage pagePrefab;

    private RectTransform rTransfrorm;

    [SerializeField]
    GameObject nextButton, previousButton;

    [ReadOnlyAttrib][SerializeField] private int currentPage = 1;
    [ReadOnlyAttrib][SerializeField] private int targetPage = 0;
    public int TargetPage
    {
        set { targetPage = value; }
        get { return (Mathf.Clamp(targetPage, -1, pages.Count - 1)); }
    }

    public void Awake()
    {
        rTransfrorm = GetComponent<RectTransform>();
        DisableExtraStuffs();
    }

    public void Update()
    {
        if (currentPage < TargetPage)
        {
            pages[currentPage].Next();
            currentPage++;
            if (currentPage < pages.Count - 1)
            {
                pages[currentPage + 1].EnableSide(Direction.LEFT);
                pages[currentPage + 1].transform.SetAsLastSibling();
            }
            pages[currentPage].transform.SetAsLastSibling();
        }
        if (currentPage > TargetPage)
        {
            pages[currentPage].Previous();
            currentPage--;

            if (currentPage > 0)
            {
                pages[currentPage - 1].EnableSide(Direction.RIGHT);
                pages[currentPage - 1].transform.SetAsLastSibling();
            }
            pages[currentPage].transform.SetAsLastSibling();
        }
        if (targetPage > TargetPage)
        {
            pages[TargetPage].Next();
        }
        if (targetPage < 1)
        {
            previousButton.SetActive(false);
        }
        else
        {
            previousButton.SetActive(true);
        }
        if (targetPage >= pages.Count)
        {
            nextButton.SetActive(false);
        }
        else
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
        if (currentPage < pages.Count - 1)
        {
            targetPage++;
        }
        else if (pages[currentPage].GetPictureCount()>=4)
        {
            pages[currentPage].Next();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            targetPage--;
        } else 
        {
            pages[currentPage].Previous();
        }
    }

    public void GoTo(int i)
    {
        targetPage = i;
        Debug.Log(TargetPage);
    }

    public void AddPage()
    {
        Debug.Log("adding page");
        UIMenuPage p = Instantiate(pagePrefab, transform);
        pages.Add(p);
        p.Initialize();
        p.DisableBackground();
        p.EnableSide(Direction.RIGHT);
        DisableExtraStuffs();
    }

    public UIMenuPage GetPicturePage()
    {
        return pages[pages.Count - 1];
    }

    public int GetIndex(UIMenuPage page)
    {
        return pages.IndexOf(page);
    }

    private void DisableExtraStuffs()
    {
        foreach (UIMenuPage page in pages)
        {
            if (!page.CoroutineRunning)
            {
                page.transform.SetAsFirstSibling();
                page.DisableBackground();

                if (page.PageNumber == currentPage + 1)
                {
                    page.ShowSideInstant(Direction.RIGHT);
                    page.transform.SetAsLastSibling();
                }

                if (page.PageNumber == currentPage)
                {
                    page.ShowSideInstant(Direction.LEFT);
                    page.transform.SetAsLastSibling();
                }

                if (page.PageNumber < currentPage)
                {
                    page.SetSide(Direction.LEFT);
                }
                if (page.PageNumber > currentPage + 1)
                {
                    page.SetSide(Direction.RIGHT);
                }
            }
        }
    }
}
