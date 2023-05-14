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
        float scale = 0.026f;

        this.transform.localScale = new Vector3(scale, scale, scale);
    }
}
