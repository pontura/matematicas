using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class AchievementsManager : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public int totalReady;
    public List<Achievement> achievements;
    string jsonUrl = "achievements";
    public string dataBaseString = "";
=======
    public List<Achievement> achievements;
    string jsonUrl = "achievements";
>>>>>>> Stashed changes
=======
    public List<Achievement> achievements;
    string jsonUrl = "achievements";
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        AchievementsEvents.OnReady += OnReady;
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
=======
>>>>>>> Stashed changes
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = JSON.Parse(json_data);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    achievement_mission.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_mission.image = Json[arrayName][a]["image"];
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                    achievement_mission.mission = int.Parse(Json[arrayName][a]["mission"]);
                    achievement_mission.Init();
                    achievements.Add(achievement_mission);
                    break;
                case "DISTANCE":
                    AchievementDistance achievement_distance = new AchievementDistance();
                    achievement_distance.title = Json[arrayName][a]["title"];
                    achievement_distance.id = a;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    achievement_distance.progress = int.Parse(Json[arrayName][a]["progress"]);
                    achievement_distance.image = Json[arrayName][a]["image"];
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
                    achievement_distance.pointsToBeReady = int.Parse(Json[arrayName][a]["distance"]);
                    achievement_distance.Init();
                    achievements.Add(achievement_distance);
                    break;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
            }
        }
        SetAchievements();
=======
            }
        }
>>>>>>> Stashed changes
=======
            }
        }
>>>>>>> Stashed changes
    }
    public Achievement GetAchievement(int id)
    {
        return achievements[id];
    }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
    
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
    

}
