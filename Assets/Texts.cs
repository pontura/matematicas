using UnityEngine;
using System.Collections;
using System;

public class Texts :MonoBehaviour {

    public string[] Bienvenida;
    public string[] MisionNoTienesNada;
    public string[] MisionTienesAlgo;
    public string[] MisionNosFalta;
    public string[] MisionCompleta;
    public string[] MisionTienesTodoLoQueFalta;

    public string[] MinigameReady;
    public string[] MinigameInvita;
    public string[] RecogeLoQueGustes;

    
    [Serializable]
    public class Minigame_Peso
    {
        public string title;
        public int[] promedios;
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
    public Minigame_Peso[] minigame_Peso;



    public string GetRandomText(string[] arr)
    {
        return arr[ UnityEngine.Random.Range(0,arr.Length) ];
    }
    public Minigame_Peso GetMinigame()
    {
        return minigame_Peso[ UnityEngine.Random.Range(0, minigame_Peso.Length) ];
       // return minigame_Peso[1];
    }


}
