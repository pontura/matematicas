using UnityEngine;
using System.Collections;

public class GemasManager : MonoBehaviour {

    public int gema1;
    public int gema2;
    public int gema3;
    public int gema4;
    public int gema5;
    public int gema6;

	void Start () {
        gema1 = PlayerPrefs.GetInt("gema1", 0);
        gema2 = PlayerPrefs.GetInt("gema2", 0);
        gema3 = PlayerPrefs.GetInt("gema3", 0);
        gema4 = PlayerPrefs.GetInt("gema4", 0);
        gema5 = PlayerPrefs.GetInt("gema5", 0);
        gema6 = PlayerPrefs.GetInt("gema6", 0);
        Events.OnGetGema += OnGetGema;
	}
    void OnGetGema(int gemaID)
    {
        switch (gemaID)
        {
            case 1: gema1 = 1; break;
            case 2: gema2 = 1; break;
            case 3: gema3 = 1; break;
            case 4: gema4 = 1; break;
            case 5: gema5 = 1; break;
            case 6: gema6 = 1; break;
        }
        PlayerPrefs.SetInt("gema" + gemaID, 1);
    }
    public int isReady(int gemaID)
    {
        int gema = 0;
        switch (gemaID)
        {
            case 1: gema = gema1; break;
            case 2: gema = gema2; break;
            case 3: gema = gema3; break;
            case 4: gema = gema4; break;
            case 5: gema = gema5; break;
            case 6: gema = gema6; break;
        }
        return gema;
    }
    public bool AreGemasReady()
    {
        if (gema1 == 1 && gema2 == 1 && gema3 == 1 && gema4 == 1)
            return true;
        else
            return false;
    }
}
