using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject tvImage;
    public Screen Mapa;
    public Screen Isla;
    public Screen Barco;
    public Screen Logros;
    public Screen Block;
    
    public Screen IslandDetail;
    public Screen Trip;

	void Start () {
	
	}
	public void Open(string name)
    {
        Mapa.Activate(false);
        Isla.Activate(false);
        Barco.Activate(false);
        Block.Activate(false);
        Trip.Activate(false);
        IslandDetail.Activate(false);
        Logros.Activate(false);


        switch (name)
        {
            case "Mapa": Mapa.Activate(true);                   tvImage.SetActive(true);  break;
            case "Isla": Isla.Activate(true);                   tvImage.SetActive(false); break;
            case "Barco": Barco.Activate(true);                 tvImage.SetActive(true); break;
            case "Trip": Block.Activate(true);                  tvImage.SetActive(false); break;
            case "IslandDetail": IslandDetail.Activate(true);   tvImage.SetActive(false); break;
        }
	}
    public void OpenBlock()
    {
        Block.Activate(true);
    }
    public void OpenTrip()
    {
        IslandDetail.Activate(false);
        Game.Instance.mainMenu.DeselectButtons();
        Trip.Activate(true);
    }
    public void Arrived()
    {
        Game.Instance.islandsManager.SetActive (Game.Instance.islandsManager.gotoIsland);
        Game.Instance.islandsManager.SetGotoIsland(new IslandsManager.DataIsland());
        Game.Instance.mainMenu.Isla();
    }
}
