using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Isla : Screen {

    public Text titleField;
    public Text dialogueField;
    public GameObject dialogue;
    public Minigame minigame;
    private IslandsManager.DataIsland dataIsland;
    public states state;
    public Animator anim;

    public enum states
    {
        NADA,
        MISSION_PRESENTA,
        MISSION_DISTE_ALGO,
        MISSION_EXITOSA,
        MISSION_NO_TENES_NADA,
        MINIGAME,
        MINIGAME_READY
    }
    void Start()
    {
        Events.OnMinigameReady += OnMinigameReady;
    }
    void OnDestroy()
    {
        Events.OnMinigameReady -= OnMinigameReady;
    }
	void OnEnable () {
        anim.Play("MgA_idle");
        state = states.NADA;

        dialogue.SetActive(true);
        minigame.Reset();
        minigame.gameObject.SetActive(false);

        dataIsland = Game.Instance.islandsManager.activeIsland;
        titleField.text = dataIsland.name;

        dialogueField.text = "";

        if (Game.Instance.minigamesManager.ready)
        {
            dialogue.SetActive(true);
            minigame.gameObject.SetActive(false);
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameReady));
            state = states.MINIGAME_READY;
        } else
        if (dataIsland.mission != null)
        {
            state = states.MISSION_PRESENTA;

            string texto = dataIsland.mission.description;
            texto = SetTextQty(texto, dataIsland.mission.qty);
            SetText(texto);
        }
        else
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameInvita));
            state = states.MINIGAME;
        }
	}
    public void Next()
    {
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
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameInvita));
            state = states.MINIGAME;
        }
        else if (state == states.MISSION_NO_TENES_NADA || state == states.NADA)
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameInvita));
            state = states.MINIGAME;
        }
        else if (state == states.MINIGAME)
        {
            dialogue.SetActive(false);
            minigame.gameObject.SetActive(true);
        }
        else if (state == states.MINIGAME_READY)
        {
            Game.Instance.mainMenu.Barco();
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
            string texto = Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionTienesTodoLoQueFalta);
            texto = SetTextQty(texto, dataIsland.mission.qty);
            SetText(texto);
            state = states.MISSION_EXITOSA;
            inventary.ConsumeElement(element, dataIsland.mission.qty);
            dataIsland.mission.qty = 0;
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
            SetText(texto);
            dataIsland.mission.qty -= totalInInventory;
            inventary.ConsumeElement(element, totalInInventory);
            state = states.MISSION_DISTE_ALGO;
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

       // field = field.Replace("[qty]", qty.ToString() );

        dialogueField.text = field;
    }
    private string SetTextQty(string field, int qty)
    {
        return field.Replace("[qty]", qty.ToString());
    }
    public void OnMinigameReady()
    {
        anim.Play("MgA_win");
        dialogue.SetActive(true);
        minigame.gameObject.SetActive(false);
        SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MinigameReady));
        state = states.MINIGAME_READY;
    }
}
