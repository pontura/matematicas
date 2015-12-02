using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

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
            case "Mapa": Mapa.Activate(true); break;
            case "Isla": Isla.Activate(true); break;
            case "Barco": Barco.Activate(true); break;
            case "Trip": Block.Activate(true); break;
            case "IslandDetail": IslandDetail.Activate(true); break;
        }
	}
    public void OpenBlock()
    {
        Block.Activate(true);
    }
    public void OpenTrip()
    {
        IslandDetail.Activate(false);
        Data.Instance.mainMenu.DeselectButtons();
        Trip.Activate(true);
    }
    public void Arrived()
    {
        Data.Instance.islandsManager.SetActive (Data.Instance.islandsManager.gotoIsland);
        Data.Instance.islandsManager.SetGotoIsland(new IslandsManager.DataIsland());
        Data.Instance.mainMenu.Isla();
    }
}
