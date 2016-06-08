using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class AchievementsManager : MonoBehaviour
{
    public int totalReady;
    public List<Achievement> achievements;
    string jsonUrl = "achievements";
    public string dataBaseString = "";

    const string PREFAB_PATH = "AchievementsManager";
    static AchievementsManager mInstance = null;

    public static AchievementsManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<AchievementsManager>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<AchievementsManager>();
                    go.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
            return mInstance;
        }
    }
  
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        AchievementsEvents.OnReady += OnReady;
    }

    /// <summary>
    /// Achievements here:
    /// </summary>
    /// 
    
    

    void Start()
    {
        string filepath = (Application.dataPath + jsonUrl);
        TextAsset file = Resources.Load(jsonUrl) as TextAsset;
        LoadDataromServer(file.text);
        Events.OnResetApp += OnResetApp;
    }
    void OnResetApp()
    {
        foreach ( Achievement ach in achievements)
        {
            ach.ready = false;
        }
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = SimpleJSON.JSON.Parse(json_data);
        string arrayName = "achievements";
        achievements = new List<Achievement>(Json[arrayName].Count);
        for (int a = 0; a < Json[arrayName].Count; a++)
        {
            string type = Json[arrayName][a]["type"];

            switch (type)
            {
                case "MISSION": 
                    AchievementMission achievement_mission = new AchievementMission();
                    achievement_mission.title = Json[arrayName][a]["title"];
                    achievement_mission.id = a;
                    achievement_mission.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_mission.image = Json[arrayName][a]["image"];
                    achievement_mission.mission = int.Parse(Json[arrayName][a]["mission"]);
                    achievement_mission.Init();
                    achievements.Add(achievement_mission);
                    break;
                case "DISTANCE":
                    AchievementDistance achievement_distance = new AchievementDistance();
                    achievement_distance.title = Json[arrayName][a]["title"];
                    achievement_distance.id = a;
                    achievement_distance.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_distance.image = Json[arrayName][a]["image"];
                    achievement_distance.pointsToBeReady = int.Parse(Json[arrayName][a]["distance"]);
                    achievement_distance.Init();
                    achievements.Add(achievement_distance);
                    break;
                case "BLOCK":
                    AchievementBlock achievement_block = new AchievementBlock();
                    achievement_block.title = Json[arrayName][a]["title"];
                    achievement_block.id = a;
                    achievement_block.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_block.image = Json[arrayName][a]["image"];
                    achievement_block.pointsToBeReady = int.Parse(Json[arrayName][a]["send"]);
                    achievement_block.Init();
                    achievements.Add(achievement_block);
                    break;
                case "SPEED":
                    AchievementSpeed achievement_speed= new AchievementSpeed();
                    achievement_speed.title = Json[arrayName][a]["title"];
                    achievement_speed.id = a;
                    achievement_speed.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_speed.image = Json[arrayName][a]["image"];
                    achievement_speed.pointsToBeReady = int.Parse(Json[arrayName][a]["ejercicios"]);
                    achievement_speed.Init();
                    achievements.Add(achievement_speed);
                    break;
            }
        }
        SetAchievements();
    }
    public Achievement GetAchievement(int id)
    {
        return achievements[id];
    }
    void SetAchievements()
    {
        totalReady = 0;
        dataBaseString = "";
        foreach (Achievement ach in achievements)
        {
            string result = "0";
            if (ach.ready)
            {
                result = "1";
                totalReady++;                
            }
            dataBaseString += result + ",";
        }
        AchievementsEvents.OnRefreshTotalAchievements(totalReady);
    }
    void OnReady(int id)
    {
        print("OnReady" + id);
        SetAchievements();
        Update_DB();
    }
    public void Update_DB()
    {
        print("____Achievements objectID totalReady: " + totalReady);

        Hashtable data = new Hashtable();
        data.Add("achievements", totalReady);
        string url = SocialManager.Instance.FIREBASE + "/users/" + Data.Instance.userData.userID + "/.json";

        Debug.Log(url);

        HTTP.Request theRequest = new HTTP.Request("patch",url, data);

        theRequest.Send((request) =>
        {
            Hashtable jsonObj = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (jsonObj == null)
            {
                Debug.LogError("server returned null or malformed response ):");
            }
            Debug.Log("achievements updated: " + request.response.Text);
        });
    }
    
    

}
