﻿using UnityEngine;
using System.Collections;

public class MiningameBackground : MonoBehaviour {

    public CharacterManager characterManagerModel;
    public CharacterManager characterManager;
    public CharacterManager npcCharacterManager;
    public GameObject container_character;
    public GameObject container_npc;
    private int lastIslandID;

    private bool loaded;

	void Start () {
        Events.OnMinigameStart += OnMinigameStart;
        Events.OnMinigameReady += OnMinigameReady;
        Events.OnMinigameMistake += OnMinigameMistake;
        Events.OnCustomizerSave += OnCustomizerSave;
	}

    void OnDestroy()
    {
        Events.OnCustomizerSave -= OnCustomizerSave;
        Events.OnMinigameStart -= OnMinigameStart;
        Events.OnMinigameReady -= OnMinigameReady;
        Events.OnMinigameMistake -= OnMinigameMistake;
    }
    public void Init()
    {
        gameObject.SetActive(true);
        
        int activeIslandID = Game.Instance.islandsManager.activeIsland.id;

        print("activeIslandID: " + activeIslandID + " lasta: " + lastIslandID);

        if (activeIslandID == lastIslandID) return;
        lastIslandID = activeIslandID;

        if (characterManager != null)
        {
            GameObject.Destroy(characterManager.gameObject);
            characterManager = null;
        }
        if (npcCharacterManager != null)
        {
            GameObject.Destroy(npcCharacterManager.gameObject);
            npcCharacterManager = null;
        }
        CustomizeCharacters();
        loaded = true;

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

        characterManager = Instantiate(characterManagerModel);
        characterManager.transform.SetParent(container_character.transform);
        characterManager.transform.localScale = Vector3.one;
        characterManager.transform.localPosition = Vector3.zero;

        characterManager.SetSex(savedSettings.GetSex());
        characterManager.SetCloth(clothesSettings.clothes, savedSettings.myPlayerSettings.clothes);
        characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.legs);
        characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
        characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hairs);
        characterManager.SetCloth(clothesSettings.skin, savedSettings.myPlayerSettings.skin);


        npcCharacterManager = Instantiate(characterManagerModel);
        npcCharacterManager.transform.SetParent(container_npc.transform);
        npcCharacterManager.transform.localScale = Vector3.one;
        npcCharacterManager.transform.localPosition = Vector3.zero;

        IslandsManager.NpcSettings npcSetings = Game.Instance.islandsManager.activeIsland.npsSettings;

        npcCharacterManager.SetSex(npcSetings.sex);
        npcCharacterManager.SetCloth(clothesSettings.clothes, npcSetings.clothes, true);
        npcCharacterManager.SetCloth(clothesSettings.legs, npcSetings.legs, true);
        npcCharacterManager.SetCloth(clothesSettings.shoes, npcSetings.shoes, true);
        npcCharacterManager.SetCloth(clothesSettings.hairs, npcSetings.shoes, true);
        //npcCharacterManager.SetCloth(clothesSettings.skin, 0, true);
    }
    void OnMinigameStart()
    {
        GetComponent<Animator>().Play("minigameA_idle", 0, 0);        
	}
    void OnMinigameReady()
    {
        GetComponent<Animator>().Play("minigameA_win", 0, 0);
    }
    void OnMinigameMistake()
    {
        GetComponent<Animator>().Play("minigameA_lose", 0, 0);
    }
    public void SetOff()
    {
        gameObject.SetActive(false);
        loaded = false;
    }
}
