using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IslandSignal : MonoBehaviour {

    public GameObject panel;
    public Text title;
    public Text desc;
    private IslandsManager.DataIsland islandData;

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
        desc.text = " Distance: " + data.distance + " Km.";
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Go()
    {
        Data.Instance.islandsManager.SetGotoIsland(islandData);
        Data.Instance.mainMenu.Isla();
        Close();
    }
}
