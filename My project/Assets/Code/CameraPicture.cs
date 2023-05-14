using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPicture : MonoBehaviour
{
    [SerializeField] Photo photoPrefab;
    [SerializeField] Transform parent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TakePhoto());
        }
    }

    IEnumerator TakePhoto()
    {
        yield return new WaitForEndOfFrame();
        Texture2D capture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect picSize = new Rect(0,0, Screen.width, Screen.height);
        capture.ReadPixels(picSize, 0, 0, false);
        capture.Apply();
        Photo p = Instantiate(photoPrefab, new Vector3(0,0,0), Quaternion.identity);
        p.transform.SetParent(parent, false);
        p.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        p.transform.localScale = new Vector3(1, 1, 1);
        ShowPhoto(p, capture);
    }

    void ShowPhoto(Photo p, Texture2D screenCap)
    {
        Sprite photoSprite = Sprite.Create(screenCap, new Rect(0f, 0f, screenCap.width, screenCap.height), new Vector2(0.5f, 0.5f), 100f);
        p.SetPhoto(photoSprite);
    }
}
