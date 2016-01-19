using UnityEngine;
using System.Collections;

public static class Events {

    public static System.Action<IslandsManager.DataIsland> Map_OpenIslandSignal = delegate { };

    public static System.Action OnUserRegistration = delegate { };
    public static System.Action OnUserPasswordValidated = delegate { };

    public static System.Action OnMinigameStart = delegate { };
    public static System.Action OnMinigameReady = delegate { };
    public static System.Action OnMinigameMistake = delegate { };

    public static System.Action OnTripStarted = delegate { };
    public static System.Action OnShipArrived = delegate { };
    public static System.Action OnSaveInventary = delegate { };
    public static System.Action OnShipRefreshCarga = delegate { };
    public static System.Action<bool> OnBlockStatus = delegate { };

    public static System.Action OnMissionComplete = delegate { };
    public static System.Action<int> OnNewMission = delegate { };
    public static System.Action OnResetApp = delegate { };

    public static System.Action<bool> OnCustomizerActive = delegate { };
    public static System.Action<int> OnCustomizerButtonPrevClicked = delegate { };
    public static System.Action<int> OnCustomizerButtonNextClicked = delegate { };
    public static System.Action OnCustomizerSave = delegate { };
    
    
    

    
}
