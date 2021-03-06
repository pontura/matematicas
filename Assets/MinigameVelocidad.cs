﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MinigameVelocidad : Minigame
{

    public int result = 0;
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    public InputField inputField4;
    public InputField inputField5;

    public List<int> numbers;

    public MathDevice mathDevice;

    private float _separationY = 0.16f;

    void Start()
    {
        
    }
    void OnEnable()
    {
        Events.OnMinigameStartCalculator();
        inputField1.text = "";
        inputField2.text = "";
        inputField3.text = "";
        inputField4.text = "";
        inputField5.text = "";
    }
    public void Init()
    {
        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
        mathDevice.Appear();

        Texts.Minigame_SimpleInput minigame = Data.Instance.texts.GetMinigame_SimpleInput();
        string textFinal = minigame.title;
        string insertfield = "";

        if (minigame.type == Texts.Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA)
        {
            textFinal = GenerateRandomResults(textFinal);
            result = numbers[0] - numbers[1];
        }
        else if (minigame.type == Texts.Minigame_SimpleInput.Minigame_SimpleInput_type.MULTIPLICA)
        {
            textFinal = GenerateRandomResults(textFinal);
            result = numbers[0] * numbers[1];
        }
        else if (minigame.type == Texts.Minigame_SimpleInput.Minigame_SimpleInput_type.HARDCODE)
        {
           // textFinal = GenerateRandomResults(textFinal);
            result = minigame.result;
        }  

        desc.text = textFinal.Replace("[]", insertfield);

    }
    string GenerateRandomResults(string _field)
    {
        string FieldToResturn = "";

        string[] textSplit = _field.Split("["[0]);

        numbers.Clear();
        foreach (string field in textSplit)
        {            
            string[] textSplit2 = field.Split("]"[0]);
            foreach (string field2 in textSplit2)
            {
               
                string[] textSplitRand = field2.Split("/"[0]);
                if (textSplitRand.Length > 1)
                {
                    int num1 = int.Parse(textSplitRand[0]);
                    int num2 = int.Parse(textSplitRand[1]);
                    int rand = Random.Range(num1, num2);
                    FieldToResturn += rand.ToString();
                    numbers.Add( rand );
                }
                else
                {
                    FieldToResturn += field2;
                }
            }
        }

        return FieldToResturn;
    }
    override public void Reset()
    {
        print("RESET");
        result = 0;
    }
    private int GetPromNumber()
    {
        return ((Random.Range(0, 99) * 2)*10)+500;
    }
    
    public void CheckResult()
    {
        if (result.ToString() == inputField1.text)
        {
            Invoke("MinigameReady", 0.7f);
            mathDevice.Disappear();
        }
        else
            Events.OnMinigameMistake();
    }
    void MinigameReady()
    {
        Events.OnMinigameReady();
    }
}
