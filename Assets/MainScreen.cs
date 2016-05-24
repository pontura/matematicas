using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MainScreen : MonoBehaviour {

    public GameObject userRegistration;
    public GameObject userLogin;
    public GameObject userLogged;
    public GameObject userPasswordValidation;
    
    void Start()
    {
        ResetScreens();
        Events.OnUserRegistration += OnUserRegistration;
        Events.OnUserPasswordValidated += OnUserPasswordValidated;
        Invoke("Delay", 0.1f);        
    }
    void Delay()
    {
        //nuevo usuario:
        if (Data.Instance.userData.userID == "")
        {
            userRegistration.SetActive(true);
            Data.Instance.userData.firstTimeHere = true;
        }
        //todavia no puso el password:
        else if (Data.Instance.userData.passwordValidated == 0)
        {
            userPasswordValidation.SetActive(true);
            GetComponent<UserPasswordValidation>().Init();
            Data.Instance.userData.firstTimeHere = true;
        }
        //ya existe:
        else
        {
            userLogged.SetActive(true);
            GetComponent<UserLogged>().Init();
        }
    }
    void ResetScreens()
    {
        userRegistration.SetActive(false);
        userLogin.SetActive(false);
        userLogged.SetActive(false);
        userPasswordValidation.SetActive(false);
    }
    void OnUserRegistration()
    {
        ResetScreens();
        userPasswordValidation.SetActive(true);
        GetComponent<UserPasswordValidation>().Init();
        Events.SendEmail();
    }
    void OnUserPasswordValidated()
    {
        string username = Data.Instance.userData.username;
        string email = Data.Instance.userData.email;
        string password = Data.Instance.userData.password;

        SocialManager.Instance.loginManager.CreateUserIfNotExists(username, email, password);

        ResetScreens();
        userLogged.SetActive(true);
        GetComponent<UserLogged>().Init();
    }
    public void Registry()
    {
        ResetScreens();
        userRegistration.SetActive(true);
    }
    public void Admin()
    {
        Data.Instance.LoadLevel("Admin");
    }
}
