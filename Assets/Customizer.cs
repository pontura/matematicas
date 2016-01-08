using UnityEngine;
using System.Collections;

public class Customizer : MonoBehaviour {

    public CharacterManager characterManager;
    private ClothesSettings clothesSettings;
    private SavedSettings savedSettings;

	void Start () {
        Events.OnCustomizerButtonPrevClicked += OnCustomizerButtonPrevClicked;
        Events.OnCustomizerButtonNextClicked += OnCustomizerButtonNextClicked;
        
        clothesSettings = Data.Instance.clothesSettings;
        savedSettings = Data.Instance.savedSettings;

        Invoke("Delay", 0.5f);

	}
    void Delay()
    {
        savedSettings.CreateRandomPlayer();

        characterManager.SetCloth(clothesSettings.clothes, savedSettings.myPlayerSettings.clothes);
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
        print("Clicked: " + id + " - next: " + next);
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
    public void Ready()
    {
        Data.Instance.LoadLevel("NameRequest");
    }
    public void Back()
    {
        Data.Instance.LoadLevel("Disciplinas");
    }
}
