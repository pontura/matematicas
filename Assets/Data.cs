using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
   // const string PREFAB_PATH = "Data";
    static Data mInstance = null;
    public bool DEBUG;
    public bool admin;
    public bool RESET_APP;

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
    public bool soundsOn;
    public AudioClip tema;
    public AudioClip playa;
    public AudioClip bosque;

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
        SceneManager.LoadScene(aLevelName);
    }
    void Awake()
    {
#if UNITY_EDITOR
        if (RESET_APP)
           PlayerPrefs.DeleteAll();
#endif
        soundsOn = true;
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
    public void VolumenIntro()
    {
        GetComponent<AudioSource>().volume = 0.45f;
    }
    public void VolumenBaja()
    {
        GetComponent<AudioSource>().volume = 0.15f;
    }
    public void VolumenSube()
    {
        GetComponent<AudioSource>().volume = 1;
    }
    public void ToogleSounds()
    {
        soundsOn = !soundsOn;
        if (!soundsOn)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().Play();
            if(GetComponent<AudioSource>().clip != tema)
                GetComponent<AudioSource>().volume = 1;
        }
    }
    public void SuenaTema(float volumen)
    {
        if (soundsOn)
            GetComponent<AudioSource>().volume = volumen;

        if (GetComponent<AudioSource>().clip == tema) return;
        GetComponent<AudioSource>().clip = tema;
        if (!soundsOn)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().Play();
            
        }
    }
    public void SuenaPlaya()
    {
        if (GetComponent<AudioSource>().clip == playa) return;
        GetComponent<AudioSource>().clip = playa;
        if (!soundsOn)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume = 0.4f;
        }
    }
    public void SuenaBosque()
    {
        if (GetComponent<AudioSource>().clip == bosque) return;
        GetComponent<AudioSource>().clip = bosque;
        if (!soundsOn)
            GetComponent<AudioSource>().Stop();
        else
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume = 0.5f;
        }
    }
}
