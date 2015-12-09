﻿using UnityEngine;
using System.Collections;

public static class Events {

    public static System.Action<IslandsManager.DataIsland> Map_OpenIslandSignal = delegate { };
    public static System.Action OnMinigameReady = delegate { };
    public static System.Action OnTripStarted = delegate { };
    public static System.Action OnShipArrived = delegate { };
    public static System.Action OnSaveInventary = delegate { };
    public static System.Action OnShipRefreshCarga = delegate { };
    public static System.Action<bool> OnBlockStatus = delegate { };  
    
}
