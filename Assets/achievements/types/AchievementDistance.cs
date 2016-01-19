using UnityEngine;
using System.Collections;

public class AchievementDistance : Achievement {

    public int missionID;

	public void Init () {
        this.type = types.DISTANCE;
        AchievementsEvents.OnMissionComplete += OnMissionComplete;
	}
    void OnMissionComplete(int _missionID)
    {
        if (missionID == _missionID)
            Ready();
    }
}
