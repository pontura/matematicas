﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Barco : Screen
{
    public Text notasField;
    public GameObject panel;
    public GameObject minigameNotReadyPanel;
    public List<ShipBox> boxes;
    public Animator anim;
    private bool tutorialDisplayed;

    void Start()
    {
        Events.OnShipRefreshCarga += OnShipRefreshCarga;
    }
    void OnDestroy()
    {
        Events.OnShipRefreshCarga -= OnShipRefreshCarga;
    }
    override public void OnScreenEnable()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        if (Data.Instance.userData.firstTimeHere && !tutorialDisplayed)
        {
            Events.OnTipsOn(4);
            tutorialDisplayed = true;
        }
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        Events.OnBlockStatus(true);
        if (Game.Instance.state == Game.states.MINIGAME_READY)
        {
            
            minigameNotReadyPanel.SetActive(false);
            panel.SetActive(true);
        }
        else
        {
            minigameNotReadyPanel.SetActive(true);
            panel.SetActive(false);
        }
        Invoke("OnShipRefreshCarga", 0.1f);

        string distance = Game.Instance.islandDistances.GetRuta(Game.Instance.islandsManager.activeIsland.id, Game.Instance.islandsManager.gotoIsland.id);
        notasField.text = distance + "\n";

        notasField.text += "El barco soporta " + Data.Instance.settings.barcoPesoMaximo.ToString() + " kilos " + " y va a " + Data.Instance.settings.barcoVelocidad.ToString() + "km/h \n";
        notasField.text += Data.Instance.settings.GetNotes();        
    }
    public void Ready()
    {
        anim.Play("Ship_close");
        panel.SetActive(false);
        Game.Instance.mainMenu.DeselectButtons();
        Invoke("Closed", 3);        
    }
    void Closed()
    {
        if (Game.Instance.islandsManager.gotoIsland != null && Game.Instance.islandsManager.gotoIsland.distance > 1)
            // Game.Instance.gameManager.OpenTrip();
            Game.Instance.gameManager.OpenTrip();
        else if (Game.Instance.state == Game.states.MINIGAME_READY)
            Game.Instance.mainMenu.Mapa();
        else
            Game.Instance.mainMenu.Isla();
    }
    public void OnShipRefreshCarga()
    {

        foreach (ShipBox shipBox in boxes)
            shipBox.Empty();

        Inventary inventary = Game.Instance.inventary;
        for (int a = 0; a < inventary.nafta; a++) AddBox(1);
        for (int a = 0; a < inventary.comida; a++) AddBox(2);
        for (int a = 0; a < inventary.madera; a++) AddBox(3);
        for (int a = 0; a < inventary.arena; a++) AddBox(4);
        for (int a = 0; a < inventary.piedras; a++) AddBox(5);
    }
    public void AddBox(int id)
    {
        foreach (ShipBox shipBox in boxes)
        {
            if (shipBox.IsAvailable())
            {
                shipBox.Add(id);
                return;
            }
        }
    }

}
