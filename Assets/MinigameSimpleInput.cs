using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameSimpleInput : Minigame {

    public Text desc;
    public int result = 0;
    public Text inputField;

    public MathDevice mathDevice;

    private float _separationY = 0.16f;

    void Start()
    {
        inputField.text = "";
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
            textFinal = GenerateRandomResults(textFinal);
        }   
        

        print("textFinal ___________" + textFinal);

        desc.text = textFinal.Replace("[]", insertfield);

    }
    string GenerateRandomResults(string _field)
    {
        string FieldToResturn = "";

        string[] textSplit = _field.Split("["[0]);
        
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
                    if (result > 0) result -= rand;
                    else result = rand;
                    FieldToResturn += rand.ToString();
                }
                else
                {
                    FieldToResturn += field2;
                }
            }


            //print(FieldToResturn);

            //textSplit = textSplit[1].Split("/"[0]);
            //int num1 = int.Parse(textSplit[0]);
            //int num2 = int.Parse(textSplit[1].Split("]"[0])[0]);

            //int rand = Random.Range(num1, num2);
            //result += rand;

            //FieldToResturn += rand.ToString();
            //FieldToResturn += rand.ToString();
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
        print("CheckResult: " + result.ToString() + " - " + inputField.text);

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
