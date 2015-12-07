using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barco : Screen
{
    public Text notasField;
    public GameObject minigameNotReadyPanel;
 
	override public void OnScreenEnable () {

        if (Game.Instance.state == Game.states.MINIGAME_READY)
            minigameNotReadyPanel.SetActive(false);
        else
            minigameNotReadyPanel.SetActive(true);

        notasField.text = Data.Instance.settings.GetNotes();
	}
    public void Ready()
    {
        if (Game.Instance.state == Game.states.MINIGAME_READY && Game.Instance.islandsManager.gotoIsland.distance <1)
            Game.Instance.mainMenu.Mapa();
        else
            Game.Instance.mainMenu.Isla();
    }
	
}
