using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Achievements : Screen
{
    void OnEnable()
    {
        Events.OnBlockStatus(false);
    }
}