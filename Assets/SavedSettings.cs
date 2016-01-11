using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SavedSettings : MonoBehaviour {
    
    [Serializable]
    public class PlayerSettings
    {
        public enum sexType
        {
            VARON,
            MUJER
        }
        public sexType sex;
        public int clothes;
        public int legs;
        public int shoes;
        public int skin;
        public int hairs;
    }    
    public PlayerSettings myPlayerSettings;
    private ClothesSettings clothSettings;

    public void ToggleSex()
    {
        if (myPlayerSettings.sex == PlayerSettings.sexType.VARON)
            myPlayerSettings.sex = PlayerSettings.sexType.MUJER;
        else myPlayerSettings.sex = PlayerSettings.sexType.VARON;
    }
    public PlayerSettings.sexType GetSex()
    {
        return myPlayerSettings.sex;
    }

	void Start () {

        Events.OnCustomizerSave += OnCustomizerSave;

        clothSettings = Data.Instance.clothesSettings;
        myPlayerSettings = new PlayerSettings();

        int sex = PlayerPrefs.GetInt("sex", 0);
        if (sex == 0)
            myPlayerSettings.sex = PlayerSettings.sexType.VARON;
        else myPlayerSettings.sex = PlayerSettings.sexType.MUJER;

        myPlayerSettings.clothes = PlayerPrefs.GetInt("clothes", 0);
        myPlayerSettings.legs = PlayerPrefs.GetInt("legs", 0);
        myPlayerSettings.shoes = PlayerPrefs.GetInt("shoes", 0);
        myPlayerSettings.skin = PlayerPrefs.GetInt("skin", 0);
        myPlayerSettings.hairs = PlayerPrefs.GetInt("hairs", 0);

	}
    void OnDestroy()
    {
        Events.OnCustomizerSave -= OnCustomizerSave;
    }
    public void CreateRandomPlayer()
    {
        myPlayerSettings.clothes = GetRandom(clothSettings.clothes);
    }
    private int GetRandom(List<string> list)
    {
        return UnityEngine.Random.Range(0, list.Count - 1);
    }
    void OnCustomizerSave()
    {
        int sex = 0;
        if (myPlayerSettings.sex == PlayerSettings.sexType.MUJER) sex = 1;
        PlayerPrefs.SetInt("sex", sex);
        PlayerPrefs.SetInt("clothes", myPlayerSettings.clothes);
        PlayerPrefs.SetInt("legs", myPlayerSettings.legs);
        PlayerPrefs.SetInt("shoes", myPlayerSettings.shoes);
        PlayerPrefs.SetInt("skin", myPlayerSettings.skin);
        PlayerPrefs.SetInt("hairs", myPlayerSettings.hairs);
    }
}
