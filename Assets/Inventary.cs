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
        Events.OnShipRefreshCarga();
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
            case "nafta":       if (nafta > 0) nafta -= qty;        break;
            case "comida":      if (comida > 0) comida -= qty;      break;
            case "madera":      if (madera > 0) madera -= qty;      break;
            case "arena":       if (arena > 0) arena -= qty;        break;
            case "piedras":     if (piedras > 0) piedras -= qty;    break;
        }
        Events.OnSaveInventary();
    }
    public int GetPesoTotalEnElBarco()
    {
        int peso = 0;
        peso += Data.Instance.settings.pesoArena * Game.Instance.inventary.arena;
        peso += Data.Instance.settings.pesoMadera * Game.Instance.inventary.madera;
        peso += Data.Instance.settings.pesoPiedras * Game.Instance.inventary.piedras;
        return peso;
    }
}
