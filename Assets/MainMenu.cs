using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button[] buttons;
    private GameManager gameManager;

	void Start () {
        gameManager = GetComponent<GameManager>();
        Invoke("Mapa", 0.5f);       
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
        SetActive(1);
        gameManager.Open("Mapa");
    }
    public void Isla()
    {
        SetActive(2);
        if (Game.Instance.islandsManager.gotoIsland.distance > 1)
            gameManager.Open("IslandDetail");
        else
            gameManager.Open("Isla");
    }
    public void Barco()
    {
        SetActive(3);
        gameManager.Open("Barco");
    }
    public void Block()
    {
        SetActive(4);
    }
    public void Logros()
    {
        SetActive(5);
    }
}
