using UnityEngine;
using System.Collections;

public class Mapa : Screen {

    public GameObject ship;
    public IslandsManager islandManager;
    public GameObject missionIcon;

	void OnEnable () {
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
