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
    }
    void Start()
    {
        data.Clear();
        LoadRanking();
        //SocialEvents.OnNewHiscore += OnNewHiscore;
        ////SocialEvents.OnFacebookFriends += OnFacebookFriends;
        //SocialEvents.OnRefreshRanking += OnRefreshRanking;
    }
    void OnDestroy()
    {
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
                // s.id = (string)json.Key;
                newData.username = (string)jsonObj["username"];
                int ach = (int)jsonObj["achievements"];
                print(ach);
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
    //void OnRefreshRanking()
    //{
    //    int hiscore = SocialManager.Instance.userHiscore.GetHiscore();

    //    bool userExistsInRanking = false;
    //    foreach (RankingData rankingData in data)
    //    {
    //        if (rankingData.facebookID == SocialManager.Instance.userData.facebookID)
    //        {
    //            rankingData.score = hiscore;
    //            userExistsInRanking = true;
    //            rankingData.isYou = true;
    //        }
    //    }
    //    if (!userExistsInRanking)
    //    {
    //        RankingData rankingData = new RankingData();
    //        rankingData.facebookID = SocialManager.Instance.userData.facebookID;
    //        rankingData.score = hiscore;
    //        rankingData.playerName = SocialManager.Instance.userData.username;
    //        rankingData.isYou = true;
    //        data.Add(rankingData);
    //    }
    //    //OrderByScore();
    //}
    
    //void OnNewHiscore(int score)
    //{
    //    int levelID = Data.Instance.moodsManager.currentMood;

    //    if (!SocialManager.Instance.userData.logged) return;

    //    List<RankingData> currentLevelData = levels[levelID - 1].data;

    //    foreach (RankingData rankingData in currentLevelData)
    //    {
    //        if (rankingData.facebookID == SocialManager.Instance.userData.facebookID)
    //        {
    //            rankingData.score = score;
    //            return;
    //        }
    //    }
    //    RankingData newData = new RankingData();
    //    newData.facebookID = SocialManager.Instance.userData.facebookID;
    //    newData.isYou = true;
    //    newData.playerName = SocialManager.Instance.userData.username;
    //    newData.score = score;
    //    currentLevelData.Add(newData);
    //    levels[levelID - 1].data = OrderByScore(currentLevelData);
    //}
}
