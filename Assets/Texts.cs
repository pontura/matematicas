using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Texts :MonoBehaviour {

    public List<string> tutorial;
    public List<string> elementos;
    public List<string> Bienvenida;
    public List<string> MisionNoTienesNada;
    public List<string> MisionTienesAlgo;
    public List<string> MisionNosFalta;
    public List<string> MisionCompleta;
    public List<string> MisionTienesTodoLoQueFalta;

    public List<string> MinigameReady;
    public List<string> MinigameInvita;
    public List<string> RecogeLoQueGustes;

    [Serializable]
    public class Minigame_SimpleInput
    {
        public int islandID;
        public string title;
        public Minigame_SimpleInput_type type;
        public enum Minigame_SimpleInput_type
        {
            RESTA,
            MULTIPLICA
        }
    }

    [Serializable]
    public class Minigame_Peso
    {
        public int islandID;
        public string title;
        public List<int> promedios;
        public int peso1;
        public int peso2;
        public int peso3;
        public Minigame_Peso_type type;
        public enum Minigame_Peso_type
        {
            PROMEDIO,
            SUMATORIA
        }
    }

    [Serializable]
    public class Minigame_Fracciones
    {
        public int islandID;
        public string title;
        public List<string> fracciones;
        public int slots;
      //  public Minigame_Peso_type type;
        //public enum Minigame_Peso_type
        //{
        //    PROMEDIO,
        //    SUMATORIA
        //}
    }

    public List<Minigame_Peso> minigame_Peso;
    public List<Minigame_SimpleInput> minigame_SimpleInput;
    public List<Minigame_Fracciones> minigame_Fracciones;

    string json_Texts_Url = "texts";
    string json_Minigames_pesar_Url = "minigames_pesar";
    string json_Minigames_fracciones_Url = "minigames_fracciones";
    string json_Minigames_simpleInput_Url = "minigames_simpleInput";

    void Start()
    {
        Encoding utf8 = Encoding.UTF8;

        TextAsset file = Resources.Load(json_Texts_Url) as TextAsset;
        LoadDataromServer(file.text);

        file = Resources.Load(json_Minigames_pesar_Url) as TextAsset;
        LoadDataMinigames(file.text, "pesar");

        file = Resources.Load(json_Minigames_fracciones_Url) as TextAsset;
        LoadDataMinigames(file.text, "fracciones");

        file = Resources.Load(json_Minigames_simpleInput_Url) as TextAsset;
        LoadDataMinigames(file.text, "simpleInput");
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = JSON.Parse(json_data);

        fillArray(tutorial, Json["tutorial"]);
        fillArray(elementos, Json["elementos"]);
        fillArray(Bienvenida, Json["bienvenida"]);
        fillArray(MisionNoTienesNada, Json["MisionNoTienesNada"]);
        fillArray(MisionTienesAlgo, Json["MisionTienesAlgo"]);
        fillArray(MisionNosFalta, Json["MisionNosFalta"]);
        fillArray(MisionCompleta, Json["MisionCompleta"]);
        fillArray(MisionTienesTodoLoQueFalta, Json["MisionTienesTodoLoQueFalta"]);
        fillArray(MinigameReady, Json["MinigameReady"]);
        fillArray(MinigameInvita, Json["MinigameInvita"]);
        fillArray(RecogeLoQueGustes, Json["RecogeLoQueGustes"]);
    }
    public void LoadDataMinigames(string json_data, string minigameName)
    {
        var Json = JSON.Parse(json_data);

        string gameName = minigameName;

        switch(minigameName)
        {
            case "pesar":
                for (int a = 0; a < Json[minigameName].Count; a++)
                {
                    Minigame_Peso minigame = new Minigame_Peso();
                    minigame.title = Json[minigameName][a]["title"];

                    minigame.promedios = new List<int>();
                    for (int b = 0; b < Json[minigameName][a]["promedios"].Count; b++)
                        minigame.promedios.Add(int.Parse(Json[minigameName][a]["promedios"][b]));

                    minigame.peso1 = int.Parse(Json[minigameName][a]["peso1"]);
                    minigame.peso2 = int.Parse(Json[minigameName][a]["peso2"]);
                    minigame.peso3 = int.Parse(Json[minigameName][a]["peso3"]);
                    switch(Json[minigameName][a]["type"])
                    {
                        case "PROMEDIO": minigame.type = Minigame_Peso.Minigame_Peso_type.PROMEDIO; break;
                        case "SUMATORIA": minigame.type = Minigame_Peso.Minigame_Peso_type.SUMATORIA; break;
                    }
                    minigame_Peso.Add(minigame);
                }
                break;



            case "simpleInput":
                /////////////////Simple
        
                for (int a = 0; a < Json[gameName].Count; a++)
                {
                    Minigame_SimpleInput minigame = new Minigame_SimpleInput();
                    minigame.title = Json[gameName][a]["title"];
                    minigame.islandID = int.Parse(Json[gameName][a]["islandId"]);

                    switch (Json[gameName][a]["type"])
                    {
                        case "RESTA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA; break;
                        case "MULTIPLICA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.MULTIPLICA; break;
                    }

                    minigame_SimpleInput.Add(minigame);
                }
                break;




            case "fracciones":
                /////////////////fracciones
                for (int a = 0; a < Json[gameName].Count; a++)
                {
                    Minigame_Fracciones minigame = new Minigame_Fracciones();
                    minigame.title = Json[gameName][a]["title"];
                    minigame.slots = int.Parse( Json[gameName][a]["slots"] );
                    minigame.fracciones = new List<string>();
                    for (int b = 0; b < Json[gameName][a]["fracciones"].Count; b++)
                        minigame.fracciones.Add(Json[gameName][a]["fracciones"][b]);

                    //switch (Json[gameName][a]["type"])
                    //{
                    //    case "RESTA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA; break;
                    //}

                    minigame_Fracciones.Add(minigame);
                }
                break;



        }
    }
    private void fillArray(List<string> arr, JSONNode content)
    {
        for (int a = 0; a < content.Count; a++)
        {
            string text = content[a]["text"];
            text = ReplaceUserName(text);
            arr.Add(text);
        }
    }
    public string ReplaceUserName(string field)
    {
        if (Data.Instance.userData.username != "")
            return field.Replace("[username]", Data.Instance.userData.username);
        else return field;
    }
    public string GetFilteredText(List<string> arr, int id)
    {
        return ReplaceUserName(arr[id]);
    }
    public string GetRandomText(List<string> arr)
    {
        return arr[ UnityEngine.Random.Range(0,arr.Count) ];
    }
    public Minigame_Peso GetMinigame_Peso()
    {
        return minigame_Peso[ UnityEngine.Random.Range(0, minigame_Peso.Count) ];
       // return minigame_Peso[1];
    }
    public Minigame_SimpleInput GetMinigame_SimpleInput()
    {
        Minigame_SimpleInput minigame = null;
        int progress_num = 0;
        foreach (Minigame_SimpleInput m in minigame_SimpleInput)
        {
            if (progress_num <= Game.Instance.islandsManager.activeIsland.progress &&  m.islandID == Game.Instance.islandsManager.activeIsland.id)
            {
                minigame = m;
                progress_num++;
            }
        }
        return minigame;
        // return minigame_Peso[1];
    }
    public Minigame_Fracciones GetMinigame_Fracciones()
    {
        return minigame_Fracciones[UnityEngine.Random.Range(0, minigame_Fracciones.Count)];
        // return minigame_Peso[1];
    }


}
