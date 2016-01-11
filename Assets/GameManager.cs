using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Screen Mapa;
    public Screen Isla;
    public Screen Barco;
    public Screen Logros;
    public Screen Block;
    public Screen Customizer;
    
    public Screen IslandDetail;
    public Screen Trip;

    public GameObject tvImage;

	void Start () {
	
	}
	public void Open(string name)
    {
        InactivateScreens();
        switch (name)
        {
            case "Mapa": Mapa.Activate(true); tvImage.SetActive(true); break;
            case "Isla": Isla.Activate(true); tvImage.SetActive(false); break;
            case "Barco": Barco.Activate(true); tvImage.SetActive(true); break;
            case "Trip": Block.Activate(true); tvImage.SetActive(false); break;
            case "Logros": Logros.Activate(true); tvImage.SetActive(false); break;
            case "Customizer": Events.OnCustomizerActive(true); Customizer.Activate(true); tvImage.SetActive(true); break;
            case "IslandDetail": IslandDetail.Activate(true); tvImage.SetActive(false); break;
        }
	}
    public void OpenBlock()
    {
        Block.Activate(true);
        Block.GetComponent<Block>().Open();
    }
    public void CloseBlock()
    {
        Block.GetComponent<Block>().Close();
    }
    private void InactivateScreens()
    {
        Mapa.Activate(false);
        Isla.Activate(false);
        Barco.Activate(false);
        Customizer.Activate(false);
        Trip.Activate(false);
        IslandDetail.Activate(false);
        Logros.Activate(false);

        Events.OnCustomizerActive(false);
    }
    public void IslandDetailPopup()
    {
        Open("Mapa");
        IslandDetail.Activate(true);
    }
    public void OpenTrip()
    {
        InactivateScreens();
        Game.Instance.mainMenu.DeselectButtons();
        Trip.Activate(true);
    }
    public void Arrived()
    {
        Game.Instance.islandsManager.SetActive (Game.Instance.islandsManager.gotoIsland);
        Game.Instance.islandsManager.SetGotoIsland(new IslandsManager.DataIsland());
        Isla.GetComponent<Isla>().SetArrived();
        Game.Instance.mainMenu.Isla();
    }
}
