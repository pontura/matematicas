using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    public int distancia_Caja_Energia;
    public int horas_Caja_Comida;
    public int barcoVelocidad;
    public int barcoPesoMaximo;

    public int pesoMadera;
    public int pesoArena;
    public int pesoPiedras;

    public string GetNotes()
    {
        string notas = "";
        notas += "1 caja de energía cubre " + distancia_Caja_Energia + " km\n";
        notas += "1 caja de comida dura " + horas_Caja_Comida + " horas\n";

        notas += "1 caja de madera pesa " + pesoMadera + "\n";
        notas += "1 caja de arena pesa " + pesoArena + "\n";
        notas += "1 caja de piedras pesa " + pesoPiedras + "\n";

        notas += "Velocidad del barco: " + barcoVelocidad + "Km/h";

        return notas;
    }

}
