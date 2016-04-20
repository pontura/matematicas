using UnityEngine;
using System.Collections;

public class MinigamesManager : MonoBehaviour {

    public bool ready;
    public enum types
    {
        SIMPLE_INPUT,
        PESAR,
        FRACCIONES,
        VELOCIDAD
    }

	void Start () {
        Events.OnMinigameReady += OnMinigameReady;
        Events.OnTripStarted += OnTripStarted;
	}
    void OnDestroy()
    {
        Events.OnMinigameReady -= OnMinigameReady;
        Events.OnTripStarted -= OnTripStarted;
    }

    void OnMinigameReady()
    {
        ready = true;
	}
    void OnTripStarted()
    {
        ready = false;
    }
}
