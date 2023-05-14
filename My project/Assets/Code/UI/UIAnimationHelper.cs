using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace LemonForest.UI
{
    public class UIAnimationHelper
    {
        public static IEnumerator ZoomIn(RectTransform rect, float speed)
        {
            float time = 0;
            while (time < 1)
            {
                rect.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, time);
                yield return null;
                time += Time.deltaTime * speed;
            }

            rect.localScale = Vector3.one;
        }

        public static IEnumerator ZoomOut(RectTransform rect, float speed)
        {
            float time = 0;
            while (time < 1)
            {
                rect.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, time);
                yield return null;
                time += Time.deltaTime * speed;
            }

            rect.localScale = Vector3.zero;
        }

        public static IEnumerator FadeIn(CanvasGroup rect, float speed)
        {
            rect.blocksRaycasts = true;
            rect.interactable = true;

            float time = 0;
            while (time < 1)
            {
                rect.alpha = Mathf.Lerp(0, 1, time);
                yield return null;
                time += Time.deltaTime * speed;
            }

            rect.alpha = 1;

        }

        public static IEnumerator FadeOut(CanvasGroup rect, float speed)
        {
            rect.blocksRaycasts = false;
            rect.interactable = false;

            float time = 0;
            while (time < 1)
            {
                rect.alpha = Mathf.Lerp(1, 0, time);
                yield return null;
                time += Time.deltaTime * speed;
            }

            rect.alpha = 0;

        }

        public static IEnumerator SlideIn(RectTransform Transform, Direction Direction, float Speed)
        {
            Vector2 startPosition;
            switch (Direction)
            {
                case Direction.UP:
                    startPosition = new Vector2(0, -Screen.height);
                    break;
                case Direction.RIGHT:
                    startPosition = new Vector2(-Screen.width, 0);
                    break;
                case Direction.DOWN:
                    startPosition = new Vector2(0, Screen.height);
                    break;
                case Direction.LEFT:
                    startPosition = new Vector2(Screen.width, 0);
                    break;
                default:
                    startPosition = new Vector2(0, -Screen.height);
                    break;
            }

            float time = 0;
            while (time < 1)
            {
                Transform.anchoredPosition = Vector2.Lerp(startPosition, Vector2.zero, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            Transform.anchoredPosition = Vector2.zero;
        }

        public static IEnumerator HidePage(UIMenuPage page, float speed)
        {
            float time = 0f;
            bool triggered = false;
            while (time < 1f)
            {
                if(time > 0.5f && !triggered)
                {
                    triggered = true;
                    page.Front.alpha = 0f;
                    page.Front.blocksRaycasts = false;
                    page.Front.interactable = false;
                    page.Back.alpha = 0f;
                    page.Back.blocksRaycasts = false;
                    page.Back.interactable = false;
                }
                yield return null;
            }

            page.Front.alpha = 0f;
            page.Front.blocksRaycasts = false;
            page.Front.interactable = false;
            page.Back.alpha = 0f;
            page.Back.blocksRaycasts = false;
            page.Back.interactable = false;
        }
        
        public static IEnumerator ShowSide(UIMenuPage page,Direction direction, float speed)
        {
            float time = 0f;
            bool triggered = false;
            while (time < 1f)
            {
                if(time > 0.5f && !triggered)
                {
                    triggered = true;
                    switch (direction)
                    {
                        case Direction.LEFT:
                            page.Back.alpha = 1f;
                            page.Back.blocksRaycasts = true;
                            page.Back.interactable = true;
                            break;
                        case Direction.RIGHT:
                            page.Front.alpha = 1f;
                            page.Front.blocksRaycasts = true;
                            page.Front.interactable = true;
                            break;
                        default:
                            break;
                    }
                }
                yield return null;
            }

        }
        
        public static IEnumerator HideSide(UIMenuPage page,Direction direction, float speed)
        {
            float time = 0f;
            bool triggered = false;
            while (time < 1f)
            {
                if(time > 0.5f && !triggered)
                {
                    triggered = true;
                    switch (direction)
                    {
                        case Direction.LEFT:
                            page.Back.alpha = 0f;
                            page.Back.blocksRaycasts = false;
                            page.Back.interactable = false;
                            break;
                        case Direction.RIGHT:
                            page.Front.alpha = 0f;
                            page.Front.blocksRaycasts = false;
                            page.Front.interactable = false;
                            break;
                        default:
                            break;

                    }
                }
                yield return null;
            }

        }

        public static IEnumerator Flip(Transform transform, Direction direction, UIMenuPage page, float speed)
        {
            Vector3 endRotation;
            Vector3 startRotation = transform.localEulerAngles;
            CanvasGroup front = page.Front;
            CanvasGroup back = page.Back;

            switch (direction)
            {
                case Direction.LEFT:
                    endRotation = new Vector3(0, 180, 0);
                    break;
                case Direction.RIGHT:
                    endRotation = new Vector3(0, 0, 0);
                    break;
                default:
                    endRotation = new Vector3(0, 180, 0);
                    break;
            }

            float time = 0f;
            bool b = true;
            while (time < 1)
            {
                if (b && time > 0.5f)
                {
                    page.Top();
                    b = false;
                }
                switch (direction)
                {
                    case Direction.LEFT:
                        if(time >= 0.5)
                        {
                            front.alpha = 0;
                            front.blocksRaycasts = false;
                            front.interactable = false;
                            back.alpha = 1;
                            back.blocksRaycasts = true;
                            back.interactable = true;
                            back.transform.SetAsLastSibling();
                        }
                        break;
                    case Direction.RIGHT:
                        if(time >= 0.5)
                        {
                            front.alpha = 1;
                            front.blocksRaycasts = true;
                            front.interactable = true;
                            front.transform.SetAsLastSibling();
                            back.alpha = 0;
                            back.interactable = false;
                            back.blocksRaycasts = false;
                        }
                        break;
                    default:
                        break;
                }
                transform.localEulerAngles = Vector3.Lerp(startRotation, endRotation, time);
                yield return null;
                time += Time.deltaTime * speed;
            }

            transform.localEulerAngles = endRotation;
        }

        public static IEnumerator SlideOut(RectTransform Transform, Direction Direction, float Speed)
        {
            Vector2 endPosition;
            switch (Direction)
            {
                case Direction.UP:
                    endPosition = new Vector2(0, Screen.height);
                    break;
                case Direction.RIGHT:
                    endPosition = new Vector2(Screen.width, 0);
                    break;
                case Direction.DOWN:
                    endPosition = new Vector2(0, -Screen.height);
                    break;
                case Direction.LEFT:
                    endPosition = new Vector2(-Screen.width, 0);
                    break;
                default:
                    endPosition = new Vector2(0, Screen.height);
                    break;
            }

            float time = 0;
            while (time < 1)
            {
                Transform.anchoredPosition = Vector2.Lerp(Vector2.zero, endPosition, time);
                yield return null;
                time += Time.deltaTime * Speed;
            }

            Transform.anchoredPosition = endPosition;
        }
    }
}