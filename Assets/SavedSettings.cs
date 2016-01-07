using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SavedSettings : MonoBehaviour {
    
    [Serializable]
    public class PlayerSettings
    {
        public string username;
        public int clothes;
        public int legs;
        public int shoes;
        public int skin;
    }    
    public PlayerSettings myPlayerSettings;
    public int totalPlayersInThisDisciplina;

    public List<PlayerSettings>savedPlayers;
    private ClothesSettings clothSettings;

	void Start () {
        clothSettings = Data.Instance.clothesSettings;
        LoadSavedPlayers();
        myPlayerSettings = new PlayerSettings();
        int disciplinaID = 0;  
	}
    public void AddPlayerCloth(string part, int clothID)
    {
        print("part " + part + " clothID " + clothID);
        switch (part)
        {
            case "clothes": myPlayerSettings.clothes = clothID; break;
            case "legs": myPlayerSettings.legs = clothID; break;
        }
    }
    public void CreateRandomPlayer()
    {
       // myPlayerSettings.color = UnityEngine.Random.Range(0, 4);
        print(myPlayerSettings);
        print(clothSettings);
        myPlayerSettings.clothes = GetRandom(clothSettings.clothes);
    }
    private int GetRandom(List<string> list)
    {
        return UnityEngine.Random.Range(0, list.Count - 1);
    }
    public void AddPlayer()
    {
        if (totalPlayersInThisDisciplina > 10)
        {
            savedPlayers.RemoveAt(0);
        }        
        PlayerSettings playerSettings = new PlayerSettings();
        playerSettings = myPlayerSettings;
        savedPlayers.Add(playerSettings);
        SavePlayers(0);
        
    }
    void SavePlayers(int disciplinaId)
    {
        //int id = 1;
        //foreach (PlayerSettings playerSettings in savedPlayers)
        //{
        //    PlayerPrefs.SetString("d_" + disciplinaId + "_p" + id,
        //    playerSettings.username + "_" +
        //    playerSettings.color + "_" +
        //    playerSettings.hair + "_" +
        //    playerSettings.face + "_" +
        //    playerSettings.body + "_" +
        //    playerSettings.bottom + "_" +
        //    playerSettings.shoes + "_" + 
        //    playerSettings.glasses
        //    );
        //    id++;
        //    if (id > 10) return;
        //}
    }
    public void LoadSavedPlayers()
    {
        savedPlayers.Clear();
        totalPlayersInThisDisciplina = 1;
        int disciplinaID = 0;
        string playerData;
        for (int a = 1; a < 11; a++)
        {
            playerData = PlayerPrefs.GetString("d_" + disciplinaID + "_p" + a);
            if (playerData.Length > 1)
            {
                String[] textSplit = playerData.Split("_"[0]);

                PlayerSettings playerSettings = new PlayerSettings();

                //playerSettings.username = textSplit[0];
                //playerSettings.color = int.Parse(textSplit[1]);
                //playerSettings.hair = int.Parse(textSplit[2]);
                //playerSettings.face = int.Parse(textSplit[3]);
                //playerSettings.body = int.Parse(textSplit[4]);
                //playerSettings.bottom = int.Parse(textSplit[5]);
                //playerSettings.shoes = int.Parse(textSplit[6]);
                //playerSettings.glasses = int.Parse(textSplit[7]);

                savedPlayers.Add(playerSettings);
                totalPlayersInThisDisciplina++;
            }
        }
    }
    public PlayerSettings GetClothes(int disciplinaID, int id)
    {
        PlayerSettings playerSettings = null;

        string playerData;
        playerData = PlayerPrefs.GetString("d_" + disciplinaID + "_p" + id);
        if (playerData.Length > 1)
        {
            String[] textSplit = playerData.Split("_"[0]);

            playerSettings = new PlayerSettings();

            //playerSettings.username = textSplit[0];
            //playerSettings.color = int.Parse(textSplit[1]);
            //playerSettings.hair = int.Parse(textSplit[2]);
            //playerSettings.face = int.Parse(textSplit[3]);
            //playerSettings.body = int.Parse(textSplit[4]);
            //playerSettings.bottom = int.Parse(textSplit[5]);
            //playerSettings.shoes = int.Parse(textSplit[6]);
            //playerSettings.glasses = int.Parse(textSplit[7]);
        }

        return playerSettings;
    }
}
