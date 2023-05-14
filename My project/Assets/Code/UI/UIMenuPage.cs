using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LemonForest.UI;
using LemonForest;

public class UIMenuPage : MonoBehaviour, IPage
{
    private Transform page;
    private Coroutine animationCoroutine;
    private Direction currentSide = Direction.RIGHT;
    public Direction CurrentSide
    {
        get { return currentSide; }
    }
    [SerializeField]
    private CanvasGroup front, back;
    [SerializeField]
    public PageEnum PageEnum { get; }

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
        if(animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }


        if (currentSide == Direction.RIGHT) {
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
        
    }

    public void EnableContent(CanvasGroup group)
    {
        
    }
}
