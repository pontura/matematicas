﻿using UnityEngine;
using System.Collections;

public class SceneBackgrounds : MonoBehaviour {

    public MiningameBackground[] minigames;

    public GameObject Customizer;
    public GameObject Trip;

    void Start()
    {
        ResetScenes();
        Events.OnCustomizerActive += OnCustomizerActive;
        Events.OnTripStarted += OnTripStarted;
        Events.OnShipArrived += OnShipArrived;
        
    }
    void OnDestroy()
    {
        Events.OnCustomizerActive -= OnCustomizerActive;
        Events.OnTripStarted -= OnTripStarted;
        Events.OnShipArrived -= OnShipArrived;
    }
    public void ResetScenes()
    {
        foreach (MiningameBackground minigameBg in minigames)
            minigameBg.SetOff();

        Customizer.SetActive(false);
        Trip.SetActive(false);
    }
    void OnCustomizerActive(bool state)
    {
        ResetScenes();
        Customizer.gameObject.SetActive(state);
    }
    void OnShipArrived()
    {
        Trip.SetActive(false);
    }
    void OnTripStarted()
    {
        Trip.SetActive(true);
    }
}
