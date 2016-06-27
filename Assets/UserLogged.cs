using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserLogged : MonoBehaviour
{
    public Text introText;
    public Text buttonText;

    public void Init()
    {
        introText.text = "Bienvenido " + Data.Instance.userData.username + "!\n Estás listo para jugar?";
        if (!Data.Instance.userData.firstTimeHere)
        {
            buttonText.text = "SEGUIR JUGANDO";
        }
    }
    public void Submit()
    {
        Events.OnAdminLoading(true);
        if (Data.Instance.userData.firstTimeHere)
        {
            Data.Instance.LoadLevel("Intro");
        }
        else
        {
            Data.Instance.LoadLevel("Game");
        }
    }
}
