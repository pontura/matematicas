using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using System.Collections;
using System.Collections.Generic;

public class UserRegistration : MonoBehaviour {

    public Text username;
    public Text email;
    public Text password;
    public Text feedback;

    public GameObject ResendButton;

    private string pass;
    private string _username;
    private int _userID;

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
        SocialEvents.OnLogin(username.text, email.text);
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

        StartCoroutine( SendIt(username.text, email.text, pass) );
        
    }
    private IEnumerator SendIt( String username, String email, String pass)
    {
        string cuerpo = "http://juegos.buber.edu.ar/chacmool/PHPMailer/examples/mail.php?username=" + username + "&to=" + email + "&password=" + pass + "&from=no-responder@email.com";
        WWW www = new WWW(cuerpo);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("EMAIL ENVIADO");
        }
        else
        {
            Debug.Log("EMAIL DONE " + cuerpo);
        }
    }
    public void ReSendEmail()
    {
        feedback.text = "Email re-enviado!";
        ResendButton.SetActive(false);
        StartCoroutine(SendIt(Data.Instance.userData.username, Data.Instance.userData.email, Data.Instance.userData.password));
    }
    void EmailExists()
    {
        state = states.IDLE;
        feedback.text = "El email ya está usado";
        registrationButton1.SetActive(true);
        registrationButton2.SetActive(true);
        //Data.Instance.userData.OnRegistration(_username, _userID, pass, "");
        //Events.OnUserRegistration();
    }

}
