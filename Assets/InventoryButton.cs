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
        Color color;
        if (!isOn)
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                color = button.image.color;
                color.a = 0.4f;
                button.image.color = color;
            }
        else
            foreach (Button button in GetComponentsInChildren<Button>())
            {
                color = button.image.color;
                color.a = 1;
                button.image.color = color;
            }
    }
    void SetQty()
    {
        qtyField.text = "x" + qty;
        inventary.SetQty(id, qty);
    }
    public void Add()
    {
        if (!isOn)
        {
            string _element = "";
            switch (id)
            {
                case 3: _element = "madera"; break;
                case 4: _element = "arena"; break;
                case 5: _element = "piedras"; break;
            }
            string new_description = Data.Instance.texts.elementos[0];
            new_description = new_description.Replace("[element]", _element);

            Events.OnTipText(new_description);
            return;
        }
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
