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
=======
>>>>>>> Stashed changes
        DISTANCE
    }

    public int id;
    public bool ready;
    public int points;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    public int pointsToBeReady;

    public void Ready()
    {
        this.ready = true;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    }
    public void Completed()
    {
        this.ready = true;
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        AchievementsEvents.OnReady(id);
    }
}
