using System;
using _Source.Services;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class FadeService : IFadeService
{
    public void FadeIn(Image image, float duration, Action onComplete = null)
    {
        image.DOFade(1, duration).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void FadeOut(Image image, float duration, Action onComplete)
    {
        image.DOFade(0, duration).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }
}