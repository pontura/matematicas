using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour
{
   // const string PREFAB_PATH = "Data";
    static Data mInstance = null;
    public bool DEBUG;
    
    [HideInInspector]
    public MissionsManager missionsManager;
    [HideInInspector]
    public Settings settings;

    public Texts texts;
    public UserData userData;
    public ClothesSettings clothesSettings;
    public SavedSettings savedSettings;
    public GemasManager gemasManager;
    public AchievementEventsManager achievementEventsManager;

    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                //if (mInstance == null)
                //{
                //    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                //    mInstance = go.GetComponent<Data>();
                //    go.transform.localPosition = new Vector3(0, 0, 0);
                //}
            }
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {     
        Application.LoadLevel(aLevelName);
    }
    void Awake()
    {
        
        if (!mInstance)
            mInstance = this;
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this);
        missionsManager = GetComponent<MissionsManager>();
        texts = GetComponent<Texts>();
        settings = GetComponent<Settings>();
        userData = GetComponent<UserData>();
        clothesSettings = GetComponent<ClothesSettings>();
        savedSettings = GetComponent<SavedSettings>();
        gemasManager = GetComponent<GemasManager>();
        achievementEventsManager = GetComponent<AchievementEventsManager>();
    }
}
