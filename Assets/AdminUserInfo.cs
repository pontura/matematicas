using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdminUserInfo : MonoBehaviour {

    public GameObject panel;
    public Text title;
    public Text field;

    public void Start()
    {
        panel.SetActive(false);
    }
    public void Init(UserData userData)
    {
        panel.SetActive(true);

        title.text = userData.username;
        field.text = "email: " + userData.email;
        field.text += "\npassword: " + userData.password;
        field.text += "\nlogros: " + userData.logros;
    }
    public void Close()
    {
        panel.SetActive(false);
    }
}
