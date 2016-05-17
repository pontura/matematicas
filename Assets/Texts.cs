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
    public List<string> Bienvenida_x_isla;
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
        public int result;
        public bool loop;
        public enum Minigame_SimpleInput_type
        {
            RESTA,
            MULTIPLICA,
            HARDCODE
        }
    }

    [Serializable]
    public class Minigame_Peso
    {
        public int islandID;
        public string title;
        public List<int> promedios;
        public float peso1;
        public float peso2;
        public float peso3;
        public bool loop;
        public float result;
        public Minigame_Peso_type type;
        public enum Minigame_Peso_type
        {
            PROMEDIO,
            SUMATORIA,
            HARDCODE
        }
    }

    [Serializable]
    public class Minigame_Fracciones
    {
        public int islandID;
        public string title;
        public List<int> fracciones;
        public Vector2 recta;
        public int slots;
        public bool loop;
      //  public Minigame_Peso_type type;
        //public enum Minigame_Peso_type
        //{
        //    PROMEDIO,
        //    SUMATORIA
        //}
    }

    [Serializable]
    public class Minigame_Velocidad
    {
        public int islandID;
        public string title;
        public List<Ejercicio> ejercicios;
        public int time;
        public bool loop;
        [Serializable]
        public class Ejercicio
        {
            public string ejercicio;
            public int resultado;
            public bool show;
        }
    }

    public List<Minigame_Peso> minigame_Peso;
    public List<Minigame_SimpleInput> minigame_SimpleInput;
    public List<Minigame_Fracciones> minigame_Fracciones;
    public List<Minigame_Velocidad> minigame_Velocidad;

    string json_Texts_Url = "texts";
    string json_Minigames_pesar_Url = "minigames_pesar";
    string json_Minigames_fracciones_Url = "minigames_fracciones";
    string json_Minigames_simpleInput_Url = "minigames_simpleInput";
    string json_Minigames_velocidad_Url = "minigames_velocidad";

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

        file = Resources.Load(json_Minigames_velocidad_Url) as TextAsset;
        LoadDataMinigames(file.text, "velocidad");
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = SimpleJSON.JSON.Parse(json_data);

        fillArray(tutorial, Json["tutorial"]);
        fillArray(elementos, Json["elementos"]);
        fillArray(Bienvenida, Json["bienvenida"]);
        fillArray(Bienvenida_x_isla, Json["bienvenida_x_isla"]);        
        fillArray(MisionNoTienesNada, Json["MisionNoTienesNada"]);
        fillArray(MisionTienesAlgo, Json["MisionTienesAlgo"]);
        fillArray(MisionNosFalta, Json["MisionNosFalta"]);
        fillArray(MisionCompleta, Json["MisionCompleta"]);
        fillArray(MisionTienesTodoLoQueFalta, Json["MisionTienesTodoLoQueFalta"]);
        fillArray(MinigameReady, Json["MinigameReady"]);
        fillArray(MinigameInvita, Json["MinigameInvita"]);
        fillArray(RecogeLoQueGustes, Json["RecogeLoQueGustes"]);
    }
    public string GetBienvenidaXIsland(int islandID)
    {
        return Bienvenida_x_isla[islandID-1];
    }
    public void LoadDataMinigames(string json_data, string minigameName)
    {
        var Json = SimpleJSON.JSON.Parse(json_data);

        string gameName = minigameName;

        switch(minigameName)
        {
            case "pesar":
                for (int a = 0; a < Json[minigameName].Count; a++)
                {
                    Minigame_Peso minigame = new Minigame_Peso();
                    minigame.title = Json[minigameName][a]["title"];
                    minigame.loop = Json[gameName][a]["loop"].AsBool;
                    minigame.islandID = int.Parse(Json[gameName][a]["islandId"]);
                    

                    minigame.peso1 = float.Parse(Json[minigameName][a]["peso1"]);
                    minigame.peso2 = float.Parse(Json[minigameName][a]["peso2"]);
                    minigame.peso3 = float.Parse(Json[minigameName][a]["peso3"]);
                    switch(Json[minigameName][a]["type"])
                    {
                        case "PROMEDIO": 
                            minigame.type = Minigame_Peso.Minigame_Peso_type.PROMEDIO;                             
                            minigame.promedios = new List<int>();
                            for (int b = 0; b < Json[minigameName][a]["promedios"].Count; b++)
                                minigame.promedios.Add(int.Parse(Json[minigameName][a]["promedios"][b]));
                        break;
                        case "SUMATORIA": minigame.type = Minigame_Peso.Minigame_Peso_type.SUMATORIA; break;
                        case "HARDCODE": 
                            minigame.type = Minigame_Peso.Minigame_Peso_type.HARDCODE;
                            minigame.result = float.Parse(Json[minigameName][a]["result"]);
                            break;
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

                    minigame.loop = Json[gameName][a]["loop"].AsBool;
                   

                    switch (Json[gameName][a]["type"])
                    {
                        case "RESTA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA; break;
                        case "MULTIPLICA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.MULTIPLICA; break;
                        case "HARDCODE": 
                             minigame.result = int.Parse(Json[gameName][a]["result"]);
                             minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.HARDCODE; 
                             break;
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
                    minigame.islandID = int.Parse(Json[gameName][a]["islandId"]);
                    minigame.loop = Json[gameName][a]["loop"].AsBool;
                    minigame.slots = int.Parse( Json[gameName][a]["slots"] );
                    minigame.recta = new Vector2(int.Parse(Json[gameName][a]["recta"][0]), int.Parse(Json[gameName][a]["recta"][1]));
                    minigame.fracciones = new List<int>();
                    for (int b = 0; b < Json[gameName][a]["fracciones"].Count; b++)
                        minigame.fracciones.Add(int.Parse(Json[gameName][a]["fracciones"][b]));

                    //switch (Json[gameName][a]["type"])
                    //{
                    //    case "RESTA": minigame.type = Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA; break;
                    //}

                    minigame_Fracciones.Add(minigame);
                }
                break;





            case "velocidad":
                /////////////////velocidad
                print("velocidad");
                for (int a = 0; a < Json[gameName].Count; a++)
                {
                    Minigame_Velocidad minigame = new Minigame_Velocidad();
                    minigame.title = Json[gameName][a]["title"];
                    minigame.islandID = int.Parse(Json[gameName][a]["islandId"]);
                    minigame.loop = Json[gameName][a]["loop"].AsBool;
                    minigame.time = int.Parse(Json[gameName][a]["time"]);
                    minigame.ejercicios = new List<Minigame_Velocidad.Ejercicio>();
                    for (int b = 0; b < Json[gameName][a]["ejercicios"].Count; b++)
                    {
                        Minigame_Velocidad.Ejercicio ejercicio = new Minigame_Velocidad.Ejercicio();
                        ejercicio.ejercicio = Json[gameName][a]["ejercicios"][b]["ejercicio"];
                        ejercicio.resultado = int.Parse(Json[gameName][a]["ejercicios"][b]["resultado"]);
                        ejercicio.show = Json[gameName][a]["ejercicios"][b]["show"].AsBool;
                        minigame.ejercicios.Add(ejercicio);
                    }
                    minigame_Velocidad.Add(minigame);
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
        Minigame_Peso minigame = null;
        int progress_num = 0;
        foreach (Minigame_Peso m in minigame_Peso)
        {
            if (progress_num <= Game.Instance.islandsManager.activeIsland.progress && m.islandID == Game.Instance.islandsManager.activeIsland.id)
            {
                minigame = m;
                progress_num++;
            }
        }
        ////////////si ya llegaste al fin:
        if (Game.Instance.islandsManager.activeIsland.progress >= progress_num)
        {
            print("LEVANTA MINIGAME RANDOM: loop = true. progress: " + Game.Instance.islandsManager.activeIsland.progress + "  activeisland: " + Game.Instance.islandsManager.activeIsland.id + " progress_num: " + progress_num);
            List<Minigame_Peso> newList = new List<Minigame_Peso>();
            foreach (Minigame_Peso m in minigame_Peso)
            {
                if (m.loop)
                    newList.Add(m);
            }
            return newList[UnityEngine.Random.Range(0, newList.Count)];
        }
        else
            //////////////////////
            return minigame;
       // return minigame_Peso[1];
    }
    public Minigame_SimpleInput GetMinigame_SimpleInput()
    {
        Minigame_SimpleInput minigame = null;
        int progress_num = 0;
        foreach (Minigame_SimpleInput m in minigame_SimpleInput)
        {
            if (progress_num <= Game.Instance.islandsManager.activeIsland.progress && m.islandID == Game.Instance.islandsManager.activeIsland.id)
            {
                minigame = m;
                progress_num++;
            }
        }
        ////////////si ya llegaste al fin:
        if (Game.Instance.islandsManager.activeIsland.progress >= progress_num)
        {
            List<Minigame_SimpleInput> newList = new List<Minigame_SimpleInput>();
            foreach (Minigame_SimpleInput m in minigame_SimpleInput)
            {
                if (m.loop)
                    newList.Add(m);
            }
            return newList[UnityEngine.Random.Range(0, newList.Count)];
        } else
        //////////////////////
        return minigame;
    }
    public Minigame_Fracciones GetMinigame_Fracciones()
    {
        Minigame_Fracciones minigame = null;
        int progress_num = 0;
        foreach (Minigame_Fracciones m in minigame_Fracciones)
        {
            if (progress_num <= Game.Instance.islandsManager.activeIsland.progress && m.islandID == Game.Instance.islandsManager.activeIsland.id)
            {
                minigame = m;
                progress_num++;
            }
        }
        ////////////si ya llegaste al fin:
        if (Game.Instance.islandsManager.activeIsland.progress >= progress_num)
        {
            List<Minigame_Fracciones> newList = new List<Minigame_Fracciones>();
            foreach (Minigame_Fracciones m in minigame_Fracciones)
            {
                if (m.loop)
                    newList.Add(m);
            }
            return newList[UnityEngine.Random.Range(0, newList.Count)];
        }
        else
            //////////////////////
            return minigame;
    }
    public Minigame_Velocidad GetMinigame_Velocidad()
    {
        Minigame_Velocidad minigame = null;
        int progress_num = 0;
        foreach (Minigame_Velocidad m in minigame_Velocidad)
        {
            if (progress_num <= Game.Instance.islandsManager.activeIsland.progress && m.islandID == Game.Instance.islandsManager.activeIsland.id)
            {
                minigame = m;
                progress_num++;
            }
        }
        ////////////si ya llegaste al fin:
        if (Game.Instance.islandsManager.activeIsland.progress >= progress_num)
        {
            List<Minigame_Velocidad> newList = new List<Minigame_Velocidad>();
            foreach (Minigame_Velocidad m in minigame_Velocidad)
            {
                if (m.loop)
                    newList.Add(m);
            }
            return newList[UnityEngine.Random.Range(0, newList.Count)];
        }
        else
            //////////////////////
            return minigame;
    }


}
