using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockItem : MonoBehaviour {

    public Text inputField;
    public int id;

	void Start () {
	
	}
    public void SetContent(string content)
    {
        if (GetComponent<InputFieldCustom>())
        {
            InputFieldCustom inputFieldCustom = GetComponent<InputFieldCustom>();
            for (int a = 0; a < 6; a++)
            {
                if(content.Length>=a+1)
                    inputFieldCustom.fields[a].text = content.Substring(a, 1);
            }
        }
        else
        {
            if (inputField != null && content.Length > 0)
                inputField.text = content;
        }
    }
}
