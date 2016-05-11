using UnityEngine;
using System.Collections;

public class AchievementSpeed : Achievement
{
	public void Init () {
        this.type = types.SPEED;

        if (pointsToBeReady <= Data.Instance.userData.speedExercices)
            Ready();
        else
            AchievementsEvents.OnNewSpeedExercices += OnNewSpeedExercices;
    }
    void OnNewSpeedExercices()
    {
        if (pointsToBeReady <= Data.Instance.userData.speedExercices)
        {
            Completed();
            AchievementsEvents.OnNewSpeedExercices -= OnNewSpeedExercices;
        }
    }
}
