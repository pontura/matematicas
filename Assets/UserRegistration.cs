using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class UserRegistration : MonoBehaviour {

    public Text username;
    public Text email;
    public Text password;
    public Text feedback;

    private string pass;
    private string _username;
    private string _userID;

    public GameObject registrationButton1;
    public GameObject registrationButton2;

    public enum states
    {
        IDLE,
        CHECKING,
        EXISTS,
        AVAILABLE
    }
    public states state;

    void Start()
    {
        registrationButton1.SetActive(false);
        registrationButton2.SetActive(false);
        Events.SendEmail += SendEmail;
    }
    void OnDestroy()
    {
        Events.SendEmail -= SendEmail;
    }
	void Update () {
        //if (state == states.AVAILABLE)
        //    EmailAvaiable();
        //else if (state == states.EXISTS)
        //    EmailExists();
	}

    public void Submit()
    {
        state = states.CHECKING;
        if (!IsValidEmail(email.text))
        {
            feedback.text = "El email es incorrecto";
            return;
        }
        if (username.text.Length < 1)
        {
            feedback.text = "El nombre de usuario es incorrecto";
            return;
        }
        SocialEvents.OnLogin(email.text, username.text);
        //CheckEmail(
        //        ParseObject.GetQuery("Users")
        //       .WhereEqualTo("userID", email.text)
        //   );
    }
    bool IsValidEmail(string strIn)
    {
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    public void SendEmail()
    {
        this.pass = Data.Instance.userData.password;
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("username", username.text);
        parameters.Add("to", email.text);
        parameters.Add("password", pass);

        print("__________SEND EMAIL username" + username.text + "email: " + email.text + " pass: " + pass);

        ParseCloud.CallFunctionAsync<string>("sendPassword", parameters)
          .ContinueWith(t =>
              Debug.Log("received: " + t.Result)
          );
        StartCoroutine(SendIt());
    }
    private IEnumerator SendIt( )
    {
        WWW www = new WWW("http://www.pontura.com/matematicas/PHPMailer/examples/mail.php?username=" + username.text + "&to=" + email.text + "&password=" + pass + "&from=no-responder@email.com");
        yield return www;

        if (www.error != null)
        {
            Debug.Log("EMAIL ENVIADO");
        }
        else
        {
            Debug.Log("EMAIL ERROR!");
        }
    }
    public void ReSendEmail()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("username", Data.Instance.userData.username);
        parameters.Add("to", Data.Instance.userData.userID);
        parameters.Add("password", Data.Instance.userData.password);

        ParseCloud.CallFunctionAsync<string>("sendPassword", parameters)
          .ContinueWith(t =>
              Debug.Log("received: " + t.Result)
          );
    }
    void EmailExists()
    {
        state = states.IDLE;
        feedback.text = "El email ya está usado";
        registrationButton1.SetActive(true);
        registrationButton2.SetActive(true);
        Data.Instance.userData.OnRegistration(_username, _userID, pass, "");
        Events.OnUserRegistration();
    }

    //public void Submit()
    //{
    //    state = states.CHECKING;
    //    if (!IsValidEmail(email.text))
    //    {
    //        feedback.text = "El email es incorrecto"; 
    //        return;
    //    }
    //    if (username.text.Length < 1)
    //    {
    //        feedback.text = "El nombre de usuario es incorrecto"; 
    //        return;
    //    }
    //     CheckEmail(
    //             ParseObject.GetQuery("Users")
    //            .WhereEqualTo("userID", email.text)
    //        );
    //}
    //void CheckEmail(ParseQuery<ParseObject> query)
    //{
    //    //query.FindAsync().ContinueWith(t =>
    //    //{
    //    //    print("CheckEmail");
    //    //    IEnumerable<ParseObject> results = t.Result;
    //    //    print(results);
    //    //    state = states.AVAILABLE;
    //    //    foreach (var result in results)
    //    //        state = states.EXISTS;

    //    //}
    //    //);

    //    query.FindAsync().ContinueWith(t =>
    //    {
    //        print("CheckEmail");
    //        IEnumerable<ParseObject> results = t.Result;

    //        state = states.AVAILABLE;

    //        foreach (var result in results)
    //        {
    //            state = states.EXISTS;
    //            _username = result.Get<string>("username");
    //            _userID = result.Get<string>("userID");
    //            pass = result.Get<string>("password");               
    //        }
    //    }
    //   );


    //}
    //void EmailAvaiable()
    //{
    //    if (!IsValidEmail(email.text))
    //    {
    //        feedback.text = "El email es incorrecto";
    //        return;
    //    }

    //    state = states.IDLE;
    //    pass = UnityEngine.Random.Range(10000,99999).ToString();

    //    ParseObject testObject = new ParseObject("Users");
    //    testObject["username"] = username.text;
    //    testObject["userID"] = email.text;
    //    testObject["password"] = pass;
    //    testObject.SaveAsync();

    //    SendEmail();

    //    Data.Instance.userData.OnRegistration(username.text, email.text, pass);
    //    Events.OnUserRegistration();
    //}
    //bool IsValidEmail(string strIn)
    //{
    //    return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    //}

}
