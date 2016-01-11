﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;

public class UserPasswordValidation : MonoBehaviour
{
    public Text title;
    public Text password;
    public Text feedback;

    public void Init()
    {
        title.text = "Bienvenido " + Data.Instance.userData.username + ".\n Te enviamos un email a " + Data.Instance.userData.userID + " con el password para poder jugar.\nCopia el pega el password acá:";
    }

    public void Submit()
    {
        if (password.text == "")
            feedback.text = "Chequeá tu email e ingresa el password que te haya llegado";
        else if (Data.Instance.userData.OnValidatePassword(password.text))
        {
            Events.OnUserPasswordValidated();
        }
        else
        {
            feedback.text = "El password es incorrecto...";
        }
    }
}