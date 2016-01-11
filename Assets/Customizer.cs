using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customizer : MonoBehaviour {

    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;
    public Text SexField; 

	void Start () {

        Events.OnCustomizerButtonPrevClicked += OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked += OnCustomizerButtonNextClicked;
        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        Invoke("Delay", 0.5f);

        SetSexButton();
	}
   public void ToggleSex()
    {
       savedSettings.ToggleSex();
       SetSexButton();
    }
   void SetSexButton()
   {
       if (savedSettings.GetSex() == SavedSettings.PlayerSettings.sexType.MUJER)
           SexField.text = "MUJER";
       else
           SexField.text = "VARON";
   }
    void Delay()
    {
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
    }
    public void Ready()
    {
        Data.Instance.LoadLevel("NameRequest");
    }
    public void Back()
    {
        Data.Instance.LoadLevel("Disciplinas");
    }
}
