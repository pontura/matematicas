using UnityEngine;
using System.Collections;
using System;

public class Texts :MonoBehaviour {

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
    }
    public Minigame_Peso[] minigame_Peso;



    public string GetRandomText(string[] arr)
    {
        return arr[ UnityEngine.Random.Range(0,arr.Length) ];
    }
    public Minigame_Peso GetMinigame()
    {
        return minigame_Peso[0];
    }


}
