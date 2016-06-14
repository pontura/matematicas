using UnityEngine;
using System.Collections;

public class GemasUIMAnager : MonoBehaviour {

    public GameObject gema1;
    public GameObject gema2;
    public GameObject gema3;
    public GameObject gema4;
    public GameObject gema5;
    public GameObject gema6;

	void Start () {

        gema1.SetActive(false);
        gema2.SetActive(false);
        gema3.SetActive(false);
        gema4.SetActive(false);
        gema5.SetActive(false);
        gema6.SetActive(false);

        if (Data.Instance.gemasManager.gema1 == 1) gema1.SetActive(true);
        if (Data.Instance.gemasManager.gema2 == 1) gema2.SetActive(true);
        if (Data.Instance.gemasManager.gema3 == 1) gema3.SetActive(true);
        if (Data.Instance.gemasManager.gema4 == 1) gema4.SetActive(true);
        if (Data.Instance.gemasManager.gema5 == 1) gema5.SetActive(true);
        if (Data.Instance.gemasManager.gema6 == 1) gema6.SetActive(true);

        Events.OnGetGema += OnGetGema;
	}
    void OnDestroy()
    {
        Events.OnGetGema -= OnGetGema;
    }
	
    void OnGetGema(int gemaID)
    {
        if (gemaID == 1) gema1.SetActive(true);
        if (gemaID == 2) gema2.SetActive(true);
        if (gemaID == 3) gema3.SetActive(true);
        if (gemaID == 4) gema4.SetActive(true);
        if (gemaID == 5) gema5.SetActive(true);
        if (gemaID == 6) gema6.SetActive(true);
	}
}
