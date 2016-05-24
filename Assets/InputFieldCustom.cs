using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputFieldCustom : MonoBehaviour {

    public InputField[] fields;
    public bool right;
    public int id;

	void Start () {
        right = true;
	}
    public void InputDone(int _id)
    {
        if (_id == 1) right = true;
        else if (_id == 6) right = false;

        if (!right) _id -= 2;

        fields[_id].Select();
        fields[_id].ActivateInputField();
    }
    public string GetContent()
    {
        string result = "";
        foreach (InputField input in fields)
        {
            int num = 0;
            try
            {
                num = int.Parse(input.text);
            }
            catch
            {
                Debug.Log("no hya numero");
            }
            result += num.ToString();
        }

        return result;
    }
}
