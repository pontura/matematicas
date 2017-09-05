using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MinigameVelocidad : Minigame
{

    public int result;
    public InputField inputField;
    public Text label;
    public int active;

    public GameObject gemas1;
    public GameObject gemas2;
    public GameObject gemas3;
    public GameObject gemas4;
    public GameObject gemas5;


    public MathDevice mathDevice;

    public GameObject StartButton;
    public Text ClockFiled;

    bool playing;

    public int secs;

    private float _separationY = 0.16f;

    void Start()
    {
        UpdateClock();
    }
    void OnEnable()
    {
        active = 0;
        StartButton.SetActive(true);
        Events.OnMinigameStartCalculator();
        inputField.text = "";
        ClockFiled.text = "";
        
    }
    void OnDisable()
    {
        playing = false;
    }
    private Texts.Minigame_Velocidad minigame;
    public void Init()
    {
       
        ClockFiled.text = "";
        StartButton.SetActive(true);

        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
        mathDevice.Appear();

        minigame = Data.Instance.texts.GetMinigame_Velocidad();
      

        string textFinal = minigame.title;


        print("textFinal: " + textFinal);

        descSmall.text = "";
        desc.text = textFinal;

        gemas1.SetActive(false);
        gemas2.SetActive(false);
        gemas3.SetActive(false);
        gemas4.SetActive(false);
        gemas5.SetActive(false);
    }
    public void StartGame()
    {
        InitGame();
        secs = minigame.time;
        playing = true;
    }
    void InitGame()
    {        
        StartButton.SetActive(false);

        ActivateNext();

        desc.text = "";
        string textFinal = "";

        int a = 0;
        foreach (Texts.Minigame_Velocidad.Ejercicio ejercicio in minigame.ejercicios)
        {
            if (a > 0)
                textFinal += "\n";

            a++;

            textFinal += a + ") " + ejercicio.ejercicio;

        }

        descSmall.text = textFinal;

    }
    void UpdateClock()
    {
        Invoke("UpdateClock", 1);
        if (!playing) return;
        if (secs > 0)
            secs--;
        if (secs <= 0)
        {
            if (secs == minigame.time)
                ClockFiled.text = "";
            else
                ClockFiled.text = "Pasó el tiempo (No suma logros)";
            return;
        }
        int min = (int)Mathf.Floor(secs / 60);
        int sec = secs - (min * 60);

        string sec_field = sec.ToString();
        if (sec < 10) sec_field = "0" + sec;

        ClockFiled.text = min + ":" + sec_field;
    }
    override public void Reset()
    {
        print("RESET");
        result = 0;
        playing = false;
    }
    private int GetValue(InputField inputField)
    {
        try
        {
            return int.Parse(inputField.text);
        }
        catch
        {
            return 0;
        }
    }
    public void CheckResult()
    {
        if (GetValue(inputField) == result)
            CheckNextResult();
        else
        {
            Events.OnMinigameMistake();
            inputField.text = "";
        }
    }
    void CheckNextResult()
    {
        if (active >= minigame.ejercicios.Count)
        {
            if (secs > 0) Events.NewSpeedExercicesReady();
            Invoke("MinigameReady", 0.7f);
            mathDevice.Disappear();
        }
        else
        {
            ActivateNext();
        }
    }
    void ActivateNext()
    {
        
        active++;
        inputField.text = "";
        label.text = active + ")";
        result = minigame.ejercicios[active - 1].resultado;

        int gemasActivas = (int)(active * 5 / minigame.ejercicios.Count);

        print("gemasActivas " + gemasActivas + " active: " + active + " minigame.ejercicios.Count): " + minigame.ejercicios.Count);

        if (gemasActivas > 1)
            gemas1.SetActive(true);
        if (active > 2)
            gemas2.SetActive(true);
        if (active > 3)
            gemas3.SetActive(true);
        if (active > 4)
            gemas4.SetActive(true);
        if (active > 5)
            gemas5.SetActive(true);

        if (active > 1)
        {
            if (Game.Instance.mainMenu.blockOn)
            {
                Game.Instance.mainMenu.BlockClose();
                // Invoke("OpenBlock", 2);
            }
        }
    }
    void OpenBlock()
    {
        //Game.Instance.mainMenu.BlockOpen();
    }
    void MinigameReady()
    {
        Events.OnMinigameReady();
    }
    override public string GetDescriptionForBlock()
    {
        string clockResult = "";
        if (!playing) return "";
        if (secs > 0)
        {
            clockResult = ClockFiled.text;
        }
        else
        {
            clockResult = "Fuera de tiempo";
        }
        return descSmall.text + "\n(tiempo: " + clockResult + ")";
    }
}
