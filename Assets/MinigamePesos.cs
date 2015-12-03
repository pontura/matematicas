﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigamePesos : Minigame {

    public Text desc;
    public int peso;
    public int average;
    public ButtonAddRemove[] buttons;

    void OnEnable()
    {
        Texts.Minigame_Peso minigame = Data.Instance.texts.GetMinigame();
        string textFinal = minigame.title;
        string insertfield = "";

        int total = 0;

        foreach (int prom in minigame.promedios)
        {
            total += prom;
            insertfield += "\n" + prom.ToString() + "k";
        }
        average = total/minigame.promedios.Length;

        desc.text = textFinal.Replace("[]", insertfield + "\n");

        buttons[0].Init(this, minigame.peso1);
        buttons[1].Init(this, minigame.peso2);
        buttons[2].Init(this, minigame.peso3);
    }
    public void Add(int _peso)
    {
        this.peso += _peso;
        CheckResult();
    }
    public void Remove(int _peso)
    {
        this.peso -= _peso;
        CheckResult();
    }
    public void CheckResult()
    {
        if (average == peso)
            Events.OnMinigameReady();
    }
}
