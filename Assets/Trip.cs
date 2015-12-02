using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Trip : Screen {

    public Text titleField;
    public Text inventaryField;

	void OnEnable () {
        titleField.text = "Rumbo a " + Data.Instance.islandsManager.activeIsland.name;
        Invoke("Arrive", 2);
	}
    void Arrive()
    {
        Data.Instance.gameManager.Arrived();
        Data.Instance.mainMenu.Mapa();
    }
}
