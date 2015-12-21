using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigamePesos : Minigame {

    public Text desc;
    public int peso;
    public int result;
    public ButtonAddRemove[] buttons;

    public GameObject itemContainer1;
    public GameObject itemContainer2;
    public GameObject itemContainer3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    public Animator anim;

    void Start()
    {
        Reset();
    }
    void Init()
    {
        peso = 0;
        Texts.Minigame_Peso minigame = Data.Instance.texts.GetMinigame();
        string textFinal = minigame.title;
        string insertfield = "";

        int total = 0;

        if (minigame.type == Texts.Minigame_Peso.Minigame_Peso_type.PROMEDIO)
        {
            foreach (int prom in minigame.promedios)
            {
                int num = GetPromNumber();
                total += num;
                print("total" + total + "    " + num);
                insertfield += "\n" + num.ToString() + "k";
            }
            result = total / minigame.promedios.Length;
        }
        else
        {
            int toneladas = Random.Range(20, 50);
            int kilos = Random.Range(1,9) * 100;
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
        Init();
    }
    void EmptyContainer(GameObject itemContainer)
    {
        int num = itemContainer.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(itemContainer.transform.GetChild(0).gameObject);
    }
    private int GetPromNumber()
    {
        return ((Random.Range(0, 99) * 2)*10)+500;
    }
    private int GetButtonPorPeso(int peso)
    {
        if (buttons[0].peso == peso) return 1;
        else  if (buttons[1].peso == peso) return 2;
        else return 3;
    }
    public void Add(int _peso)
    {
        int _separationY = 20;
        if (GetButtonPorPeso(_peso) == 1)
        {
            GameObject item = Instantiate(item1) as GameObject;
            item.transform.SetParent(itemContainer1.transform);
            item.transform.localScale = Vector3.one;
            int separationY = _separationY * (itemContainer1.GetComponentsInChildren<Transform>().Length-2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        else if (GetButtonPorPeso(_peso) == 2)
        {
            GameObject item = Instantiate(item2) as GameObject;
            item.transform.SetParent(itemContainer2.transform);
            item.transform.localScale = Vector3.one;
            int separationY = _separationY *( itemContainer2.GetComponentsInChildren<Transform>().Length-2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        else
        {
            GameObject item = Instantiate(item3) as GameObject;
            item.transform.SetParent(itemContainer3.transform);
            item.transform.localScale = Vector3.one;
            int separationY = _separationY * (itemContainer3.GetComponentsInChildren<Transform>().Length-2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        this.peso += _peso;
       // CheckResult();
    }
    public void Remove(int _peso)
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
            Destroy(items[items.Length-1].gameObject);

        this.peso -= _peso;
        if (peso < 0) peso = 0;
        //CheckResult();
    }
    public void CheckResult()
    {
        if (result == peso)
            Events.OnMinigameReady();
        else
            Events.OnMinigameMistake();
    }
}
