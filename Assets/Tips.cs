using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tips : MonoBehaviour {

    public GameObject panel;
    public Text field;

	void Start () {
        SetOff();
        Events.OnTipsOn += OnTipsOn;
	}
    void OnDestroy()
    {
        panel.SetActive(false);
        Events.OnTipsOn -= OnTipsOn;
    }
    public void Ready()
    {
        SetOff();
    }
    void OnTipsOn(int id)
    {
        field.text = Data.Instance.texts.GetFilteredText(Data.Instance.texts.tutorial, id);
        panel.SetActive(true);
	}
    void SetOff()
    {
        panel.SetActive(false);
    }
}
