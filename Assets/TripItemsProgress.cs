using UnityEngine;
using System.Collections;

public class TripItemsProgress : MonoBehaviour {

    public GameObject nafta;
    public GameObject comida;

    public int naftaQty;
    public int comidaQty;

	void OnEnable () {

        naftaQty = Game.Instance.inventary.nafta;
        comidaQty = Game.Instance.inventary.comida;

        SetQty(nafta, naftaQty);
        SetQty(comida, comidaQty);

	}
    void SetQty(GameObject container, int qty)
    {
        Transform[] gos = container.GetComponentsInChildren<Transform>();

        for (int a = 0; a < gos.Length; a++)
            gos[a].gameObject.SetActive(false);

        for (int a = 0; a < qty; a++)
            gos[a].gameObject.SetActive(true);

    }
    void Update()
    {
	    
	}
}
