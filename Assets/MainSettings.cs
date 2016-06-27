using UnityEngine;
using System.Collections;

public class MainSettings : MonoBehaviour {

    public GameObject panel;
    public GameObject quit_btn;
    public GameObject reset_btn;

	void Start () {
        panel.SetActive(false);

        quit_btn.SetActive(true);
       // reset_btn.SetActive(false);

#if UNITY_EDITOR
        quit_btn.SetActive(false);
        reset_btn.SetActive(true);
#endif
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Open()
    {
        print("Open");
        panel.SetActive(true);
    }
    public void ResetApp()
    {
        PlayerPrefs.SetString("username", "");
        PlayerPrefs.DeleteAll();       
        Events.OnResetApp();
        
      //  Data.Instance.LoadLevel("01_Main");
        Invoke("Salir", 0.5f);
    }
    public void Customizer()
    {
        Events.OnBlockStatus(false);
        Game.Instance.gameManager.OpenCustomizer();
        Close();
    }
    public void Salir()
    {
        Application.Quit();
    }

}
