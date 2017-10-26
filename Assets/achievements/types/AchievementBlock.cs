using UnityEngine;
using System.Collections;

public class AchievementBlock : Achievement
{
    public int missionID;


	public void Init () {
        this.type = types.BLOCK;

        if (pointsToBeReady < Data.Instance.userData.totalBlocksNotes)
            Ready();
        else
            AchievementsEvents.OnNewBlockSended += OnNewBlockSended;
    }
    void OnNewBlockSended()
    {
        if (pointsToBeReady <= Data.Instance.userData.totalBlocksNotes)
        {
            Completed();
            AchievementsEvents.OnNewBlockSended -= OnNewBlockSended;
        }
    }
}
