using UnityEngine;
using System.Collections;

public class MainSettings : MonoBehaviour {

    public GameObject panel;

	void Start () {
        panel.SetActive(false);
	}
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Open()
    {
        panel.SetActive(true);
    }
    public void ResetApp()
    {
        Events.OnResetApp();
        PlayerPrefs.DeleteAll();
        Data.Instance.LoadLevel("01_Main");
    }
    public void Customizer()
    {
        Events.OnBlockStatus(false);
        Game.Instance.gameManager.OpenCustomizer();
        Close();
    }

}
