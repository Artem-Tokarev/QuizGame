using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Restart : MonoBehaviour
{
    Image image;
    GameObject restartButton;
    TweenCallback restartCallback;
    IRestartObject restartObject;

    void Awake()
    {
        image = GetComponentInChildren<Image>();
        restartButton = GetComponentsInChildren<Transform>(true)[2].gameObject;
        restartCallback = new TweenCallback(EnableRestartButton);
        restartCallback += Config.EnableEventSystem;
    }

    public void SetRestart(IRestartObject restartObject)
    {
        this.restartObject = restartObject;
    }

    void EnableRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void ShowRestartMenu()
    {
        TweenEffects.FadeOut(image, 1, Config.DisableEventSystem, restartCallback);
    }

    void HideRestartMenu()
    {
        restartButton.SetActive(false);
        TweenEffects.FadeIn(image, 1, Config.DisableEventSystem, Config.EnableEventSystem);
    }

    /// <summary>
    /// Use in UI button OnClick().
    /// </summary>
    public void RestartObject()
    {
        restartObject.Restart();
        HideRestartMenu();
    }
}