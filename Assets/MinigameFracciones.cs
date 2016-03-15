using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameFracciones : Minigame {
    
    public MathDevice mathDevice;
    public int result;
    public FraccionesDraggingObject draggingObject;
    private bool dragging;
    public FraccionesSlot fraccionesSlot;
    public Transform container;

    void Start()
    {
        Reset();
    }
    public void Init()
    {
        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
        mathDevice.Appear();
        print("OK");
        int total = 15;
        for (int a = 0; a < total; a++ )
        {
            FraccionesSlot button = Instantiate(fraccionesSlot);
            button.transform.SetParent(container);
            button.id = a+1;
            button.GetComponent<Button>().onClick.AddListener(() => { SlotClicked(button); });
            button.transform.localScale = Vector2.one;
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

        if (clickedId>0)
        fraccionesSlot.Init(clickedId);
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
        //peso = 0;
        //EmptyContainer(itemContainer1);
        //EmptyContainer(itemContainer2);
        //EmptyContainer(itemContainer3);
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
        if (result == 0)
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
