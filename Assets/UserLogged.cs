using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserLogged : MonoBehaviour
{
    public Text introText;
    public Text buttonText;

    public void Init()
    {
       // introText.text = "Bienvenido " + Data.Instance.userData.username + "!\n Estás listo para jugar?";
        introText.text = "";
        if (!Data.Instance.userData.firstTimeHere)
        {
            buttonText.text = "SEGUIR JUGANDO";
        }
    }
    public void Submit()
    {
        Events.OnSoundFX("click");
        Events.OnAdminLoading(true);
        Data.Instance.LoadLevel("Intro");
    }
}
