using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AdminAlumnos : MonoBehaviour {

    public AdminAlumnosButton button;
    public Transform content;

    void Start()
    {
        print("OnGetAlumnosReady Start");
        Invoke("LoadData", 0.1f);
    }
    public void LoadData()
    {
        Events.OnAdminLoading(true);
        SocialEvents.OnGetAlumnos(0, OnGetAlumnosReady);
    }
    void OnGetAlumnosReady(string result)
    {
        int num = content.transform.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(content.transform.GetChild(0).gameObject);

        print("OnGetAlumnosReady" + result);
        string[] allData = Regex.Split(result, "</n>");

        for (var i = 0; i < allData.Length - 1; i++)
        {
            string[] userData = Regex.Split(allData[i], ":");

            UserData newData = new UserData();
            newData.userID = int.Parse(userData[0]);
            newData.username = userData[1];
            newData.password = userData[2];
            newData.email = userData[3];
            newData.logros = int.Parse(userData[4]);
            newData.filtered = int.Parse(userData[5]); 

            AdminAlumnosButton newButton = Instantiate(button);
            newButton.transform.SetParent(content);
            newButton.Init(this, newData);
            newButton.transform.localScale = Vector2.one;
            
        }
        Events.OnAdminLoading(false);
    }
    public void Clicked(UserData userdata)
    {
        print("clicked: " + userdata.username);
        GetComponent<AdminEjercicios>().Init(userdata);
    }
    public void Edit(UserData userdata)
    {
        GetComponent<AdminUserInfo>().Init(userdata);
    }
    public void Delete(UserData userdata)
    {
        print("Delete: " + userdata.username);
    }
    public void Close()
    {
        Events.QuitApp();
    }
}
