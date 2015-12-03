using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IslandDetail : Screen {

    public Text titleField;
    public Text detailsField;
    public Text inventaryField;
    public Text missionField;

    public GameObject conCarga;
    public GameObject sinCarga;

	void OnEnable () {
        IslandsManager.DataIsland dataIsland = Game.Instance.islandsManager.gotoIsland;
        titleField.text = "Viajando a " + dataIsland.name;
        string details = "Distancia: " + dataIsland.distance + "\n";
        details += "Velocidad: 10km/h \n";
        details += "Tripulación: 2 pasajeros";

        missionField.text = "";
        if (dataIsland.mission != null)
            missionField.text += dataIsland.mission.description;

        detailsField.text = details;

        Inventary inventary = Game.Instance.inventary;
        string inventaryText = "";

        if (inventary.nafta > 0) inventaryText +=   inventary.nafta +   " caja/s de nafta\n";
        if (inventary.comida > 0) inventaryText +=  inventary.comida +  " caja/s de comida\n";
        if (inventary.madera > 0) inventaryText +=  inventary.madera +  " caja/s de madera\n";
        if (inventary.piedras > 0) inventaryText += inventary.piedras + " caja/s de piedras\n";
        if (inventary.arena > 0) inventaryText +=   inventary.arena +   " caja/s de arena\n";

        if (inventaryText == "")
        {
            conCarga.SetActive(false);
            sinCarga.SetActive(true);
        }
        else
        {
            conCarga.SetActive(true);
            sinCarga.SetActive(false);
        }

        inventaryField.text = inventaryText;
        
	}
}