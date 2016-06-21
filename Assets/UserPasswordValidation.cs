﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UserPasswordValidation : MonoBehaviour
{
    public Text title;
    public InputField password;
    public Text feedback;

    public void Init(bool newUser)
    {
        print("Data.Instance.userData.password" + Data.Instance.userData.password);
        if (newUser)
        {
            title.text = "Se ha enviado un correo electrónico a " + Data.Instance.userData.email + " con la contraseña para empezar a jugar..\nEscribila acá:";
            password.text = Data.Instance.userData.password.ToString();
        }
        else
        {
            title.text = "Bienvenido nuevamente, " + Data.Instance.userData.username + ".\n Te enviamos un email a " + Data.Instance.userData.email + " con el password para poder jugar.\nPoné el password acá:";
            password.text = "";
        }
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
