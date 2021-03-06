﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IslandDetail : Screen {

    public Text titleField;
    public Text detailsField;
    public Text inventaryField;
  //  public Text dialogueField;
    public Text notesField;

    public GameObject Dialogue;
    public GameObject Menu;
    public GameObject conCarga;
    public GameObject sinCarga;
    public Animator anim;

	void OnEnable () {
        Dialogue.SetActive(true);
        Menu.SetActive(false);

        anim.Play("MgA_map");
        IslandsManager.DataIsland dataIsland = Game.Instance.islandsManager.gotoIsland;
        titleField.text = dataIsland.name;
      //  string details = "Distancia: " + dataIsland.distance + "\n";



        string distance = Game.Instance.islandDistances.GetRuta(Game.Instance.islandsManager.activeIsland.id, dataIsland.id);
        string details = "";
        if (distance == "")
            details = "Distancia: " + dataIsland.distance + " Km.";
        else
            details = distance;

       // details += "Tripulación: 2 pasajeros";

      //  dialogueField.text = "¡Hola! ¿Quieres venir a " + dataIsland.name + "?" + "\n";        

        if (dataIsland.mission != null)
        {
           // string texto = dataIsland.mission.GetDescription();
            string texto = dataIsland.mission.description;
         //   dialogueField.text += "Necesitamos tu ayuda: " + texto;
        }
        else
        {
        //    if (dataIsland.madera) dialogueField.text += "Nuestra isla es famosa por sus grandes bosques y su excelente madera";
        //    if (dataIsland.arena) dialogueField.text += "Nuestra isla es famosa por sus playas y su gran cantidad de arena";
        //    if (dataIsland.piedras) dialogueField.text += "Nuestra isla es famosa por sus acantilados y su variedad de piedras";
        }       

        detailsField.text = details;

        Inventary inventary = Game.Instance.inventary;
        string inventaryText = "Hay en el barco:\n";

        if (inventary.nafta > 0) inventaryText +=   inventary.nafta +   " caja/s de nafta\n";
        if (inventary.comida > 0) inventaryText +=  inventary.comida +  " caja/s de comida\n";
        if (inventary.madera > 0) inventaryText +=  inventary.madera +  " caja/s de madera\n";
        if (inventary.piedras > 0) inventaryText += inventary.piedras + " caja/s de piedras\n";
        if (inventary.arena > 0) inventaryText +=   inventary.arena +   " caja/s de arena\n";

        if (inventary.nafta == 0 || inventary.comida == 0 && Game.Instance.state == Game.states.MINIGAME_READY)
        {
            if (inventary.nafta == 0)
                inventaryText = "No podés salir sin energía";
            else
                inventaryText = "No podés salir sin algo de comida";
            conCarga.SetActive(false);
            sinCarga.SetActive(true);
        }
        else
        {
            conCarga.SetActive(true);
            sinCarga.SetActive(false);
        }

        inventaryField.text = inventaryText;

        notesField.text = Data.Instance.settings.GetNotes();
        
    //}
    //public void Next()
    //{
        Dialogue.SetActive(false);
        Menu.SetActive(true);
    }
    public void Back()
    {
        Game.Instance.mainMenu.Mapa();
        gameObject.SetActive(false);
    }
}