using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellEffects
{   
    public void EaseInBounce(Transform transform)
    {
        TweenEffects.EaseInBounce(transform, new Vector3(1, 0, 0), duration: 0.5f, Config.DisableEventSystem, Config.EnableEventSystem);
    }

    public void BounceEffect(List<CellData> cellsData)
    {
        for (int i = 0; i < cellsData.Count; i++)
            TweenEffects.BounceScale(cellsData[i].cellTransform, startScale: 0, targetScale: 1.2f, timeToTargetScale: 0.5f, timeToFinish: 0.25f, callbackEndAnimation: null);
    }

    public void BounceEffect(Transform transform, float startScale = 0, TweenCallback callbackEndAnimation = null)
    {
        TweenEffects.BounceScale(transform, startScale, targetScale: 1.2f, timeToTargetScale: 0.5f, timeToFinish: 0.25f, callbackEndAnimation);
    }
}