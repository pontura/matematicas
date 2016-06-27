using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MainScreen : MonoBehaviour {

    public GameObject userRegistration;
    public GameObject userLogin;
    public GameObject userLogged;
    public GameObject userPasswordValidation;
    public GameObject loading;
    
    void Start()
    {
        loading.SetActive(false);
        ResetScreens();
        Events.OnUserRegistration += OnUserRegistration;
        Events.OnUserPasswordValidated += OnUserPasswordValidated;        
        Events.OnAdminLoading += OnAdminLoading;
        Invoke("Delay", 0.1f);
    }
    void OnDestroy()
    {
        Events.OnUserRegistration -= OnUserRegistration;
        Events.OnUserPasswordValidated -= OnUserPasswordValidated;
        Events.OnAdminLoading -= OnAdminLoading;
    }
    void OnAdminLoading(bool state)
    {
        loading.SetActive(true);
    }
    void Delay()
    {
        //nuevo usuario:
        if (Data.Instance.userData.userID == 0)
        {
            userRegistration.SetActive(true);
            Data.Instance.userData.firstTimeHere = true;
        }
        //todavia no puso el password:
        else if (Data.Instance.userData.passwordValidated == 0)
        {
            userPasswordValidation.SetActive(true);
            GetComponent<UserPasswordValidation>().Init(false);
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
    void OnUserRegistration(bool newUser)
    {
        ResetScreens();
        userPasswordValidation.SetActive(true);
        GetComponent<UserPasswordValidation>().Init(newUser);
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
