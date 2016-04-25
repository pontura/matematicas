using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IslandSignal : MonoBehaviour {

    public Animation anim;
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

        string distance = Game.Instance.islandDistances.GetRuta(Game.Instance.islandsManager.activeIsland.id, data.id);
        string details = "";
        if (distance == "")
            details = "Distancia: " + data.distance + " Km.\n";
        else
            details = distance + "\n";

        desc.text = details;



        string item = "";
        if (islandData.madera) { item = "madera";       iconMadera.SetActive(true); }
        if (islandData.arena) { item = "arena";         iconArena.SetActive(true); }
        if (islandData.piedras) { item = "piedras";     iconPiedras.SetActive(true); }


        if (data.mission.qty >0)
        {
          //  desc.text += data.mission.GetDescription();
            string missionDesc = Data.Instance.missionsManager.GetDescription(data.mission.id);
            desc.text += missionDesc;
            missionPanel.SetActive(true);
            Achievement achievement = AchievementsManager.Instance.GetAchievement(data.mission.id);
            achievementIcon.LoadImage(achievement.image);
            achievementIcon.SetProgress(achievement.progress);
        }
        else
        {
            missionPanel.SetActive(false);    

            if(item=="")
                desc.text += "Esta isla tiene estación energética y un mercado de alimentos";
            else
                desc.text += "Esta isla es rica en " + item +  " además de poseer energía y alimentos.";
        }

        anim["PopupOn"].normalizedTime = 0;
        anim.Play("PopupOn");
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
