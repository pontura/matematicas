using UnityEngine;
using System.Collections;

public class AchievementEventsManager : MonoBehaviour {

    public int portal;

	void Start () {
        portal = PlayerPrefs.GetInt("achievement_event_1", 0);
        AchievementsEvents.OnAchievementEvent += OnAchievementEvent;
	}
    void OnAchievementEvent(int eventID)
    {
        switch (eventID)
        {
            case 1: portal = 1; break;
        }
        PlayerPrefs.SetInt("achievement_event_" + eventID, 1);
    }
    public int isReady(int _eventID)
    {
        int eventID = 0;
        switch (_eventID)
        {
            case 1: eventID = portal; break;
        }
        return eventID;
    }
}
