using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButton : MonoBehaviour
{

    public int qty;
    public int id;
    public Text titleField;
    public Text qtyField;
    private Inventary inventary;
    public bool isOn;

    void OnEnable()
    {
        SetStatus(true);
        inventary = Game.Instance.inventary;
        qty = inventary.GetQty(id);

        IslandsManager.DataIsland dataIsland = Game.Instance.islandsManager.activeIsland;

        if (id == 3) { if (!dataIsland.madera) SetStatus(false); else SetStatus(true); }
        if (id == 4) { if (!dataIsland.arena) SetStatus(false); else SetStatus(true); }
        if (id == 5) { if (!dataIsland.piedras) SetStatus(false); else SetStatus(true); }
        SetQty();
    }
    void SetStatus(bool on)
    {
        isOn = on;
        if (!isOn)
            foreach (Button button in GetComponentsInChildren<Button>()) button.interactable = false;
        else
            foreach (Button button in GetComponentsInChildren<Button>()) button.interactable = true;
    }
    void SetQty()
    {
        qtyField.text = "x" + qty;
        inventary.SetQty(id, qty);
    }
    public void Add()
    {
        if (!isOn) return;
        if (inventary.IsFull()) return;
        qty++;
        SetQty();
    }
    public void Remove()
    {
        if (!isOn) return;
        if (qty > 0) qty--;
        SetQty();
    }
}
