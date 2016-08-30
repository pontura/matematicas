﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Isla : Screen {

    public Text titleField;
    public Text dialogueField;
    public GameObject dialogue;
    public Minigame minigame;
    private IslandsManager.DataIsland dataIsland;
    public states state;

    public MiningameBackground minigameSimpleInput;
    public MiningameBackground minigamePeso;
    public MiningameBackground minigameFracciones;
    public MiningameBackground minigameVelocidad;
    public MiningameBackground minigameFinal;

    public MathDevice mathDevice;

    public MinigamesManager.types minigameType;
    private bool tutorialDisplayed;
    private bool tutorial2Displayed;

    public enum states
    {
        BIENVENIDA,
        BIENVENIDA_ISLA,
        BIENVENIDA_DONE,        
        MISSION_PRESENTA,
        MISSION_DISTE_ALGO,
        MISSION_EXITOSA,
        MISSION_NO_TENES_NADA,
        MINIGAME,
        MINIGAME_STARTED,
        MINIGAME_READY
    }
    void Start()
    {
        
        Events.OnTripStarted += OnTripStarted;
        Events.OnMinigameReady += OnMinigameReady;
        Events.OnMinigameMistake += OnMinigameMistake;
        SetArrived();
    }
    void OnDestroy()
    {
        Events.OnTripStarted -= OnTripStarted;
        Events.OnMinigameReady -= OnMinigameReady;
        Events.OnMinigameMistake -= OnMinigameMistake;
    }
    void OnTripStarted()
    {
        state = states.BIENVENIDA;
    }
    public void SetArrived()
    {
        //state = states.BIENVENIDA;
        //minigame.Reset();        
    }
    void OnDisable()
    {
        if (minigamePeso)
        minigamePeso.gameObject.SetActive(false);
    }
    public override void OnScreenEnable()
    {
        Data.Instance.VolumenBaja();
        dialogue.SetActive(true);
        if (Data.Instance.userData.firstTimeHere && !tutorialDisplayed)
        {
            Events.OnTipsOn(2);
            tutorialDisplayed = true;
        }
        dataIsland = Game.Instance.islandsManager.activeIsland;

        minigameType = dataIsland.minigameType;

        if(minigameType == MinigamesManager.types.PESAR)
        {
            Data.Instance.SuenaBosque();
            minigamePeso.Init();
            minigame = minigame.GetComponent<MinigamePesos>();
            minigame.GetComponent<MinigamePesos>().Init();
        } else
        if (minigameType == MinigamesManager.types.SIMPLE_INPUT)
        {
            Data.Instance.SuenaPlaya();
            minigameSimpleInput.Init();
            minigame = minigame.GetComponent<MinigameSimpleInput>();
            minigame.GetComponent<MinigameSimpleInput>().Init();
        }
        else
        if (minigameType == MinigamesManager.types.FRACCIONES)
        {
            Data.Instance.SuenaBosque();
            minigameFracciones.Init();
            minigame = minigame.GetComponent<MinigameFracciones>();
            minigame.GetComponent<MinigameFracciones>().Init();
        }
        else
        if (minigameType == MinigamesManager.types.VELOCIDAD)
        {
            Data.Instance.SuenaPlaya();
            minigameVelocidad.Init();
            minigame = minigame.GetComponent<MinigameVelocidad>();
            minigame.GetComponent<MinigameVelocidad>().Init();
        }
        else if (minigameType == MinigamesManager.types.FINAL)
        {
            Data.Instance.SuenaBosque();
            minigameFinal.Init();
            if (Data.Instance.achievementEventsManager.portal == 1)
            {
                Isla12Ready();
                minigame.gameObject.SetActive(false);
                return;
            }
            else
            {
                minigame = minigame.GetComponent<MinigameFinal>();
                minigame.GetComponent<MinigameFinal>().Init();
            }
        }

        Events.OnBlockStatus(true);
        
        titleField.text = dataIsland.name;

        //if(state != states.BIENVENIDA)
        //    state = states.NADA;        
        
        dialogue.SetActive(true);
        minigame.gameObject.SetActive(false);

        CheckStep();       
	}
    void CheckStep()
    {
        if (minigameType == MinigamesManager.types.FINAL && Data.Instance.achievementEventsManager.portal == 1)
        {
            Game.Instance.gameManager.Open("Barco");
            return;
        }
        if (state == states.BIENVENIDA)
        {
            if (Data.Instance.achievementEventsManager.travelsSuccess == 0)
                SetText("¡Hola! Te damos la bienvenida.");
            else
                SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.Bienvenida));
            state = states.BIENVENIDA_ISLA;
        }  else if (Game.Instance.minigamesManager.ready)
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameReady));
            state = states.MINIGAME_READY;
            Data.Instance.userData.firstTimeHere = false;
        }
        else if (state == states.MINIGAME_STARTED)
        {
            dialogue.SetActive(false);
            minigame.gameObject.SetActive(true);
        } 
        else if (dataIsland.mission != null && dataIsland.mission.qty > 0)
        {
            state = states.MISSION_PRESENTA;
            string texto = dataIsland.mission.description;
            texto = SetTextQty(texto, dataIsland.mission.qty);
            SetText(texto);
        }
        else if (state == states.BIENVENIDA_ISLA)
        {
            SetText(Data.Instance.texts.GetBienvenidaXIsland(Game.Instance.islandsManager.activeIsland.id));
            state = states.MINIGAME;
        }
       else
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameInvita));
            state = states.MINIGAME;
        }
    }
    public void Next()
    {
        if (state == states.BIENVENIDA || state == states.BIENVENIDA_ISLA  || state == states.BIENVENIDA_DONE)
        {
            CheckStep();
        } 
        else 
        if (state == states.MISSION_PRESENTA)
        {
            switch (dataIsland.mission.element)
            {
                case Mission.elements.MADERA:   CheckIfConsume("madera"); break;
                case Mission.elements.ARENA:    CheckIfConsume("arena");  break;                
                case Mission.elements.PIEDRAS:  CheckIfConsume("piedras"); break;
            }
        } else if (state == states.MISSION_DISTE_ALGO
            || 
              state == states.MISSION_EXITOSA)
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameReady));
         //   state = states.MINIGAME_READY;
            state = states.MINIGAME;
            Data.Instance.userData.firstTimeHere = false;
        }
        else if (state == states.MISSION_NO_TENES_NADA)
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameInvita));
            state = states.MINIGAME;
        }
        else if (state == states.MINIGAME)
        {
            dialogue.SetActive(false);
            minigame.gameObject.SetActive(true);
            state = states.MINIGAME_STARTED;
            if (Data.Instance.userData.firstTimeHere && !tutorial2Displayed)
            {
                Events.OnTipsOn(3);
                tutorial2Displayed = true;
            }
        }
        else if (state == states.MINIGAME_READY)
        {
            if(Game.Instance.islandsManager.gotoIsland.id >0)
                Game.Instance.mainMenu.Barco();
            else
                Game.Instance.mainMenu.Mapa();
        }
    }
    void CheckIfConsume(string element)
    {
        Inventary inventary = Game.Instance.inventary;

        int totalInInventory = 0;
        if (element == "madera") totalInInventory = inventary.madera;
        if (element == "arena") totalInInventory = inventary.arena;
        if (element == "piedras") totalInInventory = inventary.piedras;

        if (totalInInventory >= dataIsland.mission.qty)
        {
            //Events.OnMinigameReady();

            string texto = Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionTienesTodoLoQueFalta);
            texto = SetTextQty(texto, dataIsland.mission.qty);
            SetText(texto);
            
            state = states.MISSION_EXITOSA;
            inventary.ConsumeElement(element, dataIsland.mission.qty);
            dataIsland.mission.qty = 0;
            Events.OnMissionComplete();
            
           
        }
        else if (totalInInventory > 0)
        {
            string texto = Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionTienesAlgo);
            switch (dataIsland.mission.element)
            {
                case Mission.elements.ARENA: texto = SetTextQty(texto, Game.Instance.inventary.arena); break;
                case Mission.elements.MADERA: texto = SetTextQty(texto, Game.Instance.inventary.madera); break;
                case Mission.elements.PIEDRAS: texto = SetTextQty(texto, Game.Instance.inventary.piedras); break;
            }
            Data.Instance.missionsManager.OnMissionProgress(dataIsland.mission.id, dataIsland.mission.qty - totalInInventory);
            //dataIsland.mission.qty -= totalInInventory;            
            inventary.ConsumeElement(element, totalInInventory);
            state = states.MISSION_DISTE_ALGO;
            SetText(texto);
        }
        else
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionNoTienesNada));
            state = states.MISSION_NO_TENES_NADA;
        }
    }
    void SetText(string field)
    {
        string element = "";
        int qty = 0;

        if (dataIsland.mission != null)
        {
            switch (dataIsland.mission.element)
            {
                case Mission.elements.ARENA: element = "arena"; qty = Game.Instance.inventary.arena; break;
                case Mission.elements.MADERA: element = "madera"; qty = Game.Instance.inventary.madera; break;
                case Mission.elements.PIEDRAS: element = "piedras"; qty = Game.Instance.inventary.piedras; break;
            }
        }

        field = field.Replace("[element]", element);

        dialogueField.text = field;
    }
    private string SetTextQty(string field, int qty)
    {
        return field.Replace("[qty]", qty.ToString());
    }
    public void OnMinigameReady()
    {
        if (dataIsland.minigameType != MinigamesManager.types.FINAL && dataIsland.minigameType != MinigamesManager.types.VELOCIDAD)
            Events.OnBlockSendRequest( minigame.GetDescriptionForBlock() );

        dialogue.SetActive(true);
        minigame.gameObject.SetActive(false);
        if (dataIsland.minigameType == MinigamesManager.types.FINAL)
        {
           AchievementsEvents.OnAchievementEvent(1);
           Isla12Ready();
        }
        else
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameReady));
        }

        state = states.MINIGAME_READY;
        Data.Instance.userData.firstTimeHere = false;
    }
    public void Isla12Ready()
    {
        SetText("¡Lo lograste!\nLideraste la misión Hypatia con valor, activaste tus poderes matemáticos en cada isla y ahora preparate para una nueva aventura.");         
    }
    public void OnMinigameMistake()
    {
        ///
    }
    public void CheckResul()
    {
        if (dataIsland.minigameType == MinigamesManager.types.PESAR)
        {
            minigame.GetComponent<MinigamePesos>().CheckResult();
        } else
        if (dataIsland.minigameType == MinigamesManager.types.SIMPLE_INPUT)
        {
            minigame.GetComponent<MinigameSimpleInput>().CheckResult();
        } else
            if (dataIsland.minigameType == MinigamesManager.types.FRACCIONES)
        {
            minigame.GetComponent<MinigameFracciones>().CheckResult();
        }
        else
        if (dataIsland.minigameType == MinigamesManager.types.VELOCIDAD)
        {
            minigame.GetComponent<MinigameVelocidad>().CheckResult();
        }
        else
        if (dataIsland.minigameType == MinigamesManager.types.FINAL)
        {
            minigame.GetComponent<MinigameFinal>().CheckResult();
        }
    }
    public void ResetDevice()
    {

    }
}
