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

}
