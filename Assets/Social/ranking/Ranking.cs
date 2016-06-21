using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;


public class Ranking : MonoBehaviour {

    public List<RankingData> data;

    private string TABLE = "users";

    [Serializable]
    public class RankingData
    {
        public int achievements;
        public string username;
        public int userID;
    }
    void Start()
    {
        data.Clear();       
        AchievementsEvents.OnRefreshTotalAchievements += OnRefreshTotalAchievements;
        Invoke("Delay", 1);
    }
    void Delay()
    {
        LoadRanking();
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
        SocialEvents.OnGetRanking(OnGetRanking);
    }
    void OnGetRanking(string result)
    {
        string[] allData = Regex.Split(result, "</n>");

        for (var i = 0; i < allData.Length - 1; i++)
        {
            string[] userData = Regex.Split(allData[i], ":");

            RankingData newData = new RankingData();
            newData.userID = int.Parse(userData[0]);
            newData.username = userData[1];
            newData.achievements = int.Parse(userData[2]);
            data.Add(newData);
        }
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
