using UnityEngine;
using System.Collections;

public class AchievementEvent : Achievement {

    public int eventID;

	public void Init () {

        this.type = types.EVENT;

        if (Data.Instance.achievementEventsManager.isReady(this.eventID) == 1)
            Ready();
        else
            AchievementsEvents.OnAchievementEvent += OnAchievementEvent;
	}
    void OnAchievementEvent(int _eventID)
    {
        if (this.eventID == _eventID)
            Completed();
    }
}
