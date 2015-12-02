using UnityEngine;
using System.Collections;

public class Mapa : Screen {

    public GameObject ship;
    public IslandsManager islandManager;

	void OnEnable () {
        ChangeIslandActive();
	}
	
	void ChangeIslandActive () {
        ship.transform.localPosition = islandManager.activeIsland.island.transform.localPosition;
	}
}
