using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAddRemove : MonoBehaviour {

    public int qty;
    public int id;
    public Text titleField;
    public Text qtyField;
    public int peso;
    private MinigamePesos minigamePeso;

    public void Init(MinigamePesos minigamePeso,  int peso)
    {
        this.minigamePeso = minigamePeso;
        titleField.text = peso.ToString() + "k";
        this.peso = peso;
    }
    void SetQty()
    {
        qtyField.text = "x" + qty;
    }
	public void Add () {
        qty++;
        SetQty();
        minigamePeso.Add(peso);
	}
    public void Remove()
    {
        if (qty > 0) qty--;
        SetQty();
        minigamePeso.Remove(peso);
    }
}

