using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IslandSignal : MonoBehaviour {

    public AchivementButtonUI achievementIcon;
    public GameObject panel;
    public Text title;
    public Text desc;
    private IslandsManager.DataIsland islandData;
    public GameObject missionPanel;

    public GameObject iconMadera;
    public GameObject iconArena;
    public GameObject iconPiedras;

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
        iconMadera.SetActive(false);
        iconArena.SetActive(false);
        iconPiedras.SetActive(false);

        this.islandData = data;
        panel.SetActive(true);
        panel.transform.localPosition = data.island.transform.localPosition / 4;
        title.text = data.name;
        desc.text = "Distancia: " + data.distance + " Km.\n";

        string item = "";
        if (islandData.madera) { item = "madera";       iconMadera.SetActive(true); }
        if (islandData.arena) { item = "arena";         iconArena.SetActive(true); }
        if (islandData.piedras) { item = "piedras";     iconPiedras.SetActive(true); }


        if (data.mission != null)
        {
          //  desc.text += data.mission.GetDescription();
            desc.text += data.mission.description;
            missionPanel.SetActive(true);
            achievementIcon.LoadImage("iconBridge.png");
            achievementIcon.SetProgress(1);
        }
        else
        {
            missionPanel.SetActive(false);    

            if(item=="")
                desc.text += "Esta isla tiene estación energética y un mercado de alimentos";
            else
                desc.text += "Esta isla es rica en " + item +  " además de poseer energía y alimentos.";
        }
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Go()
    {
        print("GO");
        Game.Instance.islandsManager.SetGotoIsland(islandData);
        Game.Instance.gameManager.IslandDetailPopup();
        Close();
    }
}
