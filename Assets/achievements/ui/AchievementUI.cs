using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementUI : MonoBehaviour {

    public AchivementButtonUI achievementButton;
    public Transform container;
    public Text descriptionField;
<<<<<<< Updated upstream
    private bool tutorialDisplayed;

	void OnEnable () {
        if (Data.Instance.userData.firstTimeHere && !tutorialDisplayed)
        {
            Events.OnTipsOn(5);
            tutorialDisplayed = true;
        }
        int num = container.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(container.GetChild(0).gameObject);

=======

	void OnEnable () {
>>>>>>> Stashed changes
        descriptionField.text = "Seleccioná un logro para saber de qué se trata...";
        int id = 0;
        foreach (Achievement achievement in AchievementsManager.Instance.achievements)
        {
            AchivementButtonUI button = Instantiate(achievementButton);
            button.transform.SetParent(container);
            button.id = id;
<<<<<<< Updated upstream
            button.LoadImage(achievement.image);
            button.SetProgress(achievement.progress);
            button.SetReady(achievement.ready);
=======
>>>>>>> Stashed changes
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
