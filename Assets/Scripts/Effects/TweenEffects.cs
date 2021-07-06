using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public static class TweenEffects
{
    /// <summary>
    /// Animation starts with your alpha.
    /// </summary>
    public static void FadeOut(Image image, float duration, TweenCallback callbackStartAnimation, TweenCallback callbackEndAnimation)
    {
        image.DOFade(1, duration).OnStart(callbackStartAnimation).OnComplete(callbackEndAnimation);
    }

    /// <summary>
    /// Animation starts with your alpha.
    /// </summary>
    public static void FadeIn(Image image, float duration, TweenCallback callbackStartAnimation, TweenCallback callbackEndAnimation)
    {
        image.DOFade(0, duration).OnStart(callbackStartAnimation).OnComplete(callbackEndAnimation);
    }

    /// <summary>
    /// Change of transform.position in this effect.
    /// </summary>
    public static void EaseInBounce(Transform transform, Vector3 punch, float duration, TweenCallback callbackStartAnimation, TweenCallback callbackEndAnimation)
    {
        transform.DOPunchPosition(punch, duration).SetEase(Ease.InBounce).OnStart(callbackStartAnimation).OnComplete(callbackEndAnimation);
    }

    /// <summary>
    /// Animation end with scale 1.
    /// </summary>
    public static void BounceScale(Transform transform, float startScale, float targetScale, float timeToTargetScale, float timeToFinish, TweenCallback callbackEndAnimation)
    {
        transform.localScale = new Vector3(startScale, startScale, startScale);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(targetScale, timeToTargetScale));
        sequence.Append(transform.DOScale(1f, timeToFinish));
        sequence.AppendCallback(callbackEndAnimation);
    }
}
