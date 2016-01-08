using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserRegistration : MonoBehaviour {

    public Text username;
    public Text email;
    public Text password;
    public Text feedback;
    private enum states
    {
        IDLE,
        CHECKING,
        EXISTS,
        AVAILABLE
    }
    private states state;

	void Update () {
        if (state == states.AVAILABLE)
            EmailAvaiable();
        else if (state == states.EXISTS)
            EmailExists();
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
         CheckEmail(
                 ParseObject.GetQuery("Users")
                .WhereEqualTo("userID", email.text)
            );
    }
    void CheckEmail(ParseQuery<ParseObject> query)
    {
        query.FindAsync().ContinueWith(t =>
        {
            print("CheckEmail");
            IEnumerable<ParseObject> results = t.Result;
            print(results);
            state = states.AVAILABLE;
            foreach (var result in results)
                state = states.EXISTS;

        }
        );
    }
    void EmailAvaiable()
    {
        state = states.IDLE;
        string pass = UnityEngine.Random.Range(10000,99999).ToString();

        ParseObject testObject = new ParseObject("Users");
        testObject["username"] = username.text;
        testObject["userID"] = email.text;
        testObject["password"] = pass;
        testObject.SaveAsync();

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("username", username.text);
        parameters.Add("to", email.text);
        parameters.Add("password", pass);

        ParseCloud.CallFunctionAsync<string>("sendPassword", parameters)
            .ContinueWith(t =>
                Debug.Log("received: " + t.Result)
            );

        Data.Instance.userData.OnRegistration(username.text, email.text, pass);
        Events.OnUserRegistration();
    }
    bool IsValidEmail(string strIn)
    {
        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    void EmailExists()
    {
        state = states.IDLE;
        feedback.text = "El email ya está usado";
    }
}
