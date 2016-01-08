using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserLogged : MonoBehaviour
{
    public Text introText;

    public void Init()
    {
        introText.text = "Bienvenido " + Data.Instance.userData.username + "!\n Estás listo para jugar?";
    }
    public void Submit()
    {
        Data.Instance.LoadLevel("Game");
    }
}
