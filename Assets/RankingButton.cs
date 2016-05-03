using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankingButton : MonoBehaviour {

    public Text field;

	public void Init (string username, string logros) {
        field.text = username;

        if(int.Parse(logros)==1)
            field.text  += " (1 logro)";
        else if (int.Parse(logros) == 0)
            field.text += " (sin logros aún)";
        else
            field.text += " (" + logros + " logros)";

	}
}
