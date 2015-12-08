using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IslandSignal : MonoBehaviour {

    public GameObject panel;
    public Text title;
    public Text desc;
    private IslandsManager.DataIsland islandData;
    public GameObject missionPanel;

	void Start () {
        Events.Map_OpenIslandSignal += Map_OpenIslandSignal;
        Close();
	}
    void OnDestroy()
    {
        Events.Map_OpenIslandSignal -= Map_OpenIslandSignal;
    }
    void Map_OpenIslandSignal(IslandsManager.DataIsland data)
    {
        this.islandData = data;
        panel.SetActive(true);
        panel.transform.localPosition = data.island.transform.localPosition / 4;
        title.text = data.name;
        desc.text = "Distance: " + data.distance + " Km.\n";

        if (data.mission != null)
        {
            desc.text += data.mission.description;
            missionPanel.SetActive(true);
        }
        else
        {
            missionPanel.SetActive(false);
            string item = "";
            if (islandData.madera) item = "madera";
            if (islandData.arena) item = "arena";
            if (islandData.piedras) item = "piedras";
            desc.text += "Esta isla es rica en: " + item;
        }
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Go()
    {
        Game.Instance.islandsManager.SetGotoIsland(islandData);
        Game.Instance.mainMenu.Isla();
        Close();
    }
}
