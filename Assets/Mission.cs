using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Mission {

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

    //public string GetDescription()
    //{
    //    string _element = "";

    //    switch (element)
    //    {
    //        case elements.ARENA: _element = "arena"; break;
    //        case elements.MADERA: _element = "madera"; break;
    //        case elements.PIEDRAS: _element = "piedras"; break;
    //    }
    //    string new_description = description;
    //    new_description = new_description.Replace("[element]", _element);
    //    new_description = new_description.Replace("[qty]", qty.ToString());

    //    print("GetDescription " + new_description + description);
    //    return new_description;
    //}

}
