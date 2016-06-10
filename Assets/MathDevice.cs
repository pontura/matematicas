using UnityEngine;
using System.Collections;

public class MathDevice : MonoBehaviour {

    public GameObject minigameA;
    public GameObject minigameB;
    public GameObject minigameC;
    public GameObject minigameD;
    public GameObject minigameE;

    void Start()
    {
        Events.OnMinigameMistake += OnMinigameMistake;
    }
    void OnMinigameMistake()
    {
        Game.Instance.mainMenu.BlockClose();
        Invoke("DelayToOpen", 1.5f);
    }
	public void Init(MinigamesManager.types type) {

        gameObject.SetActive(true);

        minigameA.SetActive(false);
        minigameB.SetActive(false);
        minigameC.SetActive(false);
        minigameD.SetActive(false);
        minigameE.SetActive(false);

       // print("__________MathDevice Appear" + type);

        switch (type)
        {
            case MinigamesManager.types.PESAR: 
                minigameA.SetActive(true); 
                break;
            case MinigamesManager.types.SIMPLE_INPUT: 
                minigameB.SetActive(true);                
                break;
            case MinigamesManager.types.FRACCIONES:
                minigameC.SetActive(true);
                break;
            case MinigamesManager.types.VELOCIDAD:
                minigameD.SetActive(true);
                break;
            case MinigamesManager.types.FINAL:
                gameObject.SetActive(false);
                minigameE.SetActive(true);
                break; 
        }
	}
    void OnEnable()
    {
        GetComponent<Animator>().Play("deviceAppear", 0, 0);
        Invoke("DelayToOpen", 0.5f);
    }
    void DelayToOpen()
    {
        if (minigameD.activeSelf)
            return;
        else
            Game.Instance.mainMenu.BlockOpen();
    }
    void OnDisable()
    {
        Game.Instance.mainMenu.BlockClose();
    }
    public void Appear()
    {
        GetComponent<Animator>().Play("deviceAppear", 0, 0);
    }
    public void Disappear()
    {
        //Events.OnBlockStatus(false);
        GetComponent<Animator>().Play("deviceDissappear", 0, 0);
    }
}
