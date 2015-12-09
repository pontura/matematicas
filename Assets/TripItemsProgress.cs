using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TripItemsProgress : MonoBehaviour {

    public GameObject nafta;
    public GameObject comida;

    public int naftaQty;
    public int comidaQty;
	
    void OnDisable()
    {
        Events.OnSaveInventary -= OnSaveInventary;
    }
    void OnEnable()
    {
        Events.OnSaveInventary += OnSaveInventary;
        Invoke("Calculate", 0.1f);
    }
    void Calculate()
    {
        naftaQty = Game.Instance.inventary.nafta;
        comidaQty = Game.Instance.inventary.comida;

        SetQty(nafta, naftaQty);
        SetQty(comida, comidaQty);
    }
    void OnSaveInventary()
    {
        Calculate();
    }
    void SetQty(GameObject container, int qty)
    {
        Image[] gos = container.GetComponentsInChildren<Image>();

       // print(container + " qty: " + qty + "   gos.Length " + gos.Length);
        
        for (int a = 0; a < gos.Length; a++)
            gos[a].enabled =false;

        for (int a = 0; a < qty ; a++)
            gos[a].enabled = true;

    }
}
