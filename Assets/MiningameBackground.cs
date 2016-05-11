using UnityEngine;
using System.Collections;

public class MiningameBackground : MonoBehaviour {

    public Character Character;
    public Character Npc;

    public CharacterManager characterManager;
    public CharacterManager npcCharacterManager;

    private int lastIslandID;
    public GameObject[] backgrounds;

    private int animationID;

    private bool loaded;

	void Start () {
        Events.OnMinigameStart += OnMinigameStart;
        Events.OnMinigameStartCalculator += OnMinigameStartCalculator;
        Events.OnMinigameReady += OnMinigameReady;
        
        Events.OnMinigameMistake += OnMinigameMistake;
        Events.OnCustomizerSave += OnCustomizerSave;
	}
    void OnDestroy()
    {
        Events.OnCustomizerSave -= OnCustomizerSave;
        Events.OnMinigameStartCalculator -= OnMinigameStartCalculator;
        Events.OnMinigameStart -= OnMinigameStart;
        Events.OnMinigameReady -= OnMinigameReady;
        Events.OnMinigameMistake -= OnMinigameMistake;
    }
    void _Character_Walk()
    {
        Character.Walk();
    }
    void _Character_Idle()
    {
        Character.Idle();
    }
    void _Character_Right()
    {
        Character.Right();
    }
    void _Character_Wrong()
    {
        Character.Wrong();
    }
    void _Character_CalculatorIn()
    {
        Character.CalculatorIn();
    }
    void _Character_CalculatorOut()
    {
        Character.CalculatorOut();
    }
    void _Character_CalculatorIdle()
    {
        Character.CalculatorIdle();
    }

    void _Npc_Walk()
    {
        Npc.Walk();
    }
    void _Npc_Idle()
    {
        Npc.Idle();
    }
    void _Npc_Right()
    {
        Npc.Right();
    }
    void _Npc_Wrong()
    {
        Npc.Wrong();
    }

    public void Init()
    {
        
        gameObject.SetActive(true);
        
        int activeIslandID = Game.Instance.islandsManager.activeIsland.id;
        animationID = Game.Instance.islandsManager.activeIsland.animationID;

        print("Init" + animationID);
        GetComponent<Animator>().Play("intro" + animationID, 0, 0);

        if (activeIslandID == lastIslandID) return;
        lastIslandID = activeIslandID;

        CustomizeCharacters();
        loaded = true;
        SetBackground(Game.Instance.islandsManager.activeIsland.BackgroundBitmapID);
    }
    void SetBackground(int id)
    {
        int num = 1;
        foreach (GameObject background in backgrounds)
        {
            if (background.name == "background_" + id)
                background.SetActive(true);
            else
                background.SetActive(false);
            num++;
        }
    }
    void OnCustomizerSave()
    {
        //resetea para cargar de nuevo
        lastIslandID = 0;
    }
    void CustomizeCharacters()
    {
        ClothesSettings clothesSettings = Data.Instance.clothesSettings;
        SavedSettings savedSettings = Data.Instance.savedSettings;

        characterManager.SetSex(savedSettings.GetSex());
        characterManager.SetCloth(clothesSettings.clothes, savedSettings.myPlayerSettings.clothes);
        characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.legs);
        characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
        characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hairs);
        characterManager.SetCloth(clothesSettings.skin, savedSettings.myPlayerSettings.skin);

        IslandsManager.NpcSettings npcSetings = Game.Instance.islandsManager.activeIsland.npsSettings;

        npcCharacterManager.SetSex(npcSetings.sex);
        npcCharacterManager.SetCloth(clothesSettings.clothes, npcSetings.clothes, true);
        npcCharacterManager.SetCloth(clothesSettings.legs, npcSetings.legs, true);
        npcCharacterManager.SetCloth(clothesSettings.shoes, npcSetings.shoes, true);
        npcCharacterManager.SetCloth(clothesSettings.hairs, npcSetings.hair, true);
        npcCharacterManager.SetCloth(clothesSettings.skin, npcSetings.skin, true);
    }
    void OnMinigameStart()
    {
        print("OnMinigameStart" + animationID);
        GetComponent<Animator>().Play("intro" + animationID, 0, 0);
	}
    void OnMinigameStartCalculator()
    {
        print("OnMinigameStartCalculator: " + "calculatorIn" + animationID);
        GetComponent<Animator>().Play("calculatorIn" + animationID, 0, 0);
    }
    void OnMinigameReady()
    {
        print("OnMinigameReady" + animationID);
        GetComponent<Animator>().Play("win" + animationID, 0, 0);
        print("PLAY: " + "win" + animationID);
    }
    void OnMinigameMistake()
    {
        print("OnMinigameMistake" + animationID);
        GetComponent<Animator>().Play("lose" + animationID, 0, 0);
        print("PLAY: " + "lose" + animationID);
    }
    public void SetOff()
    {
        gameObject.SetActive(false);
        loaded = false;
    }
}
