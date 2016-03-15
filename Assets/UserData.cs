using UnityEngine;
using System.Collections;
using System;

public class UserData : MonoBehaviour {

    public bool firstTimeHere;
    public int distanceTraveled;
    public string userID;
    public string username;
    public string password;
    public int passwordValidated;

    public int islandActive;
    public int missionActive;
    private Inventary inventary;

    void Start()
    {
        userID = PlayerPrefs.GetString("userID");
        username = PlayerPrefs.GetString("username", "");
        password = PlayerPrefs.GetString("password");
        passwordValidated = PlayerPrefs.GetInt("passwordValidated", 0);
        distanceTraveled = PlayerPrefs.GetInt("distanceTraveled", 0);

        if (username == "") firstTimeHere = true;

        islandActive = PlayerPrefs.GetInt("islandActive", 1);
        missionActive = PlayerPrefs.GetInt("missionActive", 0);

        inventary = GetComponent<Inventary>();

        inventary.nafta = PlayerPrefs.GetInt("nafta", 0);
        inventary.comida = PlayerPrefs.GetInt("comida", 0);
        inventary.madera = PlayerPrefs.GetInt("madera", 0);
        inventary.arena = PlayerPrefs.GetInt("arena", 0);
        inventary.piedras = PlayerPrefs.GetInt("piedras", 0);

        Events.OnShipArrived += OnShipArrived;
        Events.OnSaveInventary += OnSaveInventary;
        Events.OnNewMission += OnNewMission;
        Events.OnMissionComplete += OnMissionComplete;
        Events.OnResetApp += OnResetApp;
        Events.NewDistanceTraveled += NewDistanceTraveled;
    }
    public void OnRegistration(string _username, string _userID, string _password)
    {
        print("OnRegistration");
        this.username = _username;
        this.userID = _userID;
        this.password = _password;
        passwordValidated = 0;

        PlayerPrefs.SetString("userID", _userID);
        PlayerPrefs.SetString("username", _username);
        PlayerPrefs.SetString("password", _password);
        PlayerPrefs.SetInt("passwordValidated", 0);

    }
    public bool OnValidatePassword(string _password)
    {
        if (password == _password)
        {
            passwordValidated = 1;
            PlayerPrefs.SetInt("passwordValidated", 1);
            return true;
        }
        return false;
    }
    void OnResetApp()
    {
        islandActive = 1;
        missionActive = 0;

        inventary.nafta = 0;
        inventary.comida = 0;
        inventary.madera = 0;
        inventary.arena = 0;
        inventary.piedras = 0;

        distanceTraveled = 0;
        userID = "";
        username = "";
        password = "";
        islandActive = 1;

    }
    void OnMissionComplete()
    {
        AchievementsEvents.OnMissionComplete(missionActive);
        missionActive++;
        Events.OnNewMission(missionActive);
    }
    void OnNewMission(int id)
    {
        PlayerPrefs.SetInt("missionActive", id);
    }
    void OnShipArrived()
    {
        Invoke("SaveNewIsland", 1);
    }
    void SaveNewIsland()
    {
        if (Game.Instance)
             PlayerPrefs.SetInt("islandActive", Game.Instance.islandsManager.activeIsland.id);
        OnSaveInventary();        
    }
    void OnSaveInventary()
    {
        PlayerPrefs.SetInt("nafta", inventary.nafta);
        PlayerPrefs.SetInt("comida", inventary.comida);
        PlayerPrefs.SetInt("madera", inventary.madera);
        PlayerPrefs.SetInt("arena", inventary.arena);
        PlayerPrefs.SetInt("piedras", inventary.piedras);
    }
    void NewDistanceTraveled(int new_distanceTraveled)
    {
        distanceTraveled += new_distanceTraveled;
        PlayerPrefs.SetInt("distanceTraveled", distanceTraveled);
        AchievementsEvents.OnNewDistance(distanceTraveled);
    }
}
