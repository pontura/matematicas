using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UserPasswordValidation : MonoBehaviour
{
    public Text title;
    public Text password;
    public Text feedback;

    public void Init()
    {
        print("Data.Instance.userData.password" + Data.Instance.userData.password);
        title.text = "Tu nuevo password es: " + Data.Instance.userData.password + ".\n Introducilo en el campo de abajo para entrar a la aventura.";
       // title.text = "Bienvenido " + Data.Instance.userData.username + ".\n Te enviamos un email a " + Data.Instance.userData.email + " con el password para poder jugar.\nPoné el password acá:";
        password.text = Data.Instance.userData.password.ToString();
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
