using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    static GameObject eventSystem;
    public readonly static Tags tags = new Tags();

    public Config()
    {
        eventSystem = GameObject.FindGameObjectWithTag(tags.eventSystem);
    }

    public static void EnableEventSystem()
    {
        eventSystem.SetActive(true);
    }

    public static void DisableEventSystem()
    {
        eventSystem.SetActive(false);
    }
}