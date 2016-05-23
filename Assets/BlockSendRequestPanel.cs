using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockSendRequestPanel : MonoBehaviour {

    public GameObject panel;
    public Text title;
    public Button SendButton;

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

    void Update()
    {
        if (Game.Instance.gameManager.Block.GetComponent<Block>().isEmpty)
            SendButton.interactable = false;
        else
            SendButton.interactable = true;
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
