using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Ranking : MonoBehaviour {

    public List<RankingData> data;

    private string TABLE = "users";

    [Serializable]
    public class RankingData
    {
        public int achievements;
        public string username;
        public string userID;
    }
    void Start()
    {
        data.Clear();
        LoadRanking();
        AchievementsEvents.OnRefreshTotalAchievements += OnRefreshTotalAchievements;
        //SocialEvents.OnNewHiscore += OnNewHiscore;
        ////SocialEvents.OnFacebookFriends += OnFacebookFriends;
        //SocialEvents.OnRefreshRanking += OnRefreshRanking;
    }
    void OnDestroy()
    {
        AchievementsEvents.OnRefreshTotalAchievements -= OnRefreshTotalAchievements;
        //SocialEvents.OnNewHiscore -= OnNewHiscore;
        //// SocialEvents.OnFacebookFriends -= OnFacebookFriends;
        //SocialEvents.OnRefreshRanking -= OnRefreshRanking;
    }
    public void LoadRanking()
    {
        data = new List<RankingData>();
        string url = SocialManager.Instance.FIREBASE + "/" + TABLE + ".json?orderBy=\"achievements\"&limitToLast=100";
        Debug.Log("LoadRanking: " + url);
        HTTP.Request someRequest = new HTTP.Request("get", url);
        someRequest.Send((request) =>
        {
            Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (decoded == null || decoded.Count == 0)
            {
                Debug.LogError("server returned null or     malformed response ):");
                return;
            }
            foreach (DictionaryEntry json in decoded)
            {
                Hashtable jsonObj = (Hashtable)json.Value;
                RankingData newData = new RankingData();
                newData.username = (string)jsonObj["username"];
                int ach = (int)jsonObj["achievements"];
                newData.userID = (string)json.Key;
                newData.achievements = ach;
                data.Add(newData);
            }
            data = OrderByScore(data);
        });
    }
    List<RankingData> OrderByScore(List<RankingData> rankingData)
    {
        return rankingData.OrderBy(go => go.achievements).Reverse().ToList();
    }
    void OnRefreshTotalAchievements(int total)
    {
        foreach (RankingData rd in data)
        {
            if (rd.userID == Data.Instance.userData.userID)
            {
                rd.achievements = total;
            }
        }
        data = OrderByScore(data);
    }
}
