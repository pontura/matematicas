using UnityEngine;
using System;
using System.Collections;

public class MinigamePesos : Minigame {

    public float peso;
    public float result;
    public ButtonAddRemove[] buttons;

    public GameObject itemContainer1;
    public GameObject itemContainer2;
    public GameObject itemContainer3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

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
        
        peso = 0;
        Texts.Minigame_Peso minigame = Data.Instance.texts.GetMinigame_Peso();
        string textFinal = minigame.title;
        string insertfield = "";

        int total = 0;

        if (minigame.type == Texts.Minigame_Peso.Minigame_Peso_type.PROMEDIO)
        {
            foreach (int prom in minigame.promedios)
            {
                int num = GetPromNumber();
                total += num;
                insertfield += " " + num.ToString() + "k";
            }
            result = total / minigame.promedios.Count;
        }
        else if (minigame.type == Texts.Minigame_Peso.Minigame_Peso_type.HARDCODE)
        {
            result = minigame.result;
        }
        else
        {
            int toneladas = UnityEngine.Random.Range(20, 50);
            int kilos = UnityEngine.Random.Range(1, 9) * 100;
            insertfield += toneladas + " toneladas y " + kilos + " kilos";
            result = (toneladas*1000) + kilos;
        }

        desc.text = textFinal.Replace("[]", insertfield);

        buttons[0].Init(this, minigame.peso1);
        buttons[1].Init(this, minigame.peso2);
        buttons[2].Init(this, minigame.peso3);
    }
    override public void Reset()
    {
        peso = 0;
        EmptyContainer(itemContainer1);
        EmptyContainer(itemContainer2);
        EmptyContainer(itemContainer3);
    }
    void EmptyContainer(GameObject itemContainer)
    {
        int num = itemContainer.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(itemContainer.transform.GetChild(0).gameObject);
    }
    private int GetPromNumber()
    {
        return ((UnityEngine.Random.Range(0, 99) * 2) * 10) + 500;
    }
    private float GetButtonPorPeso(float peso)
    {
        if (buttons[0].peso == peso) return 1;
        else  if (buttons[1].peso == peso) return 2;
        else return 3;
    }
    public void Add(float _peso)
    {
        if (GetButtonPorPeso(_peso) == 1)
        {
            GameObject item = Instantiate(item1) as GameObject;
            item.transform.SetParent(itemContainer1.transform);
            item.transform.localScale = Vector3.one;
            float separationY = _separationY * (itemContainer1.GetComponentsInChildren<Transform>().Length-2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        else if (GetButtonPorPeso(_peso) == 2)
        {
            GameObject item = Instantiate(item2) as GameObject;
            item.transform.SetParent(itemContainer2.transform);
            item.transform.localScale = Vector3.one;
            float separationY = _separationY * (itemContainer2.GetComponentsInChildren<Transform>().Length - 2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        else
        {
            GameObject item = Instantiate(item3) as GameObject;
            item.transform.SetParent(itemContainer3.transform);
            item.transform.localScale = Vector3.one;
            float separationY = _separationY * (itemContainer3.GetComponentsInChildren<Transform>().Length - 2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        this.peso += _peso;
        this.peso = (float)Math.Round((double)peso, 2);
       // CheckResult();
    }
    public void Remove(float _peso)
    {
        Transform[] items;

        if (GetButtonPorPeso(_peso) == 1)
        {
           items = itemContainer1.GetComponentsInChildren<Transform>();            
        }
        else if (GetButtonPorPeso(_peso) == 2)
        {
            items = itemContainer2.GetComponentsInChildren<Transform>();
        }
        else
        {
            items = itemContainer3.GetComponentsInChildren<Transform>();
        }

        if (items.Length > 1)
        {
            Destroy(items[items.Length - 1].gameObject);

            this.peso -= _peso;
            if (peso < 0) peso = 0;
        }
        //CheckResult();
    }
    public void CheckResult()
    {
        if (result == peso)
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
