using UnityEngine;
using System.Collections;

public class AchievementDistance : Achievement {

    public int missionID;

	public void Init () {
        this.type = types.DISTANCE;
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        if (pointsToBeReady < Data.Instance.userData.distanceTraveled)
            Ready();
        else
            AchievementsEvents.OnNewDistance += OnNewDistance;
    }
    void OnNewDistance(int distanceTraveled)
    {
        if (distanceTraveled > pointsToBeReady)
        {
            Completed();
            AchievementsEvents.OnNewDistance -= OnNewDistance;
        }
=======
=======
>>>>>>> Stashed changes
        AchievementsEvents.OnMissionComplete += OnMissionComplete;
	}
    void OnMissionComplete(int _missionID)
    {
        if (missionID == _missionID)
            Ready();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
}
