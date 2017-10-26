using UnityEngine;
using System.Collections;

public class AchievementEventsManager : MonoBehaviour {

    public int travelsSuccess;
    public int unblockedLastIsland;
    public int portal;
    public int viajes1;
    public int viajes2;
    public int viajes3;

    public int viajes4;
    public int viajes5;

	void Start () {
        portal = PlayerPrefs.GetInt("achievement_event_1", 0);
        viajes1 = PlayerPrefs.GetInt("achievement_event_2", 0);
        viajes2 = PlayerPrefs.GetInt("achievement_event_3", 0);
        viajes3 = PlayerPrefs.GetInt("achievement_event_4", 0);
        viajes4 = PlayerPrefs.GetInt("achievement_event_5", 0);
        viajes5 = PlayerPrefs.GetInt("achievement_event_6", 0);
        unblockedLastIsland = PlayerPrefs.GetInt("achievement_event_7", 0);

        AchievementsEvents.OnAchievementEvent += OnAchievementEvent;
        Events.OnShipArrived += OnShipArrived;
        Events.OnShipDie += OnShipDie;
	}
    void OnShipDie()
    {
        travelsSuccess = 0;
    }
    void OnShipArrived()
    {
        travelsSuccess++;
        if (travelsSuccess >= 2 && viajes1 == 0) AchievementsEvents.OnAchievementEvent(2);
        if (travelsSuccess >= 4 && viajes2 == 0) AchievementsEvents.OnAchievementEvent(3);
        if (travelsSuccess >= 8 && viajes3 == 0) AchievementsEvents.OnAchievementEvent(4);
        if (travelsSuccess >= 16 && viajes4 == 0) AchievementsEvents.OnAchievementEvent(5);
        if (travelsSuccess >= 32 && viajes5 == 0) AchievementsEvents.OnAchievementEvent(6);
    }
    void OnAchievementEvent(int eventID)
    {
        switch (eventID)
        {
            case 1: portal = 1; break;
            case 2: viajes1 = 1; break;
            case 3: viajes2 = 1; break;
            case 4: viajes3 = 1; break;
            case 5: viajes4 = 1; break;
            case 6: viajes5 = 1; break;
            case 7: unblockedLastIsland = 1; break;
        }
        PlayerPrefs.SetInt("achievement_event_" + eventID, 1);
    }
    public int isReady(int _eventID)
    {
        int eventID = 0;
        switch (_eventID)
        {
            case 1: eventID = portal; break;
            case 2: eventID = viajes1; break;
            case 3: eventID = viajes2; break;
            case 4: eventID = viajes3; break;
            case 5: eventID = viajes4; break;
            case 6: eventID = viajes5; break;
            case 7: eventID = unblockedLastIsland; break;
        }
        return eventID;
    }
}
