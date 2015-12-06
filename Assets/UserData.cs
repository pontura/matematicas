using UnityEngine;
using System.Collections;

public class UserData : MonoBehaviour {

    public int islandActive;
    private Inventary inventary;

    void Start()
    {
        islandActive = PlayerPrefs.GetInt("islandActive", 1);

        inventary = GetComponent<Inventary>();

        inventary.nafta = PlayerPrefs.GetInt("nafta", 0);
        inventary.comida = PlayerPrefs.GetInt("comida", 0);
        inventary.madera = PlayerPrefs.GetInt("madera", 0);
        inventary.arena = PlayerPrefs.GetInt("arena", 0);
        inventary.piedras = PlayerPrefs.GetInt("piedras", 0);

        Events.OnShipArrived += OnShipArrived;

    }
    void OnShipArrived()
    {
        Invoke("SaveNewIsland", 1);
    }
    void SaveNewIsland()
    {
        if (Game.Instance)
             PlayerPrefs.SetInt("islandActive", Game.Instance.islandsManager.activeIsland.id);

        PlayerPrefs.SetInt("nafta", inventary.nafta);
        PlayerPrefs.SetInt("comida", inventary.comida);
        PlayerPrefs.SetInt("madera", inventary.madera);
        PlayerPrefs.SetInt("arena", inventary.arena);
        PlayerPrefs.SetInt("piedras", inventary.piedras);
    }
}
