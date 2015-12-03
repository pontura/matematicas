using UnityEngine;
using System.Collections;

public static class Events {

    public static System.Action<IslandsManager.DataIsland> Map_OpenIslandSignal = delegate { };
    public static System.Action OnMinigameReady = delegate { };
    public static System.Action OnTripStarted = delegate { };   
    
}
