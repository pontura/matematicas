using UnityEngine;
using System.Collections;

public class RankingUI : MonoBehaviour {

    public RankingButton rankingButton;
    public Transform container;

    void OnEnable()
    {
        int num = container.childCount;
        for (int i = 0; i < num; i++) DestroyImmediate(container.GetChild(0).gameObject);

        int id = 0;
        foreach (Ranking.RankingData data in SocialManager.Instance.ranking.data)
        {
            RankingButton button = Instantiate(rankingButton);
            button.transform.SetParent(container);
            button.transform.localScale = Vector2.one;
            button.Init(data.username, data.achievements.ToString());
            id++;
        }
    }
}
