using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class IslandDistances : MonoBehaviour {

    public List<Ruta> rutas;
    public Text field;

    [Serializable]
    public class Ruta
    {
        public string name;
        public List<IslaData> islas;
        public int total;
        public GameObject lineAsset;
    }

    [Serializable]
    public class IslaData
    {
        public int islaID;
        public string fraccion;
        public int km;
        public string ruta;
    }

    public List<IslaData> resultsIslaA;
    public List<IslaData> resultsIslaB;

    void OnEnable()
    {
        foreach (Ruta ruta in rutas)
        {
            ruta.lineAsset.SetActive(false);
        }
        field.text = "";
    }

	public string GetRuta (int islaA, int islaB) {
        field.text = "";
        print("GetRuta " + islaA + "     islaB   " + islaB);

        resultsIslaA.Clear();
        resultsIslaB.Clear();
	    string result = "";
        
        foreach (Ruta ruta in rutas)
        {
            ruta.lineAsset.SetActive(false);
            foreach (IslaData isla in ruta.islas)
            {
                if (isla.islaID == islaA) 
                {
                    resultsIslaA.Add(isla);
                }
                if (isla.islaID == islaB) 
                {
                    resultsIslaB.Add(isla);
                }
            }
        }
        if (resultsIslaA.Count == 0 || resultsIslaB.Count == 0) return "";

        foreach (IslaData dataA in resultsIslaA)
        {
            foreach (IslaData dataB in resultsIslaB)
            {
                if (dataA.ruta == dataB.ruta)
                {
                    SetActiveRuta(dataA.ruta);
                    string origen = "el inicio";
                    if (dataA.islaID == 5)
                        origen = "la Ruta " + GetRutaTitle("E");

                    if (dataA.islaID == 1)
                        result = "Estás en el continente.";
                    else if (dataA.islaID == 4 && dataB.ruta == "E")
                        result = "Estás al inicio de la Ruta " + GetRutaTitle("E");
                    else
                        result = "La isla en la que estás se encuentra a " + dataA.km + " km del continente.";

                    result += "\nTu destino está a " + dataB.fraccion + "  de la distancia entre " + origen + " y el final de esta ruta.";

                    field.text = "Ruta " + GetRutaTitle(dataA.ruta) + ". Total: " + GetRuta(dataA.ruta).total + "km.";
                }
            }
        }

        
        return result;
	}
    public string GetRutaTitle(string referenceName)
    {
        switch (referenceName)
        {
            case "A": return "Alfa";
            case "B": return "Beta";
            case "C": return "Gamma";
            case "D": return "Delta";
            default: return "Epsilon";
        }

    }
    void SetActiveRuta(string rutaName)
    {
        foreach(Ruta ruta in rutas)
        {
            if (ruta.name == rutaName)
            {
                ruta.lineAsset.SetActive(true);
            }
        }
    }
    private Ruta GetRuta(string rutaName)
    {
        foreach (Ruta ruta in rutas)
        {
            if (ruta.name == rutaName)
            {
                return ruta;
            }
        }
        return null;
    }
}
