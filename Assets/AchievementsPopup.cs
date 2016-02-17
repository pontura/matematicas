using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementsPopup : MonoBehaviour {

    public GameObject panel;
    public Text field;
    public AchivementButtonUI icon;

	void Start () {
        panel.SetActive(false);
        AchievementsEvents.OnReady += OnReady;
	}	
	void OnDestroy () {
        AchievementsEvents.OnReady -= OnReady;
	}
    void OnReady(int id)
    {
        panel.SetActive(true);
        Achievement achievement = AchievementsManager.Instance.GetAchievement(id);
        field.text = achievement.title;

        icon.SetProgress(1);
        icon.LoadImage(achievement.image);
    }
    public void Close()
    {
        panel.SetActive(false);
    }
}
