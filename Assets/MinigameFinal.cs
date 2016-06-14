using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class MinigameFinal : Minigame {

    public InputField inputField;
    public MathDevice mathDevice;

    private float _separationY = 0.16f;

    void Start()
    {
        
    }
    void OnEnable()
    {
        Events.OnMinigameStartCalculator();
        inputField.text = "";
    }
    public void Init()
    {
        descSmall.text = "";
        desc.text = "";
        
        string textFinal = "Usá los símbolos especiales que recogiste en las islas. En ellos encontrarás las claves para invocar la magia en el dialecto nativo de la Multinesia. Si te falta alguno, explorá las islas y encontrá la información.";
       
        inputField.gameObject.SetActive(false);

        if (Data.Instance.gemasManager.AreGemasReady())
        {
            textFinal = "¡Ya recolectaste toda la información que necesitás sobre el dialecto nativo de la Multinesia!\nEscribí la palabra clave en la tabla para abrir el portal. ";
            inputField.gameObject.SetActive(true);
        }
        mathDevice.Init(Game.Instance.islandsManager.activeIsland.minigameType);
        descSmall.text = textFinal;
    }
    
    override public void Reset()
    {
        inputField.text = "";
    }
    public void CheckResult()
    {
        if (inputField.text.ToUpper() == "VIDA")
            MinigameReady();
        else
            Events.OnMinigameMistake();
    }
    void MinigameReady()
    {
        Events.OnMinigameReady();
    }
}
