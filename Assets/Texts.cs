using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class Texts :MonoBehaviour {

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
    public class Minigame_Peso
    {
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
    public List<Minigame_Peso> minigame_Peso;

    string json_Texts_Url = "texts";
    string json_Minigames_Url = "minigames";

    void Start()
    {
        TextAsset file = Resources.Load(json_Texts_Url) as TextAsset;
        LoadDataromServer(file.text);

        file = Resources.Load(json_Minigames_Url) as TextAsset;
        LoadDataMinigames(file.text);
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = JSON.Parse(json_data);

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
    public void LoadDataMinigames(string json_data)
    {
        var Json = JSON.Parse(json_data);

        for (int a = 0; a < Json["pesar"].Count; a++)
        {
            Minigame_Peso minigame = new Minigame_Peso();
            minigame.title = Json["pesar"][a]["title"];

            minigame.promedios = new List<int>();
            for (int b = 0; b < Json["pesar"][a]["promedios"].Count; b++)
                minigame.promedios.Add(int.Parse(Json["pesar"][a]["promedios"][b]));

            minigame.peso1 = int.Parse(Json["pesar"][a]["peso1"]);
            minigame.peso2 = int.Parse(Json["pesar"][a]["peso2"]);
            minigame.peso3 = int.Parse(Json["pesar"][a]["peso3"]);
            switch(Json["pesar"][a]["type"])
            {
                case "PROMEDIO": minigame.type = Minigame_Peso.Minigame_Peso_type.PROMEDIO; break;
                case "SUMATORIA": minigame.type = Minigame_Peso.Minigame_Peso_type.SUMATORIA; break;
            }
            
            minigame_Peso.Add(minigame);
        }
    }
    private void fillArray(List<string> arr, JSONNode content)
    {
        for (int a = 0; a < content.Count; a++)
            arr.Add(content[a]["text"]);
    }



    public string GetRandomText(List<string> arr)
    {
        return arr[ UnityEngine.Random.Range(0,arr.Count) ];
    }
    public Minigame_Peso GetMinigame()
    {
        return minigame_Peso[ UnityEngine.Random.Range(0, minigame_Peso.Count) ];
       // return minigame_Peso[1];
    }


}
