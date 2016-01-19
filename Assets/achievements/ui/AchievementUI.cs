using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementUI : MonoBehaviour {

    public AchivementButtonUI achievementButton;
    public Transform container;
    public Text descriptionField;

	void OnEnable () {
        descriptionField.text = "Seleccioná un logro para saber de qué se trata...";
        int id = 0;
        foreach (Achievement achievement in AchievementsManager.Instance.achievements)
        {
            AchivementButtonUI button = Instantiate(achievementButton);
            button.transform.SetParent(container);
            button.id = id;
            button.GetComponent<Button>().onClick.AddListener(() => { Clicked(button); });
            button.transform.localScale = Vector2.one;
            id++;
        }
	}
    void Clicked(AchivementButtonUI achivementButtonUI)
    {
        Achievement achievement = AchievementsManager.Instance.GetAchievement(achivementButtonUI.id);
        descriptionField.text = achievement.title;

    }
}
