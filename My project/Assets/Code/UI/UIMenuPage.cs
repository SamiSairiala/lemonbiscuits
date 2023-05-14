using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LemonForest.UI;
using LemonForest;
using System;
using UnityEngine.UI;

public class UIMenuPage : MonoBehaviour
{
    private Transform page;
    private Image image;
    private Coroutine animationCoroutine;
    private Journal journal;
    [ReadOnlyAttrib] [SerializeField] private int pageNo = -1;
    private Direction currentSide = Direction.RIGHT;
    public Direction CurrentSide
    {
        get { return currentSide; }
    }
    public int PageNumber
    {
        get { return pageNo; }
    }
    [SerializeField]
    private CanvasGroup front, back;
    [SerializeField]
    public PageEnum PageEnum { get; }

    public bool CoroutineRunning
    {
        get { return (animationCoroutine != null); }
    }

    private Vector3[] pictureLocations = new Vector3[]
    {
        new Vector3(1.5f, 4,0),
        new Vector3(-4,4,0),
        new Vector3(1.5f, -3,0),
        new Vector3(-4,-3,0)
    };

    [SerializeField]
    private int pictureCount = 0;

    public CanvasGroup Front
    {
        get { return front; }
    }
    public CanvasGroup Back
    {
        get { return back; }
    }

    [SerializeField]
    private float turnSpeed = 0.2f;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        journal = FindObjectOfType<Journal>();
        pageNo = journal.GetIndex(this);
        image = GetComponent<Image>();
        page = GetComponent<Transform>();
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    public void Top()
    {
        page.SetAsLastSibling();
    }

    public void FlipPage()
    {
        Debug.Log("flip");
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }


        if (currentSide == Direction.RIGHT)
        {
            currentSide = Direction.LEFT;
        }
        else
        {
            currentSide = Direction.RIGHT;
        }

        animationCoroutine = StartCoroutine(UIAnimationHelper.Flip(transform, currentSide, this, turnSpeed));
    }

    public void DisableContent()
    {
        StartCoroutine(UIAnimationHelper.HidePage(this, turnSpeed));
    }

    public void EnableSide(Direction dir)
    {
        StartCoroutine(UIAnimationHelper.ShowSide(this, dir, turnSpeed));
    }

    public void DisableSide(Direction dir)
    {
        StartCoroutine(UIAnimationHelper.HideSide(this, dir, turnSpeed));
    }

    public void Next()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.Flip(transform, Direction.LEFT, this, turnSpeed));
        currentSide = Direction.LEFT;
    }

    public void Previous()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.Flip(transform, Direction.RIGHT, this, turnSpeed));
        currentSide = Direction.RIGHT;
    }

    public void SetLayer(int i)
    {
        GetComponentInChildren<SpriteRenderer>().sortingOrder = i;
    }

    public void DisableContent(CanvasGroup group)
    {
        image.enabled = false;
    }

    public void EnableContent(CanvasGroup group)
    {
        image.enabled = true;
    }

    public int GetPictureCount()
    {
        return pictureCount;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public Transform GetPictureParent()
    {
        if (GetPictureCount() < 4)
        {
            return front.transform;
        }
        else
        {
            return back.transform;
        }
    }

    public void SetSide(Direction dir)
    {
        switch (dir)
        {
            case Direction.LEFT:
                transform.localEulerAngles = new Vector3(0, 180, 0);
                front.alpha = 0;
                front.blocksRaycasts = false;
                front.interactable = false;
                back.alpha = 1;
                back.blocksRaycasts = true;
                back.interactable = true;
                back.transform.SetAsLastSibling();
                break;
            case Direction.RIGHT:
                transform.localEulerAngles = new Vector3(0, 0, 0);
                front.alpha = 1;
                front.blocksRaycasts = true;
                front.interactable = true;
                front.transform.SetAsLastSibling();
                back.alpha = 0;
                back.interactable = false;
                back.blocksRaycasts = false;
                break;
            default:
                break;
        }
    }

    public void DisableBackground()
    {
        Front.alpha = 0f;
        Front.blocksRaycasts = false;
        Front.interactable = false;
        Back.alpha = 0f;
        Back.blocksRaycasts = false;
        Back.interactable = false;
    }

    public void ShowSideInstant(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                Back.alpha = 1f;
                Back.blocksRaycasts = true;
                Back.interactable = true;
                break;
            case Direction.RIGHT:
                Front.alpha = 1f;
                Front.blocksRaycasts = true;
                Front.interactable = true;
                break;
            default:
                break;
        }
    }

    public void HideSideInstant(Direction direction)
    {
        switch (direction)
        {
            case Direction.LEFT:
                Back.alpha = 0f;
                Back.blocksRaycasts = false;
                Back.interactable = false;
                break;
            case Direction.RIGHT:
                Front.alpha = 0f;
                Front.blocksRaycasts = false;
                Front.interactable = false;
                break;
            default:
                break;

        }
    }

    public void EnableBackground()
    {

        Front.alpha = 1f;
        Front.blocksRaycasts = true;
        Front.interactable = true;
        Back.alpha = 1f;
        Back.blocksRaycasts = true;
        Back.interactable = true;
    }

    public Vector3 GetPictureLocation()
    {
        int i = 1;
        if (GetPictureCount() >= 4) i = -1;
        Vector3 loc = pictureLocations[GetPictureCount() % 4];
        loc.x = loc.x * i;
        return loc;
    }

    internal void AddPictureCount()
    {
        pictureCount++;
    }
}
