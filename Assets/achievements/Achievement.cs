using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Achievement  {

    public string title;
    public types type;
    public enum types
    {
        MISSION_COMPLETE,
<<<<<<< Updated upstream
        DISTANCE,
        BLOCK
    }
    public string image;
    public int id;
    public bool ready;
    public int points;
    public int progress;
=======
        DISTANCE
    }

    public int id;
    public bool ready;
    public int points;
>>>>>>> Stashed changes
    public int pointsToBeReady;

    public void Ready()
    {
        this.ready = true;
<<<<<<< Updated upstream
    }
    public void Completed()
    {
        this.ready = true;
=======
>>>>>>> Stashed changes
        AchievementsEvents.OnReady(id);
    }
}
