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
        title.text = _title;
        panel.SetActive(true);
	}

    public void Send()
    {
        Events.OnSaveBlock(title.text);
        Cancel();
    }

    public void Cancel()
    {
        Game.Instance.mainMenu.BlockClose();
        Game.Instance.mainMenu.SetDisableButtons(false);
        panel.SetActive(false);
        Events.OnBlockReset();
    }
}
