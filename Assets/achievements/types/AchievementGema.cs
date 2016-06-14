using UnityEngine;
using System.Collections;

public class AchievementGema : Achievement {

    public int gemaID;

	public void Init () {
        this.type = types.GEMA;

        if (Data.Instance.gemasManager.isReady(this.gemaID) == 1)
            Ready();
        else
            AchievementsEvents.OnGema += OnGema;
	}
    void OnGema(int _gemaID)
    {
        Debug.Log("OnGema" + gemaID);

        if (this.gemaID == _gemaID)
            Completed();
    }
}
