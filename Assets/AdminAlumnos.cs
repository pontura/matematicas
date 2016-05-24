using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdminAlumnos : MonoBehaviour {

    public AdminAlumnosButton button;
    public Transform content;

    void Start()
    {
        Events.OnAdminLoading(true);
        string url = SocialManager.Instance.FIREBASE + "/users.json";

        Debug.Log(url);

        HTTP.Request someRequest = new HTTP.Request("get", url);
        someRequest.Send((request) =>
        {
            Events.OnAdminLoading(false);
            Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);
            
            if (decoded == null)
            {
                Debug.Log("no existe el user or malformed response ):");
                return;
            }
            else
            {
                foreach (DictionaryEntry json in decoded)
                {
                    
                    Hashtable jsonObj = (Hashtable)json.Value;
                    string id = (string)json.Key.ToString();

                    UserData userData = new UserData();

                    userData.userID = (string)json.Key.ToString();
                    userData.username = (string)jsonObj["username"];
                    userData.password = (string)jsonObj["password"];
                    userData.email = (string)jsonObj["email"];
                    userData.logros = (int)jsonObj["achievements"];
                  
                    AdminAlumnosButton newButton = Instantiate(button);
                    newButton.transform.SetParent(content);
                    newButton.Init(this, userData);
                    newButton.transform.localScale = Vector2.one;

                    Debug.Log(userData.username);
                }
            }
        });
    }
    public void Clicked(UserData userdata)
    {
        print("clicked: " + userdata.username);
        GetComponent<AdminEjercicios>().Init(userdata);
    }
    public void Edit(UserData userdata)
    {
        print("Edit: " + userdata.username);
        GetComponent<AdminUserInfo>().Init(userdata);
    }
    public void Delete(UserData userdata)
    {
        print("Delete: " + userdata.username);
    }
    public void Close()
    {
        Application.Quit();
    }
}
