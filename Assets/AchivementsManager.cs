using UnityEngine;
using System.Collections;

public class AchivementsManager : MonoBehaviour {

    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        Events.OnAchivementWin += OnAchivementWin;
    }
    void OnAchivementWin(int id)
    {
        panel.SetActive(true);
    }
    public void Close()
    {
        panel.SetActive(false);
    }
}
