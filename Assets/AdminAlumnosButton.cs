using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdminAlumnosButton : MonoBehaviour {

    public Text field;
    public Button userButton;
    public Button editButton;
    public Button deleteButton;

    public void Init(AdminAlumnos _admin,  UserData userdata)
    {
        field.text = userdata.username;
        userButton.onClick.AddListener(() => { _admin.Clicked(userdata); });
        editButton.onClick.AddListener(() => { _admin.Edit(userdata); });
        deleteButton.onClick.AddListener(() => { _admin.Delete(userdata); });
    }
}
