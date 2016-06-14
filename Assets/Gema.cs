using UnityEngine;
using System.Collections;

public class Gema : MonoBehaviour {

    public int id;

	void Start () {
        if (Data.Instance.gemasManager.isReady(id)==1)
            Destroy(gameObject);
	}
    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Events.OnGetGema(id);
            AchievementsEvents.OnGema(id);
            Destroy(gameObject);
        }
    }
}
