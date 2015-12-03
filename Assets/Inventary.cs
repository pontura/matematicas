using UnityEngine;
using System.Collections;

public class Inventary : MonoBehaviour
{
    public int MAX_ITEMS;

    public int nafta;
    public int comida;
    public int madera;
    public int arena;
    public int piedras;

    public void SetQty(int id, int qty)
    {
        switch (id)
        {
            case 1: nafta = qty; break;
            case 2: comida = qty; break;
            case 3: madera = qty; break;
            case 4: arena = qty; break;
            case 5: piedras = qty; break;
        }
    }
    public int GetQty(int id)
    {
        switch (id)
        {
            case 1: return nafta;
            case 2: return comida;
            case 3: return madera;
            case 4: return arena;
            default: return piedras;
        }
    }
    public int GetTotal()
    {
        return nafta + comida + madera + arena + piedras;
    }
    public bool IsFull()
    {
        if (GetTotal() >= MAX_ITEMS) return true;
        return false;
    }
    public void ConsumeElement(string element, int qty)
    {
        switch (element)
        {
            case "nafta": nafta = qty; break;
            case "comida": comida = qty; break;
            case "madera": madera = qty; break;
            case "arena": arena = qty; break;
            case "piedras": piedras = qty; break;
        }
    }
}
