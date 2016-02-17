using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tips : MonoBehaviour {

    public GameObject panel;
    public Text field;

	void Start () {
        SetOff();
        Events.OnTipsOn += OnTipsOn;
        Events.OnTipText += OnTipText;
	}
    void OnDestroy()
    {
        panel.SetActive(false);
        Events.OnTipsOn -= OnTipsOn;
        Events.OnTipText -= OnTipText;
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
    void OnTipText(string text)
    {
        field.text = text;
        panel.SetActive(true);
    }
    void SetOff()
    {
        panel.SetActive(false);
    }
}
