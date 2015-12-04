using UnityEngine;
using System.Collections;

public class Mapa : Screen {

    public GameObject ship;
    public IslandsManager islandManager;
    public GameObject missionIcon;

	void OnEnable () {
        Game.Instance.islandsManager.gotoIsland = null;
        ChangeIslandActive();
        missionIcon.transform.localPosition = Game.Instance.islandsManager.GetIslandWithMission().island.transform.localPosition;
	}
	
	void ChangeIslandActive () {
        ship.transform.localPosition = islandManager.activeIsland.island.transform.localPosition;
	}
}
