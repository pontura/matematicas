using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameSimpleInput : Minigame {

    public Text desc;
    public int result;
    public Text inputField;

    public MathDevice mathDevice;

    private float _separationY = 0.16f;

    void Start()
    {
        Reset();
    }
    public void Init()
    {
        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
        mathDevice.Appear();

        Texts.Minigame_SimpleInput minigame = Data.Instance.texts.GetMinigame_SimpleInput();
        string textFinal = minigame.title;
        string insertfield = "AA";

        if (minigame.type == Texts.Minigame_SimpleInput.Minigame_SimpleInput_type.RESTA)
        {
            result = 100;
        }

        desc.text = textFinal.Replace("[]", insertfield);

    }
    override public void Reset()
    {
        result = 0;
    }
    private int GetPromNumber()
    {
        return ((Random.Range(0, 99) * 2)*10)+500;
    }
    
    public void CheckResult()
    {
        if (result.ToString() == inputField.text)
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
