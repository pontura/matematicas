using UnityEngine;
using System.Collections;

public class MathDevice : MonoBehaviour {

    public GameObject minigameA;
    public GameObject minigameB;
    public GameObject minigameC;

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

        minigameA.SetActive(false);
        minigameB.SetActive(false);
        minigameC.SetActive(false);

        print("__________MathDevice Appear" + type);
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
        }
	}
    void OnEnable()
    {
        GetComponent<Animator>().Play("deviceAppear", 0, 0);
        Invoke("DelayToOpen", 0.5f);
    }
    void DelayToOpen()
    {
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
