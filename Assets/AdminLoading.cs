using UnityEngine;
using System.Collections;

public class AdminLoading : MonoBehaviour {

    public GameObject panel;

	void Start () {
        Events.OnAdminLoading += OnAdminLoading;
	}
    void OnDestroy()
    {
        Events.OnAdminLoading -= OnAdminLoading;
    }
    void OnAdminLoading(bool isActive)
    {
        panel.SetActive(isActive);
	}

}
