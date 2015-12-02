using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Isla : Screen {

    public Text titleField;
    public Text inventaryField;

	void OnEnable () {
        titleField.text = "";
	}
}
