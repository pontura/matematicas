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
        //int qty = 0;

        switch (element)
        {
            case elements.ARENA: _element = "arena"; break;
            case elements.MADERA: _element = "madera"; break;
            case elements.PIEDRAS: _element = "piedras"; break;
        }
        //switch (element)
        //{
        //    case elements.ARENA: _element = "arena"; qty = Game.Instance.inventary.arena; break;
        //    case elements.MADERA: _element = "madera"; qty = Game.Instance.inventary.madera; break;
        //    case elements.PIEDRAS: _element = "piedras"; qty = Game.Instance.inventary.piedras; break;
        //}
        string new_description = description;
        new_description = new_description.Replace("[element]", _element);
        new_description = new_description.Replace("[qty]", qty.ToString());

        print("GetDescription " + new_description + description);
        return new_description;
    }

}
