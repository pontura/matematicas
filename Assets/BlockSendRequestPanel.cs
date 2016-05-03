using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockSendRequestPanel : MonoBehaviour {

    public GameObject panel;
    public Text title;

    void Start()
    {
        panel.SetActive(false);
    }
    void OnDisable()
    {
        panel.SetActive(false);
    }
    public void Init(string _title)
    {
        Game.Instance.mainMenu.SetButtonsEnable(false);
        title.text = _title;
        panel.SetActive(true);
	}

    public void Send()
    {
        Events.OnSaveBlock(title.text);
    }

    public void Cancel()
    {
        Game.Instance.mainMenu.SetButtonsEnable(true);
        panel.SetActive(false);
    }
}
