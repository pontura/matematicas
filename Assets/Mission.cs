using UnityEngine;
using System.Collections;

public class Mission : MonoBehaviour {

    public enum elements
    {
        MADERA,
        ARENA,
        PIEDRAS
    }
    public int islandId;
    public int id;
    public string description;
    public elements element;
    public int qty;

    public string GetDescription()
    {
        string _element = "";
        int qty = 0;

        switch (element)
        {
            case elements.ARENA: _element = "arena"; qty = Game.Instance.inventary.arena; break;
            case elements.MADERA: _element = "madera"; qty = Game.Instance.inventary.madera; break;
            case elements.PIEDRAS: _element = "piedras"; qty = Game.Instance.inventary.piedras; break;
        }

        description = description.Replace("[element]", _element);
        description = description.Replace("[qty]", qty.ToString());

        return description;
    }

}
