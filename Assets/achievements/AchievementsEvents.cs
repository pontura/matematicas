using UnityEngine;
using System.Collections;

public static class AchievementsEvents
{
    public static System.Action<int> OnReady = delegate { };
    public static System.Action<int> OnMissionComplete = delegate { };
    public static System.Action<int> OnNewDistance = delegate { };
    public static System.Action OnNewSpeedExercices = delegate { };
    public static System.Action OnNewBlockSended = delegate { };
    public static System.Action<int> OnRefreshTotalAchievements = delegate { };
    public static System.Action<int> OnGema = delegate { };
    public static System.Action<int> OnAchievementEvent = delegate { };
    public static System.Action OnNewTravelSuccess = delegate { };
}