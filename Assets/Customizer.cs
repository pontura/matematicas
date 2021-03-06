﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customizer : MonoBehaviour {

    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;
    public Image sex_varon;
    public Image sex_mujer;

    public Color button_on;
    public Color button_off;

    public Text usernameField; 

	void Start () {

        Events.OnCustomizerButtonPrevClicked += OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked += OnCustomizerButtonNextClicked;
        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        Invoke("Delay", 0.5f);

        SetSexButton();

        usernameField.text = Data.Instance.userData.username;
	}
   public void ToggleSex()
    {
       savedSettings.ToggleSex();
       SetSexButton();
       Delay();
    }
   void SetSexButton()
   {
       if (savedSettings.GetSex() == SavedSettings.PlayerSettings.sexType.MUJER)
       {
           sex_varon.color = button_off;
           sex_mujer.color = button_on;
       }
       else
       {
           sex_varon.color = button_on;
           sex_mujer.color = button_off;
       }
   }
    void Delay()
    {
       characterManager.SetSex(savedSettings.GetSex());
       characterManager.SetCloth(clothesSettings.clothes, savedSettings.myPlayerSettings.clothes);
       characterManager.SetCloth(clothesSettings.legs, savedSettings.myPlayerSettings.legs);
       characterManager.SetCloth(clothesSettings.shoes, savedSettings.myPlayerSettings.shoes);
       characterManager.SetCloth(clothesSettings.hairs, savedSettings.myPlayerSettings.hairs);
       characterManager.SetCloth(clothesSettings.skin, savedSettings.myPlayerSettings.skin);
    }
    void OnDestroy()
    {
        Events.OnCustomizerButtonPrevClicked -= OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked -= OnCustomizerButtonNextClicked;
    }
    void OnCustomizerButtonNextClicked(int id)
    {
        Clicked(id, true);
    }
    void OnCustomizerButtonPrevClicked(int id)
    {
        Clicked(id, false);
    }
    void Clicked(int id, bool next)
    {
        switch (id)
        {
            case 1:
                characterManager.ChangeClothes(next);
                break;
            case 2:
                characterManager.ChangeLegs(next);
                break;
            case 3:
                characterManager.ChangeShoes(next);
                break;
            case 4:
                characterManager.ChangeSkin(next);
                break;
            case 5:
                characterManager.ChangeHair(next);
                break;
        }
        Resources.UnloadUnusedAssets();
    }
    public void Ok()
    {
        Events.OnCustomizerSave();
        gameObject.SetActive(false);
        Events.OnCustomizerActive(false);
        Game.Instance.mainMenu.Mapa();
    }
}
