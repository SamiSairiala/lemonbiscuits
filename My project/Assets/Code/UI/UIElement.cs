using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LemonForest.UI;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource), typeof(CanvasGroup))]
public class UIElement : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private AudioSource audioSource;
    [SerializeField]
    private float animationSpeed = 1f;

    public bool exitOnNewPagePush = false;
    [SerializeField]
    private AudioClip entryClip;
    [SerializeField]
    private AudioClip exitClip;
    [SerializeField]
    private UIAnimation entryMode = UIAnimation.SLIDE;
    [SerializeField]
    private Direction entryDirection = Direction.LEFT;
    [SerializeField]
    private UIAnimation exitMode = UIAnimation.SLIDE;
    [SerializeField]
    private Direction exitDirection = Direction.LEFT;

    private Coroutine animationCoroutine;
    private Coroutine audioCoroutine;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.spatialBlend = 0;

        audioSource.enabled = false;
    }

    public void Enter(bool PlayAudio)
    {

        switch (entryMode)
        {
            case UIAnimation.FADE:
                FadeIn(PlayAudio);
                break;
            case UIAnimation.SLIDE:
                SlideIn(PlayAudio);
                break;
            case UIAnimation.ZOOM:
                ZoomIn(PlayAudio);
                break;

            default:
                break;
        }
    }
    public void Exit(bool PlayAudio)
    {

        switch (entryMode)
        {
            case UIAnimation.FADE:
                FadeOut(PlayAudio);
                break;
            case UIAnimation.SLIDE:
                SlideOut(PlayAudio);
                break;
            case UIAnimation.ZOOM:
                ZoomOut(PlayAudio);
                break;

            default:
                break;
        }
    }

    private void SlideIn(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.SlideIn(rectTransform, entryDirection, animationSpeed));
    }

    private void SlideOut(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.SlideOut(rectTransform, entryDirection, animationSpeed));
    }

    private void FadeIn(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.FadeIn(canvasGroup, animationSpeed));
    }

    private void FadeOut(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.FadeOut(canvasGroup, animationSpeed));
    }

    private void ZoomIn(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.ZoomIn(rectTransform, animationSpeed));
    }

    private void ZoomOut(bool audio)
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(UIAnimationHelper.ZoomOut(rectTransform, animationSpeed));
    }

    private void PlayEntryClip(bool play)
    {
        if (play && entryClip != null && audioSource != null)
        {
            if(audioCoroutine != null)
            {
                StopCoroutine(audioCoroutine);
            }

            audioCoroutine = StartCoroutine(PlayClip(entryClip));
        }
    }

    private void PlayExitClip(bool play)
    {
        if (play && entryClip != null && audioSource != null)
        {
            if(audioCoroutine != null)
            {
                StopCoroutine(audioCoroutine);
            }

            audioCoroutine = StartCoroutine(PlayClip(exitClip));
        }
    }

    private IEnumerator PlayClip(AudioClip clip)
    {
        audioSource.enabled = true;

        WaitForSeconds Wait = new WaitForSeconds(clip.length);
        audioSource.PlayOneShot(clip);

        yield return null;

        audioSource.enabled = false;
    }
}
