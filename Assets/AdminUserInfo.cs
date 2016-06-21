using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdminUserInfo : MonoBehaviour {

    public Text esAlumno;
    public GameObject panel;
    public Text title;
    public Text field;

    public void Start()
    {
        panel.SetActive(false);
    }
    private UserData userData;
    public void Init(UserData userData)
    {
        this.userData = userData;
        panel.SetActive(true);

        title.text = userData.username;
        field.text = "email: " + userData.email;
        field.text += "\npassword: " + userData.password;
        field.text += "\nlogros: " + userData.logros;
        SetIfEsAlumno();
    }
    public void SwitchEsAlumno()
    {
        if (userData.filtered == 0)
            userData.filtered = 1;
        else 
            userData.filtered = 0;

        SetIfEsAlumno();

        print("userData.userID:::::::: " + userData.userID + " username: " + userData.username + " filtered: " + userData.filtered);

        SocialEvents.OnSetFiltered(userData.userID, userData.filtered, SetFilterReady);
    }
    void SetFilterReady()
    {
        GetComponent<AdminAlumnos>().LoadData();
        Close();
    }
    public void SetIfEsAlumno()
    {
        if (userData.filtered == 0)
            esAlumno.text = "X";
        else 
            esAlumno.text = "";
    }
    public void Close()
    {
        panel.SetActive(false);
    }
}
