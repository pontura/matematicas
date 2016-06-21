using UnityEngine;
using System.Collections;

public static class SocialEvents {

    //userID, filtered -> 1 si, 0 no
    public static System.Action<int, int, System.Action> OnSetFiltered = delegate { };

    public static System.Action<int> OnSaveAchievements = delegate { };
    public static System.Action<System.Action<string>> OnGetRanking = delegate { };
    public static System.Action<int, System.Action<string>> OnGetAlumnos = delegate { };
    public static System.Action<int, System.Action<string>> OnGetEjercicios = delegate { };
    public static System.Action<bool> OnUserExistInDB = delegate { };
    public static System.Action OnUserCreatedInDB = delegate { };
    public static System.Action ResetApp = delegate { };

    public static System.Action<string, string> OnLogin = delegate { };

    //facebookID, id
    public static System.Action<string, string> OnUserReady = delegate { };

    public static System.Action OnFacebookFriends = delegate { };
    public static System.Action OnFacebookNotConnected = delegate { };
    public static System.Action OnFacebookInviteFriends = delegate { };
    public static System.Action OnFacebookLogin = delegate { };
    public static System.Action OnFacebookLoginCanceled = delegate { };
    public static System.Action<string, string> AddFacebookFriend = delegate { }; 

    public static System.Action<string, float, int> OnParseLoadedScore = delegate { };
    public static System.Action OnLoadLocalData = delegate { };

    //Hiscores:
    public static System.Action<int> OnNewHiscore = delegate { };
    public static System.Action<int> OnAddToTotalScore = delegate { };
    public static System.Action<int> OnSetToTotalBarScore = delegate { };
    
    public static System.Action OnRefreshRanking = delegate { };

    //challenges:
    //facebookID, op_facebookID, score
    public static System.Action<string, string, int> OnChallengeCreate = delegate { };
    public static System.Action<string> OnChallengeDelete = delegate { };
    public static System.Action OnChallengesLoad = delegate { };
    public static System.Action<string, string> OnChallengeRemind = delegate { };
    public static System.Action<string, string, string, float> OnChallengeClose = delegate { };
    public static System.Action<string> OnChallengeNotificated = delegate { };
    public static System.Action<string, string, string, float> OnChallengeConfirm = delegate { };
}
