using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonAddRemove : MonoBehaviour {

    public Text infoField;
    public int qty;
    public int id;
    public Text qtyField;
    public float peso;
    private MinigamePesos minigamePeso;

    public void Init(MinigamePesos minigamePeso,  float peso)
    {
        this.minigamePeso = minigamePeso;
        this.peso = (float)Math.Round((double)peso, 2);
        qty = 0;
        if(peso>999)
            qtyField.text = (peso / 1000) + " toneladas";
        else if(peso<1)
            qtyField.text = (peso * 1000) + " grames";
        else
            qtyField.text = peso + " Kilos";
        SetQty();
    }
    void SetQty()
    {
        infoField.text = qty.ToString();
    }
	public void Add () {
        qty++;
        SetQty();
        print("peso: " + peso);
        minigamePeso.Add(peso);
	}
    public void Remove()
    {
        if (qty > 0) qty--;
        SetQty();
        minigamePeso.Remove(peso);
    }
}

