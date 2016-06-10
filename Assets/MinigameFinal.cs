using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MinigameFinal : Minigame {

    public int result = 0;
    public InputField inputField;
    public List<int> numbers;

    public MathDevice mathDevice;

    private float _separationY = 0.16f;

    void Start()
    {
        
    }
    void OnEnable()
    {
        Events.OnMinigameStartCalculator();
        inputField.text = "";
    }
    public void Init()
    {
        descSmall.text = "";
        desc.text = "";
        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
       // mathDevice.Disappear();

       // Texts.Minigame_SimpleInput minigame = Data.Instance.texts.GetMinigame_SimpleInput();
        string textFinal = "Llegaste a la isla final";

        desc.text = textFinal.Replace("[]", textFinal);

    }
    
    override public void Reset()
    {
        print("RESET");
        result = 0;
    }
    public void CheckResult()
    {
    
    }
    void MinigameReady()
    {
        Events.OnMinigameReady();
    }
}
