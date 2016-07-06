using UnityEngine;
using System.Collections;

public class Mapa : Screen {

    public GameObject ship;
    public IslandsManager islandManager;
    public GameObject missionIcon;
    public GameObject fog;

	void OnEnable () {
        Data.Instance.SuenaTema(0.2f);
        //desbloquea la ultima isla:
        if (Data.Instance.achievementEventsManager.unblockedLastIsland == 1)
        {
            fog.SetActive(false);
        } else
            if (Data.Instance.achievementEventsManager.unblockedLastIsland == 0 && Data.Instance.userData.missionActive >= 10)
            {
                AchievementsEvents.OnAchievementEvent(7);
                fog.SetActive(false);
            }
            else
            {
                fog.SetActive(true);
            }

        //Game.Instance.islandsManager.gotoIsland = null;
        ChangeIslandActive();
        IslandsManager.DataIsland data = Game.Instance.islandsManager.GetIslandWithMission();
        if (data != null)
            missionIcon.transform.localPosition = data.island.transform.localPosition;
        else
            missionIcon.transform.localPosition = new Vector3(1000, 0, 0);
	}
	
	void ChangeIslandActive () {
        ship.transform.localPosition = islandManager.activeIsland.island.transform.localPosition;
	}
}
