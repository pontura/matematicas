using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

public class MissionsManager : MonoBehaviour {
    
    public List<Mission> missions;

    string jsonUrl = "missions";

    void Start()
    {
        string filepath = (Application.dataPath + jsonUrl);
        TextAsset file = Resources.Load(jsonUrl) as TextAsset;
        LoadDataromServer(file.text);
    }
    
    public Mission GetActiveMission()
    {
        return missions[Data.Instance.userData.missionActive];
    }
    public IEnumerator GetServerData(string url)
    {
        WWW textURLWWW = new WWW(url);
        yield return textURLWWW;
        LoadDataromServer(textURLWWW.text);
        //Events.OnLoading(false);
    }
    public void LoadDataromServer(string json_data)
    {
        var Json = JSON.Parse(json_data);
        missions = new List<Mission>(Json["missions"].Count);
        for (int a = 0; a < Json["missions"].Count; a++)
        {
            Mission newMission = new Mission();
            newMission.id = int.Parse(Json["missions"][a]["id"]);
            newMission.islandId = int.Parse(Json["missions"][a]["islandId"]);
           
            newMission.qty = int.Parse(Json["missions"][a]["qty"]);

            switch (Json["missions"][a]["element"])
            {
                case "MADERA": newMission.element = Mission.elements.MADERA; break;
                case "PIEDRAS": newMission.element = Mission.elements.PIEDRAS; break;
                case "ARENA": newMission.element = Mission.elements.ARENA; break;
            }
            newMission.description = Json["missions"][a]["description"];
          //  newMission.description = GetDescription(newMission);

            missions.Add(newMission);
        }
        //foreach(Mission mission in missions)
        //{
        //    Debug.Log("M: " + mission.description);
        //}
    }
    public string SetDescription(Mission mission)
    {
        string _element = "";

        switch (mission.element)
        {
            case Mission.elements.ARENA: _element = "arena"; break;
            case Mission.elements.MADERA: _element = "madera"; break;
            case Mission.elements.PIEDRAS: _element = "piedras"; break;
        }
        string new_description = mission.description;
        new_description = new_description.Replace("[element]", _element);
        new_description = new_description.Replace("[qty]", mission.qty.ToString());
        return new_description;
    }
    public string GetDescription(int missionID)
    {
        string str = "";
        foreach (Mission mission in missions)
        {
            if (missionID == mission.id)
            {
                str = SetDescription(mission);
            }
        }
        return str;
    }
    public void OnMissionProgress(int missionID, int totalQty)
    {
        print("OnMissionProgress  " + missionID + "     totalQty : " + totalQty);
        foreach (Mission mission in missions)
        {
            if (missionID == mission.id)
            {
                mission.qty = totalQty;
            }
        }
    }
}
