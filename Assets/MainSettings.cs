using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainSettings : MonoBehaviour {

    public GameObject panel;
    public GameObject quit_btn;
    public GameObject reset_btn;
    public Text soundField;
    public GameObject iconoOn;
    public GameObject iconoOff;
    bool saliendo;

	void Start () {
        iconoOn.SetActive(false);
        iconoOff.SetActive(true);
        soundField.text = "SONIDO OFF";

        panel.SetActive(false);

        quit_btn.SetActive(true);
       // reset_btn.SetActive(false);

#if UNITY_EDITOR
      //  quit_btn.SetActive(false);
      //  reset_btn.SetActive(true);
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
    public void ToogleSounds()
    {
        Data.Instance.ToogleSounds();
        SetSonidosText();
    }
    void SetSonidosText()
    {
        if (Data.Instance.soundsOn)
        {
            iconoOn.SetActive(false);
            iconoOff.SetActive(true);
            soundField.text = "SONIDO OFF";
        }
        else
        {
            iconoOn.SetActive(true);
            iconoOff.SetActive(false);
            soundField.text = "SONIDO ON";
        }
    }
    public void ResetApp()
    {
        if (saliendo) return;
        saliendo = true;
        PlayerPrefs.SetString("username", "");
        PlayerPrefs.DeleteAll();       
        Events.OnResetApp();

        //Data.Instance.LoadLevel("01_Main");
        Invoke("SalirSinGrabar", 0.5f);
    }
    public void SalirSinGrabar()
    {
        Application.Quit();
    }
    public void Customizer()
    {
        Events.OnBlockStatus(false);
        Game.Instance.gameManager.OpenCustomizer();
        Close();
    }
    public void Salir()
    {
        if (saliendo) return;
        saliendo = true;
        Events.QuitApp();
        Invoke("SalirDone", 0.5f);
    }
    void SalirDone()
    {
        Application.Quit();
    }
    public void GuardarSalir()
    {
        if (saliendo) return;
        saliendo = true;
        Events.QuitApp();
        Invoke("GuardarSalir2", 0.5f);        
    }
    void GuardarSalir2()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

}
