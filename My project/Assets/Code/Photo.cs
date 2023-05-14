using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] private Image image;

    public void SetPhoto(Sprite photoSprite)
    {
        image.sprite = photoSprite;
        float scale = 0f;

        RectTransform rectTransform = GetComponent<RectTransform>();
        RectTransform parentRectTransform = GetComponentInParent<RectTransform>();
        scale = (parentRectTransform.sizeDelta.x / parentRectTransform.sizeDelta.y) / 34;

        this.transform.localScale = new Vector3(scale, scale, scale);
    }
}
