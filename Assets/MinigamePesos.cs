using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigamePesos : Minigame {

    public Text desc;
    public int peso;
    public int average;
    public ButtonAddRemove[] buttons;

    public GameObject itemContainer1;
    public GameObject itemContainer2;
    public GameObject itemContainer3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    void OnEnable()
    {
        Texts.Minigame_Peso minigame = Data.Instance.texts.GetMinigame();
        string textFinal = minigame.title;
        string insertfield = "";

        int total = 0;

        foreach (int prom in minigame.promedios)
        {
            int num = GetPromNumber();
            total += num;
            print("total" + total + "    " + num);
            insertfield += "\n" + num.ToString() + "k";
        }
        average = total/minigame.promedios.Length;

        desc.text = textFinal.Replace("[]", insertfield + "\n");

        buttons[0].Init(this, minigame.peso1);
        buttons[1].Init(this, minigame.peso2);
        buttons[2].Init(this, minigame.peso3);
    }
    private int GetPromNumber()
    {
        return ((Random.Range(0, 40) * 2)*10)+1000;
    }
    public void Add(int _peso)
    {
        int _separationY = 20;
        if (_peso == 500)
        {
            GameObject item = Instantiate(item1) as GameObject;
            item.transform.SetParent(itemContainer1.transform);
            item.transform.localScale = Vector3.one;
            int separationY = _separationY * (itemContainer1.GetComponentsInChildren<Transform>().Length-2);
            item.transform.localPosition = new Vector3(0, separationY, 0);
        }
        else if (_peso == 50)
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
        CheckResult();
    }
    public void Remove(int _peso)
    {
        Transform[] items;

        if (_peso == 500)
        {
           items = itemContainer1.GetComponentsInChildren<Transform>();            
        }
        else if (_peso == 50)
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
        CheckResult();
    }
    public void CheckResult()
    {
        if (average == peso)
            Events.OnMinigameReady();
    }
}
