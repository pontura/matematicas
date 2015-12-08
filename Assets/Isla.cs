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
            OnMinigameReady();
        } else
        if (dataIsland.mission != null)
        {
            state = states.MISSION_PRESENTA;
            SetText(dataIsland.mission.description);
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
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionCompleta));
            inventary.ConsumeElement(element, dataIsland.mission.qty);
            state = states.MISSION_EXITOSA;
        }
        else if (totalInInventory > 0)
        {
            SetText(Data.Instance.texts.GetRandomText(Data.Instance.texts.MisionTienesAlgo));
            inventary.ConsumeElement(element, Game.Instance.inventary.arena);
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

        if (dataIsland.mission != null)
        {
            switch (dataIsland.mission.element)
            {
                case Mission.elements.ARENA: element = "arena"; break;
                case Mission.elements.MADERA: element = "madera"; break;
                case Mission.elements.PIEDRAS: element = "piedras"; break;
            }
        }

        field = field.Replace("[element]", element);
        field = field.Replace("[qty]", field);

        dialogueField.text = field;
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
