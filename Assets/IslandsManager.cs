using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IslandsManager : MonoBehaviour {

    public DataIsland activeIsland;
    public DataIsland gotoIsland;
    public List<DataIsland> islands;

    [Serializable]
    public class NpcSettings
    {
        public SavedSettings.PlayerSettings.sexType sex;
        public int hair;
        public int clothes;
        public int legs;
        public int shoes;
    }
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
        public MinigamesManager.types minigameType;
        public NpcSettings npsSettings;
        public int BackgroundBitmapID;
        public int ObjectsBitmapID;
    }
	void Start () {
        activeIsland = GetIslandById( Data.Instance.userData.islandActive );
        SetNewMission(Data.Instance.userData.missionActive);
        Events.OnNewMission += OnNewMission;
	}
    void OnDestroy()
    {
        Events.OnNewMission -= OnNewMission;
    }
    void OnNewMission(int id)
    {
        SetNewMission(id);
    }
    void SetNewMission(int missionID)
    {
        if (Data.Instance.missionsManager.missions.Count == missionID)
        {
            Debug.Log("No NORE MISSIONS");
        }
        else
        {
            Mission mission = Data.Instance.missionsManager.missions[missionID];
            GetIslandById(mission.islandId).mission = mission;
        }
    }
    public DataIsland GetIslandWithMission()
    {
        foreach (DataIsland di in islands)
            if (di.mission != null)
                return di;
        return null;
    }
    public void Clicked(int id)
    {
        
        DataIsland clickedIsland = GetIslandById(id);
        int distance = (int)Vector3.Distance(clickedIsland.island.transform.position, activeIsland.island.transform.position);

        print(clickedIsland.name + "Clicked : " + id + "   clickedIsland: " + clickedIsland.island.transform.localPosition + "  activeIsland: " + activeIsland.island.transform.localPosition + "  distance: " + distance);

        if (distance > 1)
        {
            clickedIsland.distance = distance;
            Events.Map_OpenIslandSignal(clickedIsland);
        }
        else
        {
            gotoIsland = new DataIsland();
            Game.Instance.mainMenu.Isla();
        }
    }
    public DataIsland GetIslandById(int id)
    {
        foreach (DataIsland di in islands)
            if(di.id == id)
                return di;
        return null;
    }
    public void SetActive(DataIsland _activeIsland)
    {
        this.activeIsland = _activeIsland;
    }
    public void SetGotoIsland(DataIsland _gotoIsland)
    {
        this.gotoIsland = _gotoIsland;
    }
    public void SetMissionToIsland(Mission mission, int islandId)
    {
        GetIslandById(islandId).mission = mission;
    }
}
