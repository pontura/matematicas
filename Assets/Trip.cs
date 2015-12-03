using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trip : Screen {

    public Text titleField;
    public Text inventaryField;

	void OnEnable () {
        Events.OnTripStarted();
        titleField.text = "Rumbo a " + Game.Instance.islandsManager.activeIsland.name;
        Invoke("Arrive", 2);
	}
    void Arrive()
    {
        Game.Instance.gameManager.Arrived();
        Game.Instance.mainMenu.Isla();
    }
}
