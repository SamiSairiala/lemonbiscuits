using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraPicture : MonoBehaviour
{
    [SerializeField] Photo photoPrefab;
    private Transform parent;
    [SerializeField] Journal journal;
    [SerializeField] Canvas uiCanvas;
    [SerializeField] InputActionReference Interaction;
    private Coroutine pictureTakingCoroutine;

    private void OnEnable()
    {
        Interaction.action.Enable();

    }
    private void OnDisable()
    {
        Interaction.action.Disable();

    }

    private void Update()
    {
        if (Interaction.action.WasPerformedThisFrame())
        {
            OnScreenCaptureTrigger();
        }
    }

    public void OnScreenCaptureTrigger()
    {
        if(pictureTakingCoroutine != null)
        {
            StopCoroutine(pictureTakingCoroutine);
        }
        pictureTakingCoroutine = StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()
    {
        yield return null;

        if(uiCanvas != null)
        {
            uiCanvas.enabled = false;
        }

        yield return new WaitForEndOfFrame();

        Texture2D capture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect picSize = new Rect(0,0, Screen.width, Screen.height);
        capture.ReadPixels(picSize, 0, 0, false);
        uiCanvas.enabled = true;
        capture.Apply();
        Photo p = Instantiate(photoPrefab, new Vector3(0,0,0), Quaternion.identity);

        if(journal.GetPicturePage().GetPictureCount() < 8)
        {
            parent = journal.GetPicturePage().GetPictureParent();

            p.transform.SetParent(parent);
            p.transform.SetLocalPositionAndRotation(journal.GetPicturePage().GetPictureLocation(), new Quaternion(0, 0, 0, 0));
        } else
        {
            journal.AddPage();
            parent = journal.GetPicturePage().GetPictureParent();
            p.transform.SetParent(parent);
            p.transform.SetLocalPositionAndRotation(journal.GetPicturePage().GetPictureLocation(), new Quaternion(0, 0, 0, 0));
        }

        journal.GetPicturePage().AddPictureCount();
        AddPhoto(p, capture);

    }

    void AddPhoto(Photo p, Texture2D screenCap)
    {
        Sprite photoSprite = Sprite.Create(screenCap, new Rect(0f, 0f, screenCap.width, screenCap.height), new Vector2(0.5f, 0.5f), 100f);
        p.SetPhoto(photoSprite);
    }
}
