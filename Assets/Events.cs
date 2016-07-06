using UnityEngine;
using System.Collections;

public static class Events {


    public static System.Action<string> OnSoundFX = delegate { };
    public static System.Action<IslandsManager.DataIsland> Map_OpenIslandSignal = delegate { };
    public static System.Action<int> OnTipsOn = delegate { };
    public static System.Action<string> OnTipText = delegate { };
    public static System.Action OnLoading = delegate { };
    public static System.Action SendEmail = delegate { };  
    public static System.Action<bool> OnAdminLoading = delegate { };

    //bool: isNewUser pregunta si es nuevo el usuario:
    public static System.Action<bool> OnUserRegistration = delegate { };

    public static System.Action OnUserPasswordValidated = delegate { };

    public static System.Action OnMinigameStart = delegate { };
    public static System.Action OnMinigameStartCalculator = delegate { };
    public static System.Action OnMinigameReady = delegate { };
    public static System.Action OnMinigameMistake = delegate { };

    public static System.Action OnTripStarted = delegate { };
    public static System.Action OnShipArrived = delegate { };
    public static System.Action OnShipDie = delegate { };
    public static System.Action<int> NewDistanceTraveled = delegate { };
    public static System.Action NewSpeedExercicesReady = delegate { };
    
    public static System.Action OnSaveInventary = delegate { };
    public static System.Action OnShipRefreshCarga = delegate { };

    public static System.Action<bool> OnBlockStatus = delegate { };
    public static System.Action<string> OnBlockSendRequest = delegate { };
    public static System.Action<string> OnSaveBlock = delegate { };
    public static System.Action<string, string> OnSaveBlockToDB = delegate { };
    public static System.Action OnBlockReset = delegate { };

    public static System.Action OnMissionComplete = delegate { };
    public static System.Action<int> OnNewMission = delegate { };
    public static System.Action OnResetApp = delegate { };

    public static System.Action<bool> OnCustomizerActive = delegate { };
    public static System.Action<int> OnCustomizerButtonPrevClicked = delegate { };
    public static System.Action<int> OnCustomizerButtonNextClicked = delegate { };
    public static System.Action OnCustomizerSave = delegate { };

    public static System.Action<int> OnGetGema = delegate { };


    public static string OnGetFilePath(string pathTemp)
    {
        string path = Application.dataPath;
        if (Application.platform == RuntimePlatform.OSXPlayer)
            path += "/../../";
        else
            path += "/../";

        pathTemp = pathTemp.Replace("file://", "");
        pathTemp = "file://" + path + pathTemp;

        return pathTemp;
    }
    public static string GetPathBySystem(string pathTemp)
    {
        if (Application.platform == RuntimePlatform.OSXPlayer)
            pathTemp = pathTemp.Replace(@"\", @"/");

        return pathTemp;
    }
}
