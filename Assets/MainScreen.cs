using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Parse;
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

        if (Data.Instance.userData.userID == "")
            userRegistration.SetActive(true);
        else if (Data.Instance.userData.passwordValidated == 0)
        {
            userPasswordValidation.SetActive(true);
            GetComponent<UserPasswordValidation>().Init();
        }
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
    }
    void OnUserPasswordValidated()
    {
        ResetScreens();
        userLogged.SetActive(true);
        GetComponent<UserLogged>().Init();
    }
}
