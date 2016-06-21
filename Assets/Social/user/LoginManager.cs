using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoginManager : MonoBehaviour
{
    private string username;

    void Start()
    {
        SocialEvents.OnLogin += OnLogin;
    }
    void OnLogin(string _email, string _username)
    {

        //Debug.Log("CheckIfUserExists: " + _email + " username: " + _username);

        //string url = SocialManager.Instance.FIREBASE + "/users.json?orderBy=\"email\"&equalTo=\"" + _email + "\"";

        //Debug.Log(url);

        //HTTP.Request someRequest = new HTTP.Request("get", url);
        //someRequest.Send((request) =>
        //{
        //    Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);

        //    if (decoded == null)
        //    {
        //        Debug.Log("no existe el user or malformed response ):");
        //        return;
        //    }
        //    else if (decoded.Count == 0)
        //    {
        //        //usuario nuevo manda email:
        //       // Events.OnUserRegistration();
        //        Data.Instance.userData.OnRegistration(_username, _email, UnityEngine.Random.Range(10000, 99999).ToString(), "");
        //    }
        //    else
        //    {
        //        foreach (DictionaryEntry json in decoded)
        //        {
        //            Hashtable jsonObj = (Hashtable)json.Value;
        //            //Score s = new Score();
        //            string id = (string)json.Key.ToString();
        //            string username = (string)jsonObj["username"];
        //            string password = (string)jsonObj["password"];
        //            Data.Instance.userData.OnRegistration(username, _email, password, id);
        //        }
        //    }
        //});
    }
    public void CreateUserIfNotExists(string username, string _email, string password)
    {

        string url = SocialManager.Instance.PHP + "";


        //Debug.Log("CreateUserIfNotExists: " + _email);

        //string url = SocialManager.Instance.FIREBASE + "/users.json?orderBy=\"email\"&equalTo=\"" + _email + "\"";

        //Debug.Log(url);

        //HTTP.Request someRequest = new HTTP.Request("get", url);
        //someRequest.Send((request) =>
        //{
        //    Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);

        //    if (decoded == null || decoded.Count == 0)
        //    {
        //        AddNewUserTODB(username, _email, password);
        //        return;
        //    }
        //    else if (decoded.Count > 0)
        //    {
        //        foreach (DictionaryEntry json in decoded)
        //        {
        //            Hashtable jsonObj = (Hashtable)json.Value;
        //            string id = (string)json.Key.ToString();
         //           Data.Instance.userData.SaveObjectID(id);
        //        }
        //        Debug.Log("Ya existias");
        //    }
        //});
    }
    void AddNewUserTODB(string username, string email, string password)
    {
        Debug.Log("AddNewUser" + username + "_" + email + "_" + password);

        Hashtable data = new Hashtable();

        data.Add("username", username);
        data.Add("email", email);
        data.Add("password", password);
        data.Add("achievements", 0);

        Hashtable blockContent = new Hashtable();
        //blockContent.Add("title", "");
        //blockContent.Add("content", "");

        data.Add("block", blockContent);        

        HTTP.Request theRequest = new HTTP.Request("post", SocialManager.Instance.FIREBASE + "/users.json", data);
        theRequest.Send((request) =>
        {
            Hashtable jsonObj = (Hashtable)JSON.JsonDecode(request.response.Text);
            if (jsonObj == null)
            {
                Debug.LogError("server returned null or malformed response ):");
            }
            else
            {
                Debug.Log("nuevo usuario!!");
                GetObjectID(email);
            }
        });
    }
    void GetObjectID(string _email)
    {
        Debug.Log("GetObjectID: " + _email);

        string url = SocialManager.Instance.FIREBASE + "/users.json?orderBy=\"email\"&equalTo=\"" + _email + "\"";

        Debug.Log(url);

        HTTP.Request someRequest = new HTTP.Request("get", url);
        someRequest.Send((request) =>
        {
            Hashtable decoded = (Hashtable)JSON.JsonDecode(request.response.Text);

            if (decoded == null)
            {
                Debug.Log("no existe el user or malformed response ):");
                return;
            }
            else if (decoded.Count > 0)
            {
                foreach (DictionaryEntry json in decoded)
                {
                    Hashtable jsonObj = (Hashtable)json.Value;
                    string id = (string)json.Key.ToString();
                   // Data.Instance.userData.SaveObjectID(id);
                }
            }
        });
        
    }
}
