using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Canvas))]
[DisallowMultipleComponent]
public class UIController : MonoBehaviour
{
    [SerializeField]
    private UIElement InitialPage;
    [SerializeField]
    private GameObject FirstFocusItem;

    private Canvas RootCanvas;
    [SerializeField] InputActionReference toggleUI;

    private Stack<UIElement> elementStack = new Stack<UIElement>();
    private bool toggle = false;

    private void Awake()
    {
        RootCanvas = GetComponent<Canvas>();
        toggleUI.action.Enable();
    }

    private void Start()
    {
        if (FirstFocusItem != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstFocusItem);
        }

        if (InitialPage != null)
        {
            PushElement(InitialPage);
        }
    }

    private void Update()
    {
        if (false)
        {
            Debug.Log("pop");
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        Debug.Log("toggel");
        toggle = !toggle;
        if (toggle)
        {
            PushElement(InitialPage);
        }
        else
        {
            RemoveAllElements();
        }
    }

    private void OnCancel()
    {
        if (RootCanvas.enabled && RootCanvas.gameObject.activeInHierarchy)
        {
            if (elementStack.Count != 0)
            {
                RemoveElement();
            }
        }
    }

    public bool IsElementInStack(UIElement Page)
    {
        return elementStack.Contains(Page);
    }

    public bool IsElementOnTopOfStack(UIElement Page)
    {
        return elementStack.Count > 0 && Page == elementStack.Peek();
    }

    public void PushElement(UIElement Page)
    {
        Page.Enter(true);

        if (elementStack.Count > 0)
        {
            UIElement currentPage = elementStack.Peek();

            if (currentPage.exitOnNewPagePush)
            {
                currentPage.Exit(false);
            }
        }

        elementStack.Push(Page);
    }

    public void RemoveElement()
    {
        if (elementStack.Count > 1)
        {
            UIElement page = elementStack.Pop();
            page.Exit(true);

            UIElement newCurrentPage = elementStack.Peek();
            if (newCurrentPage.exitOnNewPagePush)
            {
                newCurrentPage.Enter(false);
            }
        }
    }

    public void RemoveAllElements()
    {
        for (int i = 1; i < elementStack.Count; i++)
        {
            RemoveElement();
        }
    }
}