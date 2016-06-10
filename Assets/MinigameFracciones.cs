using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MinigameFracciones : Minigame {

    public MathDevice mathDevice;
    public FraccionesDraggingObject draggingObject;
    private bool dragging;
    public FraccionesSlot fraccionesSlot;
    public Transform container;


    public int totalResults;

    public Text recta1;
    public Text recta2;

    public List<int> results;

    void Start()
    {

    }
    public void Init()
    {
       // desc.text = "";
       // descSmall.text = "";
        mathDevice.Init(MinigamesManager.types.FRACCIONES);       

        if (Game.Instance.gameManager.Isla.GetComponent<Isla>().state == Isla.states.MINIGAME_STARTED) return;

        Texts.Minigame_Fracciones minigame = Data.Instance.texts.GetMinigame_Fracciones();
        string textFinal = minigame.title;

        desc.text = "";
        descSmall.text = textFinal;

        int total = minigame.slots;

        recta1.text = minigame.recta[0].ToString();
        recta2.text = minigame.recta[1].ToString();

        results.Add(minigame.fracciones[0]);
        results.Add(minigame.fracciones[1]);
        results.Add(minigame.fracciones[2]);
        results.Add(minigame.fracciones[3]);

        for (int a = 0; a < total; a++ )
        {
            FraccionesSlot button = Instantiate(fraccionesSlot);
            button.transform.SetParent(container);
            button.id = a+1;
            button.GetComponent<Button>().onClick.AddListener(() => { SlotClicked(button); });
            button.transform.localScale = Vector2.one;
            int _id = 1;
            foreach (int piedraID in results)
            {
                if (piedraID == button.id) button.resultPiedraID = _id;
                _id++;
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
        //if (results != null)
        //        results.Clear();
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
