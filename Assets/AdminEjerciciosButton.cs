using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdminEjerciciosButton : MonoBehaviour {

    public Text field;
    public Button editButton;

    public void Init(AdminEjercicios _admin, AdminEjercicios.Block blockData)
    {
        field.text = blockData.title;
        editButton.onClick.AddListener(() => { _admin.Clicked(blockData); });
    }
}
