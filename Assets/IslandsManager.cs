using UnityEngine;
using System.Collections;
using System;

public class IslandsManager : MonoBehaviour {

    public DataIsland activeIsland;
    public DataIsland gotoIsland;

    [Serializable]
    public class DataIsland
    {
        public string name;
        public int distance;
        public Mission mission;
        public IslandButton island;
        public int id;
        public bool madera;
        public bool arena;
        public bool piedras;
    }

    public DataIsland island1;
    public DataIsland island2;
    public DataIsland island3;
    public DataIsland island4;

	void Start () {
        activeIsland = island1;
	}
    public void Clicked(int id)
    {
        DataIsland clickedIsland = GetIslandById(id);
        int distance = (int)Vector3.Distance(clickedIsland.island.transform.localPosition, activeIsland.island.transform.localPosition);
        if (distance > 1)
        {
            clickedIsland.distance = distance;
            Events.Map_OpenIslandSignal(clickedIsland);
        }
        else
        {
            gotoIsland = new DataIsland();
            Data.Instance.mainMenu.Isla();
        }
    }
    public DataIsland GetIslandById(int id)
    {
        switch(id)
        {
            case 1: return island1;
            case 2: return island2;
            case 3: return island3;
            default: return island4;
        }
    }
    public void SetActive(DataIsland _activeIsland)
    {
        this.activeIsland = _activeIsland;
    }
    public void SetGotoIsland(DataIsland _gotoIsland)
    {
        this.gotoIsland = _gotoIsland;
    }
}
