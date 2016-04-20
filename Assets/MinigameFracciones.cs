using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MinigameFracciones : Minigame {

    public Text desc;
    public MathDevice mathDevice;
    public FraccionesDraggingObject draggingObject;
    private bool dragging;
    public FraccionesSlot fraccionesSlot;
    public Transform container;

    public List<ResultLine> results;
    public int totalResults;

    [SerializeField]
    public class ResultLine
    {
        public int piedraID;
        public int num;
    }

    void Start()
    {

    }
    public void Init()
    {        
        mathDevice.Init(MinigamesManager.types.FRACCIONES);
        mathDevice.Appear();

        if (Game.Instance.gameManager.Isla.GetComponent<Isla>().state == Isla.states.MINIGAME_STARTED) return;
        if (results != null && results.Count > 0) return;

        Texts.Minigame_Fracciones minigame = Data.Instance.texts.GetMinigame_Fracciones();
        string textFinal = minigame.title;
        //desc.text = textFinal.Replace("[]", insertfield);
        desc.text = textFinal;
        desc.text += " Coloca ";

        int total = minigame.slots;

        total++;

        results = new List<ResultLine>();
        int num = 1;
        foreach (string result in minigame.fracciones)
        {
            ResultLine line = new ResultLine();

            switch (num)
            {
                case 1:
                    desc.text += "una piedra verde a " + result; break;
                case 2:
                    desc.text += ", una roja a " + result; break;
                case 3:
                    desc.text += " y una amarilla a " + result; break;
            }

            string[] textSplit = result.Split("/"[0]);

            float frac = (float.Parse(textSplit[0]) / float.Parse(textSplit[1]));
            line.num = (int)(minigame.slots * frac);
            line.piedraID = num;
            results.Add(line);
            num++;
        }
        for (int a = 0; a < total; a++ )
        {
            FraccionesSlot button = Instantiate(fraccionesSlot);
            button.transform.SetParent(container);
            button.id = a;
            button.GetComponent<Button>().onClick.AddListener(() => { SlotClicked(button); });
            button.transform.localScale = Vector2.one;
            foreach (ResultLine line in results)
            {
                if (line.num == button.id) button.resultPiedraID = line.piedraID;
            }
        }
       
    }
    private int clickedId;
    public void Clicked(int clickedId)
    {
        this.clickedId = clickedId;
        draggingObject.Init(clickedId);
        dragging = true;
        draggingObject.gameObject.layer = 2;
        draggingObject.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
    public void SlotClicked(FraccionesSlot fraccionesSlot)
    {
        print("SlotClicked" + clickedId);

        if (clickedId > 0)
            fraccionesSlot.Init(clickedId);
        else
            fraccionesSlot.SetOff();
    }
    void Update()
    {
        draggingObject.transform.position = Input.mousePosition;
        if (dragging)
        {
            if (Input.anyKeyDown)
            {
                print("FUE");
                draggingObject.SetOff();
                Invoke("ResetClicked", 0.5f);
                dragging = false;
            }
        }
    }
    void ResetClicked()
    {
        clickedId = 0;        
    }
    override public void Reset()
    {
        if (results != null)
        results.Clear();
        foreach (FraccionesSlot slot in container.GetComponentsInChildren<FraccionesSlot>())
        {
            Destroy(slot.gameObject);
        }
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
    public void CheckResult()
    {
        foreach (FraccionesSlot slot in container.GetComponentsInChildren<FraccionesSlot>())
        {
            if (slot.piedraID != slot.resultPiedraID)
            {
                Events.OnMinigameMistake();
                return;
            }
        }
        MinigameReady();
    }
    void MinigameReady()
    {
        Events.OnMinigameReady();
    }
}
