using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button[] buttons;
    private GameManager gameManager;
    public GameObject masker;
    public GameObject blockOn;
    public GameObject blockOff;
    private bool BlockOpened;
    public SceneBackgrounds scenesBackground;
    private bool showTutorial;

	void Start () {
        masker.SetActive(false);
        gameManager = GetComponent<GameManager>();
        Events.OnTripStarted += OnTripStarted;
        Events.OnShipArrived += OnShipArrived;
        Events.OnBlockStatus += OnBlockStatus;

        if (Data.Instance.userData.firstTimeHere) 
            showTutorial = true;
    }
    void OnBlockStatus(bool show)
    {
        buttons[3].gameObject.SetActive(show);
    }
    void OnDestroy()
    {
        Events.OnBlockStatus -= OnBlockStatus;
        Events.OnTripStarted -= OnTripStarted;
        Events.OnShipArrived -= OnShipArrived;
    }
    void OnTripStarted()
    {
        masker.SetActive(true);
    }
    void OnShipArrived()
    {
        masker.SetActive(false);
    }
    void SetActive(int id)
    {
        DeselectButtons();
        buttons[id - 1].interactable = false;
    }
    public void DeselectButtons()
    {
        foreach (Button button in buttons)
            button.interactable = true;
    }

    
    public void Mapa()
    {
        if (Data.Instance.userData.firstTimeHere && showTutorial == true)
        {
            Events.OnTipsOn( 1 );
            showTutorial = false;
        }
        scenesBackground.ResetScenes();
        SetActive(1);
        gameManager.Open("Mapa");
    }
    public void Isla(bool forceGoToMainIsland = false)
    {
        scenesBackground.ResetScenes();
        SetActive(2);

        //if (Game.Instance.islandsManager.gotoIsland != null && Game.Instance.islandsManager.gotoIsland.distance > 1 && !forceGoToMainIsland)
        //    gameManager.Open("IslandDetail");
        //else
            gameManager.Open("Isla");
    }
    public void IslaActiva()
    {
        scenesBackground.ResetScenes();
        SetActive(2);
        gameManager.Open("Isla");
    }
    public void Barco()
    {
        scenesBackground.ResetScenes();
        SetActive(3);
        gameManager.Open("Barco");
    }
    public void BlockOpen()
    {
        if (!BlockOpened)
        {
            gameManager.OpenBlock();
            blockOn.SetActive(false);
            blockOff.SetActive(true);
            BlockOpened = !BlockOpened;
        }
    }
    public void BlockClose()
    {
        if (BlockOpened)
        {
            gameManager.CloseBlock();
            blockOn.SetActive(true);
            blockOff.SetActive(false);
            BlockOpened = !BlockOpened;
        }
    }
    public void Block()
    {
        if (!BlockOpened)
        {
            gameManager.OpenBlock();
            blockOn.SetActive(false);
            blockOff.SetActive(true);
        }
        else
        {
            gameManager.CloseBlock();
            blockOn.SetActive(true);
            blockOff.SetActive(false);
        }
        BlockOpened = !BlockOpened;
        
    }
    public void Logros()
    {
        scenesBackground.ResetScenes();
        SetActive(5);
        gameManager.Open("Logros");
    }
}
