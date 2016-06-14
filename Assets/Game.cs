using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    const string PREFAB_PATH = "Game";
    static Game mInstance = null;

    [HideInInspector]
    public IslandsManager islandsManager;
    [HideInInspector]
    public Inventary inventary;
    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public MainMenu mainMenu;
    [HideInInspector]
    public MinigamesManager minigamesManager;
    [HideInInspector]
    public IslandDistances islandDistances;

    public states state;
    public enum states
    {
        ARRIVED,
        TRAVELLING,
        MINIGAME_READY,
    }

    public static Game Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Game>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Game>();
                    go.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {
        Application.LoadLevel(aLevelName);
    }
    void Awake()
    {

        if (!mInstance)
            mInstance = this;
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(this.gameObject);
            return;
        }

        islandsManager = GetComponent<IslandsManager>();
        inventary = Data.Instance.GetComponent<Inventary>();
        mainMenu = GetComponent<MainMenu>();
        gameManager = GetComponent<GameManager>();
        minigamesManager = GetComponent<MinigamesManager>();
        islandDistances = GetComponent<IslandDistances>();

        Invoke("StartGame", 1f);
        
    }
    void StartGame()
    {
        if (Data.Instance.DEBUG)
        {
            Data.Instance.GetComponent<Inventary>().nafta = 9;
            Data.Instance.GetComponent<Inventary>().comida = 9;
        }

        if (Data.Instance.userData.firstTimeHere)
        {            
            Events.OnTipsOn(0);
            gameManager.OpenCustomizer();
        }
        else mainMenu.Mapa();
    }
    void Start()
    {
        Events.OnTripStarted += OnTripStarted;
        Events.OnShipArrived += OnShipArrived;
        Events.OnMinigameReady += OnMinigameReady;
    }
    void OnDestroy()
    {
        Events.OnTripStarted -= OnTripStarted;
        Events.OnShipArrived -= OnShipArrived;
        Events.OnMinigameReady -= OnMinigameReady;
    }
    void OnTripStarted()
    {
        state = states.TRAVELLING;
    }
    void OnShipArrived()
    {
        state = states.ARRIVED;
    }
    void OnMinigameReady()
    {
        state = states.MINIGAME_READY;
    }
}
