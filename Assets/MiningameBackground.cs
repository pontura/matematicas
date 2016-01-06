using UnityEngine;
using System.Collections;

public class MiningameBackground : MonoBehaviour {
    
	void Start () {
        Events.OnMinigameStart += OnMinigameStart;
        Events.OnMinigameReady += OnMinigameReady;
        Events.OnMinigameMistake += OnMinigameMistake;
	}

    void OnDestroy()
    {
        Events.OnMinigameStart -= OnMinigameStart;
        Events.OnMinigameReady -= OnMinigameReady;
        Events.OnMinigameMistake -= OnMinigameMistake;
    }
	
    void OnMinigameStart()
    {
        GetComponent<Animator>().Play("minigameA_idle", 0, 0);
	}
    void OnMinigameReady()
    {
        GetComponent<Animator>().Play("minigameA_win", 0, 0);
    }
    void OnMinigameMistake()
    {
        GetComponent<Animator>().Play("minigameA_lose", 0, 0);
    }
}
