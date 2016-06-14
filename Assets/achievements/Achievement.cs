﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Achievement  {

    public string title;
    public types type;
    public enum types
    {
        MISSION_COMPLETE,
        DISTANCE,
        BLOCK,
        SPEED,
        GEMA,
        EVENT
    }
    public string image;
    public int id;
    public bool ready;
    public int points;
    public int progress;
    public int pointsToBeReady;

    public void Ready()
    {
        this.ready = true;
    }
    public void Completed()
    {
        this.ready = true;
        AchievementsEvents.OnReady(id);
    }
}
